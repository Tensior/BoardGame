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

            var node = Player.CurrentNode;
            
            if (PlayerMovesHolder.MovesLeft == 0 || node.NextNodes.Count == 0)
            {
                return StatesContainer.CheckFinishState;
            }

            if (node.NextNodes.Count > 1)
            {
                return StatesContainer.SelectDirectionState;
            }
            
            NodePath.Clear();
            FillNodePath(node);
            Player.SetNodePath(NodePath);
            
            return null;
        }

        public override void Exit()
        {
            
        }
    }
}