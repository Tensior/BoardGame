using Meta;
using UIView.ViewModels;
using UnityEngine;

namespace UIMediation.Mediators
{
    public sealed class MainMenuMediator : ShowableMediator
    {
        private readonly MainMenuVM _mainMenuVM;
        private readonly ISceneLoader _sceneLoader;

        public MainMenuMediator(MainMenuVM mainMenuVM, ISceneLoader sceneLoader) : base(mainMenuVM)
        {
            _mainMenuVM = mainMenuVM;
            _sceneLoader = sceneLoader;
            
            Show();
        }

        protected override void Show()
        {
            base.Show();
            
            _mainMenuVM.OnStartGameClicked += StartGame;
            _mainMenuVM.OnExitGameClicked += ExitGame;
        }

        protected override void Hide()
        {
            base.Hide();
            
            _mainMenuVM.OnExitGameClicked -= ExitGame;
            _mainMenuVM.OnStartGameClicked -= StartGame;
        }

        private async void StartGame()
        {
            Hide();
            await _sceneLoader.LoadLevelAsync();
        }

        private void ExitGame()
        {
            Hide();
            Application.Quit();
        }
    }
}