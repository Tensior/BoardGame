using UnityEngine;

namespace Core
{
    public class CausticsEffect : MonoBehaviour
    {
        [SerializeField] private float _fps = 30.0f; //footage fps
        [SerializeField] private Texture2D[] _frames; //caustics images

        private int _frameIndex;
        private Projector _projector; //Projector GameObject

        void Start()
        {
            _projector = GetComponent<Projector>();
            NextFrame();
            InvokeRepeating(nameof(NextFrame), 1 / _fps, 1 / _fps);
        }

        void NextFrame()
        {
            _projector.material.SetTexture("_ShadowTex", _frames[_frameIndex]);
            _frameIndex = (_frameIndex + 1) % _frames.Length;
        }

    }
}