using Cinemachine;
using Zenject;

namespace Core.Camera
{
    public class CameraController : ICameraController
    {
        private readonly CinemachineVirtualCamera _overviewCamera;
        private readonly CinemachineVirtualCamera _playerCamera;

        public CameraController(
            [Inject(Id = CameraType.Overview)] CinemachineVirtualCamera overviewCamera,
            [Inject(Id = CameraType.Player)] CinemachineVirtualCamera playerCamera)
        {
            _overviewCamera = overviewCamera;
            _playerCamera = playerCamera;
        }

        void ICameraController.ActivateOverview()
        {
            _playerCamera.Priority = 0;
            _overviewCamera.Priority = 10;
        }

        void ICameraController.ActivatePlayer(IPlayer player)
        {
            _overviewCamera.Priority = 0;
            
            _playerCamera.Priority = 10;
            _playerCamera.Follow = player.CameraTarget;
            _playerCamera.LookAt = player.CameraTarget;
        }
    }
}