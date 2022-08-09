using Configs;
using Core.Players;
using Core.Turns;
using Input;
using UIMediation.Mediators;

namespace Core.States
{
    public class SelectDirectionState : MovementState
    {
        private readonly PlayerMoveDirectionsMediator _playerMoveDirectionsMediator;
        private readonly IInputProvider _inputProvider;

        public SelectDirectionState(
            ITurnsProvider turnsProvider,
            IPlayerProvider playerProvider,
            PlayerMoveDirectionsMediator playerMoveDirectionsMediator,
            IInputProvider inputProvider,
            PlayerMovesHolder playerMovesHolder)
            : base(turnsProvider, playerProvider, playerMovesHolder)
        {
            _playerMoveDirectionsMediator = playerMoveDirectionsMediator;
            _inputProvider = inputProvider;
        }

        public override void Enter()
        {
            base.Enter();

            if (Player.PlayerID == PlayerID.Player)
            {
                _playerMoveDirectionsMediator.Show();
                _playerMoveDirectionsMediator.SetPosition(Player.Transform.position);
                foreach (var nextNode in Player.CurrentNode.NextNodes)
                {
                    _playerMoveDirectionsMediator.AddArrow(nextNode.Position);
                }
            }
        }

        public override IState Update()
        {
            if (!_inputProvider.SelectedDirection.HasValue)
            {
                return null;
            }

            var node = Player.CurrentNode.NextNodes[_inputProvider.SelectedDirection.Value];
            --PlayerMovesHolder.MovesLeft;
            NodePath.Clear();
            NodePath.Add(node);
            FillNodePath(node);

            Player.SetNodePath(NodePath);
            return StatesContainer.MovePlayerState;
        }

        public override void Exit()
        {
            base.Exit();

            if (Player.PlayerID == PlayerID.Player)
            {
                _playerMoveDirectionsMediator.Hide();
            }
        }
    }
}