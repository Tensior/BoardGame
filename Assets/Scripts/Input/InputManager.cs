using Zenject;

namespace Input
{
    public class InputManager : IInputProvider, IInputController, ITickable
    {
        private bool _isSmallDiceChosen;
        private bool _isLargeDiceChosen;
        private bool _isDiceStopped;
        private int? _selectedDirection;

        bool IInputProvider.IsSmallDiceChosen => _isSmallDiceChosen;
        
        bool IInputProvider.IsLargeDiceChosen => _isLargeDiceChosen;
        
        bool IInputProvider.IsDiceStopped => _isDiceStopped;

        int? IInputProvider.SelectedDirection => _selectedDirection;

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

        int? IInputController.SelectedDirection
        {
            set => _selectedDirection = value;
        }

        void ITickable.Tick()
        {
            _isSmallDiceChosen = false;
            _isLargeDiceChosen = false;
            _isDiceStopped = false;
            _selectedDirection = null;
        }
    }
}
