using Runner.ScriptableObjects;
using UnityEngine;

namespace Runner.SoundSystem
{
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public void InitAudioClip(AllRunnerSettings allRunnerSettings)
        {
            _audioSource.clip = allRunnerSettings.AudioClip;
            _audioSource.Play();
        }
    }
}
