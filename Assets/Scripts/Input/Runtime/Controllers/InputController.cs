using Input.Interfaces;

namespace Input.Controllers
{
    public class InputController : IInputController
    {
        public InputController()
        {
            
        }
        
        void IInputController.SetGameplayActive(bool isActive)
        {
            if (isActive)
            {
                //_controls.Gameplay.Enable();
            }
            else
            {
                //_controls.Gameplay.Disable();
            }
        }
    }
}