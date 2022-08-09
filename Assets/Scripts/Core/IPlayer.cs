using System.Collections.Generic;
using Configs;
using Core.Map;
using UnityEngine;

namespace Core
{
    public interface IPlayer
    {
        PlayerID PlayerID { get; }
        bool IsMoving { get; }
        Node CurrentNode { get; set; }
        Transform Transform { get; }
        void SetNodePath(List<Node> nodes);
    }
}