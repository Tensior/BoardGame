using Meta;
using UIMediation.Mediators.Base;
using UIView.ViewModels;
using UnityEngine;

namespace UIMediation.Mediators
{
    public sealed class MainMenuMediator : ShowableMediator<MainMenuVM>
    {
        private readonly ISceneLoader _sceneLoader;

        public MainMenuMediator(MainMenuVM mainMenuVM, ISceneLoader sceneLoader) : base(mainMenuVM)
        {
            _sceneLoader = sceneLoader;
            
            Show();
        }

        public override void Show()
        {
            base.Show();
            
            ViewModel.OnStartGameClicked += StartGame;
            ViewModel.OnExitGameClicked += ExitGame;
        }

        public override void Hide()
        {
            base.Hide();
            
            ViewModel.OnExitGameClicked -= ExitGame;
            ViewModel.OnStartGameClicked -= StartGame;
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