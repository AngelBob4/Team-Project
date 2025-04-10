using Runner.ScriptableObjects;
using UnityEngine;

namespace Runner.SoundSystem
{
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public void InitAudioClip(AudioClip audioclip)
        {
            _audioSource.clip = audioclip;
        }

        public void PlayBackgroundMusic()
        {
            _audioSource.Play();
        }
    }
}
