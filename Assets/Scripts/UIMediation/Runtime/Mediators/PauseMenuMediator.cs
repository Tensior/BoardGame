using Meta;
using UIView.ViewModels;

namespace UIMediation.Mediators
{
    public sealed class PauseMenuMediator : ShowableMediator
    {
        private readonly PauseMenuVM _pauseMenuVM;
        private readonly ISceneLoader _sceneLoader;

        public PauseMenuMediator(PauseMenuVM pauseMenuVM, ISceneLoader sceneLoader) : base(pauseMenuVM)
        {
            _pauseMenuVM = pauseMenuVM;
            _sceneLoader = sceneLoader;
            
            Hide();
        }

        protected override void Show()
        {
            base.Show();
            
            _pauseMenuVM.OnExitToMainMenuClicked += ExitToMainMenu;
        }

        protected override void Hide()
        {
            base.Hide();

            _pauseMenuVM.OnExitToMainMenuClicked -= ExitToMainMenu;
        }

        private void ExitToMainMenu()
        {
            Hide();
            
            _sceneLoader.LoadMainMenuAsync();
        }
    }
}