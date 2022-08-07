using Zenject;

namespace Input
{
    public class InputManager : IInputProvider, IInputController, ITickable
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

        void ITickable.Tick()
        {
            _isSmallDiceChosen = false;
            _isLargeDiceChosen = false;
            _isDiceStopped = false;
        }
    }
}
