using Input;
using UIMediation.Mediators.Base;
using UIView.ViewModels;
using UnityEngine;

namespace UIMediation.Mediators
{
    public class PlayerMoveDirectionsMediator : InputShowableMediator<PlayerMoveDirectionsVM>
    {
        public PlayerMoveDirectionsMediator(PlayerMoveDirectionsVM viewModel, IInputController inputController) 
            : base(viewModel, inputController) { }

        public override void Show()
        {
            base.Show();
            
            ViewModel.Arrows.Clear();
        }

        public void SetPosition(Vector3 position)
        {
            ViewModel.Position = position;
        }

        public void AddArrow(Vector3 nextNodePosition)
        {
            var arrowVM = new ArrowVM(
                ViewModel.Arrows.Count,
                Quaternion.LookRotation(nextNodePosition - ViewModel.Position));

            arrowVM.OnArrowClicked += SelectDirection;
            
            ViewModel.Arrows.Add(arrowVM);
        }

        private void SelectDirection(int arrowIndex)
        {
            InputController.SelectedDirection = arrowIndex;
        }
    }
}