using Runner.PlayerController;
using Runner.UI;
using UnityEngine;

namespace Runner.SoundSystem
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource _backgroundMusicAudioSource;

        private AudioSource _soundEffectsSource;

        //установить дефолтное значение и передавать из главного скрипта сохраненные значения, также после изменения сохранять значение
        public void Initialize(AudioClip clip, Player player, CanvasUI canvasUI)
        {
            _soundEffectsSource = player.PlayerAudioEffects.AudioSource;
            InitAudioClip(clip);
        }

        private void InitAudioClip(AudioClip clip)
        {
            _backgroundMusicAudioSource.clip = clip;
            _backgroundMusicAudioSource.Play();
        }

        public void ChangeBackgroundMusicVolume(float value)
        {
            ChangeVolume(_backgroundMusicAudioSource, value);
            // _saver.Save();
        }

        public void ChangeSoundEffectsMusicVolume(float value)
        {
            ChangeVolume(_soundEffectsSource, value);
           // _saver.Save();
        }

        private void ChangeVolume(AudioSource source, float value)
        {
            source.volume = value;
        }
    }
}
