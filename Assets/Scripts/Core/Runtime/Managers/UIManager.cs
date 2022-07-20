using Core.Interfaces;
using Input.Interfaces;
using UIMediation.Mediators;
using UnityEngine;
using Zenject;

namespace Core.Managers
{
    public class UIManager : MonoBehaviour
    {
        private IPauseController _pauseController;
        private IInputProvider _inputProvider;
        private PauseMenuMediator _pauseMenuMediator;
        
        [Inject]
        public void Inject(IPauseController pauseController, IInputProvider inputProvider, PauseMenuMediator pauseMenuMediator)
        {
            _pauseController = pauseController;
            _inputProvider = inputProvider;
            _pauseMenuMediator = pauseMenuMediator;
        }

        private void Update()
        {
            if (!_inputProvider.IsPause)
            {
                return;
            }
            
            _pauseController.TogglePause();

            
            /*_pauseMenuMediator.IsShown = _pauseController.IsPaused;
            _inputProvider.SetGameplayActive(!_pauseController.IsPaused);*/
        }

        private void OnDestroy()
        {
            if (_pauseController.IsPaused)
            {
                _pauseController.TogglePause();
            }
        }
    }
}