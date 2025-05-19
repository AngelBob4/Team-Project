using System.Collections;
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

        private Coroutine _coroutine;

        private void Awake()
        {
            _backgroundMusicSlider.onValueChanged.AddListener(ChangeBackgroundMusicVolume);
            _soundEffectsSlider.onValueChanged.AddListener(ChangeSoundEffectsMusicVolume);
            _soundEffectsButton.onClick.AddListener(PlaySoundEffect);
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
        }

        private void SetButtonActive()
        {
            _coroutine = StartCoroutine(InteractableRoutine());
        }

        private IEnumerator InteractableRoutine()
        {
            float pause = 5.0f;
            _soundEffectsButton.interactable = false;
            yield return new WaitForSeconds(pause);
            _soundEffectsButton.interactable = true;
        }

        private void PlaySoundEffect()
        {
            _soundEffectsSource.PlayOneShot(_soundEffectsSource.clip);
            SetButtonActive();
        }

        private void ChangeVolume(AudioSource source, float value)
        {
            source.volume = value;
        }
    }
}