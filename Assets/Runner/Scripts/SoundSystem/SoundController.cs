using UnityEngine;

namespace Runner.SoundSystem
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private BackgroundMusic _backgroundMusic;

        public void Initialize(AudioClip clip)
        {
            _backgroundMusic.InitAudioClip(clip);
        }
    }
}
