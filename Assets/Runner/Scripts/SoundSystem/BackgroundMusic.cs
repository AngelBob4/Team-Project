using UnityEngine;

namespace Runner.SoundSystem
{
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public void StartMusic(AudioClip clip)
        {
            InitAudioClip(clip);
            Play();
        }

        public void InitAudioClip(AudioClip audioclip)
        {
            _audioSource.clip = audioclip;
        }

        public void Play()
        {
            _audioSource.Play();
        }
    }
}