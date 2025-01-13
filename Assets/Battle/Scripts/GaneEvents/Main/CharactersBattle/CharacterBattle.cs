using System;
using UnityEngine;

namespace Events.Main.CharactersBattle
{
    public abstract class CharacterBattle : MonoBehaviour, ICharacter
    {
        public abstract event Action Died;

        protected Bar _hPBar;
        protected Bar _armorBar;

        private int _takeDamage;

        public Bar HPBar => _hPBar;
        public Bar ArmorBar => _armorBar;

        public abstract void StartRound();

        public abstract void Attack(ICharacter character);

        public abstract void TakeAttack(int damage);

        protected void DefaultTakeAttack(int damage)
        {
            _takeDamage = damage;

            _takeDamage -= _armorBar.CurrentValue;
            _armorBar.ChangeValue(-damage);

            if (_takeDamage > 0)
            {
                DefaultTakeDamage(_takeDamage);
            }
        }

        protected abstract void DefaultTakeDamage(int damage);
    }
}
