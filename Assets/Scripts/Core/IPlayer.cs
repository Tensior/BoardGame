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
        Node NextNode { get; set; }
        Transform CameraTarget { get; }
    }
}