using Events.Cards;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleVampire : EnemyDataBattle
    {
        private readonly int _passiveArmor = 1;
        private readonly int _attackBatsDamage = 2;
        private readonly int _attackBatsIgnoringArmor = 1; 
        private readonly int _attackClawDamage = 2;
        private readonly int _attackClawIgnoringArmor = 2;
        private readonly int _attackClawDamageDeckCard = 1;
        private readonly int _attackBiteDamage = 5;
        private readonly int _attackBiteModifierRegenerationHP = 2;

        private int _currentDamage;

        public EnemyDataBattleVampire()
        {
            _name = "Вампир";
            _level = 10;
            _hP = 12;
            _armorBar = new ColorBar();

            _attackList = new List<Action>() { AttackBats, AttackBats, AttackClaw, AttackBite };
        }

        public override void StartRound()
        {
            ArmorBar.ChangeValue(_passiveArmor);
            base.StartRound();
        }

        private void AttackBats()
        {
            Debug.Log(_name + " AttackBats");

            _currentDamage = AttackDamag(_attackBatsDamage, _attackBatsIgnoringArmor);

            if (_currentDamage > 0)
            {
                RegenerationHP(_currentDamage);
            }
        }

        private void AttackClaw()
        {
            Debug.Log(_name + " AttackClaw");

            _currentDamage = AttackDamag(_attackClawDamage, _attackClawIgnoringArmor);

            if (_currentDamage > 0)
            {
                PlayerToPoison();
                AttackDamagCards(0, _attackClawDamageDeckCard);
            }
        }

        private void AttackBite()
        {
            Debug.Log(_name + " AttackBite");

            _currentDamage = AttackDamag(_attackBiteDamage);

            if (_currentDamage > 0)
            {
                RegenerationHP(_currentDamage * _attackBiteModifierRegenerationHP);
            }
        }
    }
}