using System.Threading.Tasks;

namespace Meta
{
    public interface ILevelLoader
    {
        Task LoadLevelAsync();
        Task LoadMainMenuAsync();
    }
}