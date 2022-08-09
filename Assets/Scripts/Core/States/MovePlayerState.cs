using System.Collections.Generic;
using System.Linq;
using Core.Camera;
using Core.Map;
using Core.Players;
using Core.Turns;
using UIMediation.Mediators;

namespace Core.States
{
    public class MovePlayerState : IState
    {
        private readonly ITurnsProvider _turnsProvider;
        private readonly IPlayerProvider _playerProvider;
        private readonly ICameraController _cameraController;
        private readonly UseDiceMediator _useDiceMediator;
        private readonly List<Node> _nodePath = new();
        private IPlayer _player;
        private int _stepsLeft;

        public MovePlayerState(
            ITurnsProvider turnsProvider, 
            IPlayerProvider playerProvider, 
            ICameraController cameraController,
            UseDiceMediator useDiceMediator)
        {
            _turnsProvider = turnsProvider;
            _playerProvider = playerProvider;
            _cameraController = cameraController;
            _useDiceMediator = useDiceMediator;
        }
        
        void IState.Enter()
        {
            _player = _playerProvider.GetPlayer(_turnsProvider.CurrentPlayerID);
            _cameraController.ActivatePlayer(_player);
            _stepsLeft = _useDiceMediator.Number;
        }

        IState IState.Update()
        {
            if (_player.IsMoving)
            {
                return null;
            }

            if (_stepsLeft == 0)
            {
                return StatesContainer.PassTurnState;
            }

            var node = _player.CurrentNode;
            _nodePath.Clear();
            while (node.NextNodes.Count == 1 && _stepsLeft > 0)
            {
                --_stepsLeft;
                node = node.NextNodes.First();
                _nodePath.Add(node);
            }
            
            _player.SetNodePath(_nodePath);
            return null;
        }

        void IState.Exit()
        {
            
        }
    }
}