﻿using Meta;
using UIMediation.Mediators.Base;
using UIView.ViewModels;

namespace UIMediation.Mediators
{
    public sealed class GameHUDMediator : ShowableMediator<GameHUDVM>
    {
        private readonly ILevelLoader _levelLoader;
        
        public string CurrentPlayer
        {
            get => ViewModel.CurrentPlayer;
            set => ViewModel.CurrentPlayer = value;
        }
        
        public int CurrentTurn
        {
            get => ViewModel.CurrentTurn;
            set => ViewModel.CurrentTurn = value;
        }

        public GameHUDMediator(GameHUDVM gameHUDVM, ILevelLoader levelLoader) : base(gameHUDVM)
        {
            _levelLoader = levelLoader;
            
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
            
            _levelLoader.LoadMainMenuAsync();
        }
    }
}