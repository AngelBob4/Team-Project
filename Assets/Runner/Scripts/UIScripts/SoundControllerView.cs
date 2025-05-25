using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SoundControllerView : MonoBehaviour
    {
        [SerializeField] private Slider _backgroundMusicSlider;
        [SerializeField] private Slider _soundEffectsSlider;
        [SerializeField] private Button _soundEffectsButton;
        [SerializeField] private AudioSource _backgroundMusicSource;
        [SerializeField] private AudioSource _soundEffectsSource;
        [SerializeField] private MainMenuCanvas _mainCanvas;

        private void Awake()
        {
            _backgroundMusicSlider.onValueChanged.AddListener(ChangeBackgroundMusicVolume);
            _soundEffectsSlider.onValueChanged.AddListener(ChangeSoundEffectsMusicVolume);
            _soundEffectsButton.onClick.AddListener(PlayTestEffect);
            _backgroundMusicSource.Play();
        }

        public void ChangeBackgroundMusicVolume(float value)
        {
            ChangeVolume(_backgroundMusicSource, value);
            _mainCanvas.GlobalGame.SetMusicVolume(value);
        }

        public void ChangeSoundEffectsMusicVolume(float value)
        {
            ChangeVolume(_soundEffectsSource, value);
            _mainCanvas.GlobalGame.SetEffectsVolume(value);
            PlayTestEffect();
        }

        private void ChangeVolume(AudioSource source, float value)
        {
            source.volume = value;
        }

        private void PlayTestEffect()
        {
            if (!_soundEffectsSource.isPlaying)
                _soundEffectsSource.PlayOneShot(_soundEffectsSource.clip);
        }
    }
}