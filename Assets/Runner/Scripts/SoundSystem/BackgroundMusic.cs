using Runner.ScriptableObjects;
using Runner.Settings;
using UnityEngine;

namespace Runner.SoundSystem
{
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private LevelController _levelController;

        private void OnEnable()
        {
          //  _levelController.Initializing += InitAudioClip;
        }

        private void OnDisable()
        {
            //_levelController.Initializing -= InitAudioClip;
        }

        public  void InitAudioClip(LocationType settings)
        {
            _audioSource.clip = settings.AudioClip;
            _audioSource.Play();
        }
    }
}