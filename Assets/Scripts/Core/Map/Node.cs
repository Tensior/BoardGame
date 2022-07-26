using System.Collections.Generic;
using UnityEngine;

namespace Core.Map
{
    public class Node : MonoBehaviour
    {
        [SerializeField] private List<Node> _nextNodes = new();

        public Vector3 Position => transform.position;
        public List<Node> NextNodes => _nextNodes;
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            //Gizmos.DrawSphere(transform.position, 1f);
            foreach (var nextNode in _nextNodes)
            {
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
            }
        }
    }
}