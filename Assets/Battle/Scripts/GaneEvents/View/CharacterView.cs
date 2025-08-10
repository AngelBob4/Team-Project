using Events.Main.CharactersBattle;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

namespace Events.View
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private BarView _hPBar;
        [SerializeField] private BarView _armorBar;
        [SerializeField] private Image _image;

        public void SetCharacter(CharacterBattleData character)
        {
            SetBars(character.HPBar, character.ArmorBar);
        }

        public void SetBars(Bar hP, Bar armor)
        {
            if (_hPBar != null)
                _hPBar.SetBar(hP);

            if (_armorBar != null)
                _armorBar.SetBar(armor);
        }
    }
}