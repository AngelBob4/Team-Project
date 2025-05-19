using Runner.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class EducationView : MonoBehaviour
    {
        [SerializeField] private Advices _currentAdvices;
        [SerializeField] private TMP_Text _text;
       
        private void Start()
        {
            ShowAdvice( _currentAdvices);
        }

        private void ShowAdvice( Advices advices)
        {
            _text.text = advices.HowToRunText.ToString();
        }
    }
}