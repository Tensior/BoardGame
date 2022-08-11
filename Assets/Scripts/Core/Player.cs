using System;
using System.Collections.Generic;
using Configs;
using Core.Map;
using UnityEngine;
using UnityEngine.AI;

namespace Core
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Player : MonoBehaviour, IPlayer
    {
        private static readonly int IsMovingToNextNode = Animator.StringToHash("IsMovingToNextNode");
        private const float NODE_POSITION_THRESHOLD = 0.5f;

        [SerializeField] private PlayerID _playerID;

        private Node _currentNode;
        private Node _nextNode;
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;
        private List<Node>.Enumerator _nodePath;
        private float? _distBetweenNodes;

        PlayerID IPlayer.PlayerID => _playerID;
        bool IPlayer.IsMoving => _nextNode != null;
        Node IPlayer.CurrentNode
        {
            get => _currentNode;
            set => SetCurrentNode(value);
        }
        Transform IPlayer.Transform => transform;

        void IPlayer.SetNodePath(List<Node> nodePath)
        {
            _nodePath = nodePath.GetEnumerator();
            _nodePath.MoveNext();
            SetNextNode(_nodePath.Current);
        }

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (_nextNode == null || _navMeshAgent.pathPending)
            {
                return;
            }

            if (!_distBetweenNodes.HasValue)
            {
                _distBetweenNodes = _navMeshAgent.remainingDistance;
            }
            
            if (Math.Abs(_currentNode.FreeYPosition - _nextNode.FreeYPosition) > 0.0001)
            {
                _navMeshAgent.baseOffset = Mathf.Lerp(
                    _nextNode.FreeYPosition,
                    _currentNode.FreeYPosition,
                    _navMeshAgent.remainingDistance / _distBetweenNodes.Value);
            }

            if (_navMeshAgent.remainingDistance < NODE_POSITION_THRESHOLD)
            {
                SetCurrentNode(_nextNode);
                SetNextNode(_nodePath.MoveNext() ? _nodePath.Current : null);
            }
        }

        private void SetCurrentNode(Node value)
        {
            if (_currentNode != null)
            {
                _currentNode.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else
            {
                _navMeshAgent.Warp(value.Position + transform.up * value.FreeYPosition);
            }

            _currentNode = value;
            _currentNode.FreeYPosition += Constants.PlayerYOffset;
            _currentNode.GetComponent<SpriteRenderer>().color = Color.red;
        }

        private void SetNextNode(Node value)
        {
            if (_nextNode != null)
            {
                _nextNode.transform.localScale /= 3;
            }

            _nextNode = value;
            
            if (_nextNode != null)
            {
                _navMeshAgent.SetDestination(_nextNode.Position);
                _distBetweenNodes = null;
                _nextNode.transform.localScale *= 3;
                
                if (_currentNode != null)
                {
                    _currentNode.FreeYPosition -= Constants.PlayerYOffset;
                }
            }
            _navMeshAgent.isStopped = _nextNode == null;
            
            _animator.SetBool(IsMovingToNextNode, _nextNode != null);
        }
    }
}