using Runner.SoundSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class SoundControllerView : MonoBehaviour
    {
        [SerializeField] private Slider _backgroundMusicSlider;
        [SerializeField] private Slider _soundEffectsSlider;

        private SoundController _soundController;

        public void Initialize(SoundController soundController)
        {
            _soundController = soundController;
            _backgroundMusicSlider.onValueChanged.AddListener(_soundController.ChangeBackgroundMusicVolume);
            _soundEffectsSlider.onValueChanged.AddListener(_soundController.ChangeSoundEffectsMusicVolume);
        }
    }
}
