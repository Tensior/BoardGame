using UnityEngine;

namespace Input
{
    public class InputManager : MonoBehaviour, IInputProvider, IInputController
    {
        private bool _isSmallDiceChosen;
        private bool _isLargeDiceChosen;
        private bool _isDiceStopped;

        bool IInputProvider.IsSmallDiceChosen => _isSmallDiceChosen;
        
        bool IInputProvider.IsLargeDiceChosen => _isLargeDiceChosen;
        
        bool IInputProvider.IsDiceStopped => _isDiceStopped;

        bool IInputController.IsSmallDiceChosen
        {
            set => _isSmallDiceChosen = value;
        }

        bool IInputController.IsLargeDiceChosen
        {
            set => _isLargeDiceChosen = value;
        }

        bool IInputController.IsDiceStopped
        {
            set => _isDiceStopped = value;
        }

        private void LateUpdate()
        {
            _isSmallDiceChosen = false;
            _isLargeDiceChosen = false;
            _isDiceStopped = false;
        }
    }
}
