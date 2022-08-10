using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Core.Map
{
    public class MapProvider : IMapProvider, IInitializable
    {
        private readonly List<Node> _nodes;
        private Node _startNode;
        private Node _finishNode;

        Node IMapProvider.StartNode => _startNode;
        Node IMapProvider.FinishNode => _finishNode;

        public MapProvider(Transform nodesRoot)
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