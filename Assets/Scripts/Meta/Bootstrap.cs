// UserUserBoardGame

using System;
using UnityEngine;
using Zenject;

namespace Meta
{
    public class Bootstrap : MonoBehaviour
    {
        private ILevelLoader _levelLoader;

        [Inject]
        private void Inject(ILevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }
        private void Start()
        {
            _levelLoader.LoadMainMenuAsync();
        }
    }
}