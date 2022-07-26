using Meta;
using UIMediation.Mediators.Base;
using UIView.ViewModels;

namespace UIMediation.Mediators
{
    public sealed class GameMenuMediator : ShowableMediator<GameMenuVM>
    {
        private readonly ISceneLoader _sceneLoader;

        public GameMenuMediator(GameMenuVM gameMenuVM, ISceneLoader sceneLoader) : base(gameMenuVM)
        {
            _sceneLoader = sceneLoader;
            
            Show();
        }

        public override void Show()
        {
            base.Show();
            
            ViewModel.OnExitToMainMenuClicked += ExitToMainMenu;
        }

        public override void Hide()
        {
            base.Hide();

            ViewModel.OnExitToMainMenuClicked -= ExitToMainMenu;
        }

        private void ExitToMainMenu()
        {
            Hide();
            
            _sceneLoader.LoadMainMenuAsync();
        }
    }
}