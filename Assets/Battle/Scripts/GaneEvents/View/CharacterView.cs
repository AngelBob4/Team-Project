using Events.Main.CharactersBattle;
using UnityEngine;
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
            if (_hPBar != null)
                _hPBar.SetBar(character.HPBar);

            if (_armorBar != null)
                _armorBar.SetBar(character.ArmorBar);
        }
    }
}