using Meta;
using UIView.ViewModels;

namespace UIMediation.Mediators
{
    public sealed class GameMenuMediator : ShowableMediator
    {
        private readonly GameMenuVM _gameMenuVM;
        private readonly ISceneLoader _sceneLoader;

        public GameMenuMediator(GameMenuVM gameMenuVM, ISceneLoader sceneLoader) : base(gameMenuVM)
        {
            _gameMenuVM = gameMenuVM;
            _sceneLoader = sceneLoader;
            
            Show();
        }

        public override void Show()
        {
            base.Show();
            
            _gameMenuVM.OnExitToMainMenuClicked += ExitToMainMenu;
        }

        public override void Hide()
        {
            base.Hide();

            _gameMenuVM.OnExitToMainMenuClicked -= ExitToMainMenu;
        }

        private void ExitToMainMenu()
        {
            Hide();
            
            _sceneLoader.LoadMainMenuAsync();
        }
    }
}