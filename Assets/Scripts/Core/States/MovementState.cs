using System.Collections.Generic;
using System.Linq;
using Core.Map;
using Core.Players;
using Core.Turns;

namespace Core.States
{
    public abstract class MovementState : IState
    {
        protected readonly List<Node> NodePath = new();
        protected readonly PlayerMovesHolder PlayerMovesHolder;
        protected IPlayer Player;
        private readonly ITurnsProvider _turnsProvider;
        private readonly IPlayerProvider _playerProvider;

        protected MovementState(
            ITurnsProvider turnsProvider, 
            IPlayerProvider playerProvider,
            PlayerMovesHolder playerMovesHolder)
        {
            _turnsProvider = turnsProvider;
            _playerProvider = playerProvider;
            PlayerMovesHolder = playerMovesHolder;
        }

        public virtual void Enter()
        {
            Player = _playerProvider.GetPlayer(_turnsProvider.CurrentPlayerID);
        }

        public abstract IState Update();

        public virtual void Exit() { }

        protected void FillNodePath(Node startNode)
        {
            while (startNode.NextNodes.Count == 1 && PlayerMovesHolder.MovesLeft > 0)
            {
                --PlayerMovesHolder.MovesLeft;
                startNode = startNode.NextNodes.First();
                NodePath.Add(startNode);
            }
        }
    }
}