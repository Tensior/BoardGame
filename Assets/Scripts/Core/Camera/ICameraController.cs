namespace Core.Camera
{
    public interface ICameraController
    {
        void ActivateOverview();
        void ActivatePlayer(IPlayer player);
    }
}