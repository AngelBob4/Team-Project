using Runner.ScriptableObjects;
using Runner.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class EducationView : MonoBehaviour
    {
        [SerializeField] private Advices _currentAdvices;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _continueButton;

        private int _index = 0;

        private void Start()
        {
            ShowAdvice(_index, _currentAdvices);
            _index++;
        }

        public void OnContinueButtonClick()
        {
            ShowAdvice(_index, _currentAdvices);
            _index++;
        }

        private void ShowAdvice(int index, Advices advices)
        {
            if (index < advices.EducationAdvices.Count)
            {
                _text.text = advices.EducationAdvices[index].ToString();
            }
            else
            {
                // _canvasUI.FinishEducation();
                this.gameObject.SetActive(false);
            }
        }
    }
}
