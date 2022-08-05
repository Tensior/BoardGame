using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Meta
{
    public class LevelLoader : ILevelLoader
    {
        public const string UNDERWATER_LEVEL = "UnderwaterLevel";
        private const string MAIN_MENU = "MainMenu";
        private const string GAMEPLAY = "Gameplay";

        private readonly IMusicController _musicController;

        public LevelLoader(IMusicController musicController)
        {
            _musicController = musicController;
        }

        async Task ILevelLoader.LoadLevelAsync()
        {
            _musicController.StopCurrentMusicAsync();
            await LoadSceneAsync(UNDERWATER_LEVEL, LoadSceneMode.Single);
            await LoadSceneAsync(GAMEPLAY, LoadSceneMode.Additive);
            _musicController.PlayLevelMusic(UNDERWATER_LEVEL);
        }

        async Task ILevelLoader.LoadMainMenuAsync()
        {
            _musicController.StopCurrentMusicAsync();
            await LoadSceneAsync(MAIN_MENU);
            _musicController.PlayMainMenuMusic();
        }

        private async Task LoadSceneAsync(string sceneName, LoadSceneMode loadMode)
        {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadMode);
            asyncOperation.allowSceneActivation = false;

            while (asyncOperation is { isDone: false })
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                OnLoadProgress(asyncOperation.progress);
                await Task.Yield();
            }
        }

        private async Task LoadSceneAsync(string sceneName)
        {
            await LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }

        private void OnLoadProgress(float progress)
        {
            Debug.Log($"progress = {progress}");
        }
    }
}
