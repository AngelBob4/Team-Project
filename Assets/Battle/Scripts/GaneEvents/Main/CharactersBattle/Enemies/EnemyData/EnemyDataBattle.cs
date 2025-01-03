using System;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public abstract class EnemyDataBattle : ScriptableObject, ICharacter
    {
        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private int _hP;
        [SerializeField] private int _armor;

        [Header("Damage")]
        [SerializeField] protected int _minDamage;
        [SerializeField] protected int _maxDamage;
        [SerializeField] protected int _cardDamage;

        public event Action Died;

        protected int _takeDamage;
        protected Bar _hPBar;
        protected Bar _armorBar;
        protected bool _isDefaultTakeDamage = true;

        public string Name => _name;
        public int Lavel => _level;

        public Bar HP => _hPBar;
        public Bar Armor => _armorBar;
        public bool IsDefaultTakeAttack => _isDefaultTakeDamage;

        public virtual void NewInitValue()
        {
            _hPBar = new Bar(_hP);
            _armorBar = new Bar(_armor);
        }

        public void Attack(ICharacter character)
        {
            Attack((PlayerBattle)character);
        }

        protected virtual void Attack(PlayerBattle player)
        {
            player.TakeAttack(UnityEngine.Random.Range(_minDamage, _maxDamage + 1));
            player.TakeDamageCards(_cardDamage);
        }

        public virtual void TakeAttack(int damage)
        {
            throw new NotImplementedException();
        }

        public virtual void CheckAlive()
        {
            if (_hPBar.CurrentValue <= 0)
            {
                Died?.Invoke();
            }
        }

        public virtual void StartRound()
        {

        }
    }
}
