using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Core.Map
{
    public class MapManager : IMapManager, IInitializable
    {
        private readonly List<Node> _nodes;
        private Node _startNode;
        private Node _finishNode;

        Node IMapManager.StartNode => _startNode;
        Node IMapManager.FinishNode => _finishNode;

        public MapManager(Transform nodesRoot)
        {
            _nodes = nodesRoot.GetComponentsInChildren<Node>().ToList();
        }

        void IInitializable.Initialize()
        {
            foreach (var node in _nodes)
            {
                if (node.NextNodes is not { Count: > 0 })
                {
                    _finishNode = node;
                }
                else if (!_nodes.Any(nodeAny => nodeAny.NextNodes.Contains(node)))
                {
                    _startNode = node;
                }
            }
        }
    }
}