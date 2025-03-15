using System;

namespace Events.Main.CharactersBattle
{
    public class CharacterBattleData
    {
        public virtual event Action Died;

        protected Bar _hPBar;
        protected ColorBar _armorBar;

        private int _takeDamage;

        public Bar HPBar => _hPBar;
        public ColorBar ArmorBar => _armorBar;

        public CharacterBattleData(Bar hPBar = null, ColorBar armorBar = null)
        {
            if (hPBar != null) 
            {
                _hPBar = hPBar;
            }

            if (armorBar != null)
            {
                _armorBar = armorBar;
            }
        }

        public int DefaultTakeAttack(int damage)
        {
            _takeDamage = damage;

            if (_armorBar != null && _armorBar.CurrentValue > 0)
            {
                _takeDamage -= _armorBar.CurrentValue;
                _armorBar.ChangeValue(-damage);
            }

            if (_takeDamage > 0)
            {
                DefaultTakeDamage(_takeDamage);
                return _takeDamage;
            }
            else
            {
                return 0;
            }
        }

        public void DefaultTakeDamage(int damage)
        {
            _hPBar.ChangeValue(-damage);
            CheckAlive();
        }

        public void CheckAlive()
        {

            if (_hPBar.CurrentValue <= 0)
            {
                Died?.Invoke();
            }
        }
    }
}