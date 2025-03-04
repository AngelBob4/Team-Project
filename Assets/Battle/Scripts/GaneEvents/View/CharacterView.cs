using Events.Main.CharactersBattle;
using UnityEngine;

namespace Events.View
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private BarView _hPBar;
        [SerializeField] private BarView _armorBar;

        public void SetCharacter(CharacterBattleData character)
        {
            if (_hPBar != null)
                _hPBar.SetBar(character.HPBar);

            if (_armorBar != null)
                _armorBar.SetBar(character.ArmorBar);
        }
    }
}