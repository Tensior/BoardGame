using Configs;
using Core.Map;
using UnityEngine;

namespace Core
{
    public class Player : MonoBehaviour
    {
        public PlayerID PlayerID;

        private Node _currentNode;
        private Node _nextNode;

        public void SetCurrentNode(Node node)
        {
            if (_currentNode != null)
            {
                _currentNode.FreeYPosition -= Constants.PlayerYOffset;
            }
            
            _currentNode = node;
            UpdateCurrentTransform();
        }

        private void UpdateCurrentTransform()
        {
            transform.position = _currentNode.Position + transform.up * _currentNode.FreeYPosition;
            _currentNode.FreeYPosition += Constants.PlayerYOffset;
        }

        public void SetNextNode(Node node)
        {
            _nextNode = node;
        }
    }
}