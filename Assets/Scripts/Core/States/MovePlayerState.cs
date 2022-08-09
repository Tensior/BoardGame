using System.Linq;
using Core.Camera;
using Core.Players;
using Core.Turns;

namespace Core.States
{
    public class MovePlayerState : MovementState
    {
        private readonly ICameraController _cameraController;

        public MovePlayerState(
            ITurnsProvider turnsProvider, 
            IPlayerProvider playerProvider, 
            ICameraController cameraController,
            PlayerMovesHolder playerMovesHolder) 
            : base(turnsProvider, playerProvider, playerMovesHolder)
        {
            _cameraController = cameraController;
        }

        public override void Enter()
        {
            base.Enter();
            _cameraController.ActivatePlayer(Player);
        }

        public override IState Update()
        {
            if (Player.IsMoving)
            {
                return null;
            }

            if (PlayerMovesHolder.MovesLeft == 0)
            {
                return StatesContainer.PassTurnState;
            }

            var node = Player.CurrentNode;
            NodePath.Clear();
            FillNodePath(node);

            if (NodePath.Any())
            {
                Player.SetNodePath(NodePath);
                return null;
            }

            return StatesContainer.SelectDirectionState;
        }

        public override void Exit()
        {
            
        }
    }
}