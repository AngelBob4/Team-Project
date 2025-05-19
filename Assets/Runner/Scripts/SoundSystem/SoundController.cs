using MainGlobal;
using Runner.PlayerController;
using Runner.UI;
using UnityEngine;

namespace Runner.SoundSystem
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource _backgroundMusicAudioSource;

        private AudioSource _soundEffectsSource;
        private GlobalGame _globalGame;

        public void Initialize(AudioClip clip, Player player, CanvasUI canvasUI, GlobalGame globalGame)
        {
            _globalGame = globalGame;
            _soundEffectsSource = player.PlayerAudioEffects.AudioSource;
            InitVolume(_soundEffectsSource, _globalGame.SoundEffectsVolume);
            InitVolume(_backgroundMusicAudioSource, _globalGame.BackgroundMusicVolume);
            InitAudioClip(clip);
        }

        private void InitVolume(AudioSource source, float volume)
        {
            source.volume = volume;
        }

        private void InitAudioClip(AudioClip clip)
        {
            _backgroundMusicAudioSource.clip = clip;
            _backgroundMusicAudioSource.Play();
        }
    }
}