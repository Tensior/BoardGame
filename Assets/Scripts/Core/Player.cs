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
        
        [SerializeField] private PlayerID _playerID;

        private Node _currentNode;
        private Node _nextNode;
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;

        PlayerID IPlayer.PlayerID => _playerID;
        bool IPlayer.IsMoving => _nextNode != null;
        Node IPlayer.CurrentNode
        {
            get => _currentNode;
            set => SetCurrentNode(value);
        }
        Node IPlayer.NextNode
        {
            get => _nextNode;
            set => SetNextNode(value);
        }

        Transform IPlayer.CameraTarget => transform;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (_nextNode != null && _navMeshAgent.remainingDistance < 0.0001f)
            {
                SetCurrentNode(_nextNode);
                SetNextNode(null);
            }
        }

        private void SetCurrentNode(Node value)
        {
            if (_currentNode != null)
            {
                _currentNode.FreeYPosition -= Constants.PlayerYOffset;
            }
            else
            {
                _navMeshAgent.baseOffset = value.FreeYPosition;
                _navMeshAgent.Warp(value.Position + transform.up * value.FreeYPosition);
            }

            _currentNode = value;
            _currentNode.FreeYPosition += Constants.PlayerYOffset;
        }

        private void SetNextNode(Node value)
        {
            _nextNode = value;
            
            if (_nextNode != null)
            {
                _navMeshAgent.SetDestination(_nextNode.Position);
                _navMeshAgent.baseOffset = _nextNode.FreeYPosition;
            }
            _navMeshAgent.isStopped = _nextNode == null;
            
            _animator.SetBool(IsMovingToNextNode, _nextNode != null);
        }
    }
}