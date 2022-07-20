using Input.Interfaces;

namespace Input.Providers
{
    public class InputProvider : IInputProvider
    {
        private readonly InputActions _controls;

        public InputProvider(InputActions controls)
        {
            _controls = controls;
            _controls.Enable();
        }

        bool IInputProvider.IsPause => _controls.Menu.Pause.triggered;
    }
}
