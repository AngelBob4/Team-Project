using Events.Cards;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleSectarian : EnemyDataBattle
    {
        private readonly int _armorCurse = 10;
        private readonly int _attackHPDamage = 1;
        private readonly int _attackHPIgnoringArmor = -1;
        private readonly int _attackCardDamage = 1;

        private int _currentTakeDamage;
        private bool _isCurse = false;

        public EnemyDataBattleSectarian()
        {
            _name = "Сектант";
            _level = 7;
            _hP = 10;
            _armorBar = new ColorBar();

            _attackList = new List<Action>() { AttackHP, AttackCard, AttackToPoison };
        }

        public override void NewInitValue()
        {
            _isCurse = false;

            base.NewInitValue();
        }

        public override void StartRound()
        {
            if (_isCurse)
            {
                base.StartRound();
            }
            else
            {
                _newAttack = Curse;
            }
        }

        public override int TakeAttack(int damage, List<CardType> cardTypesList = null)
        {
            _currentTakeDamage = base.TakeAttack(damage, cardTypesList);

            if (_currentTakeDamage > 0)
            {
                if (_isCurse)
                {
                    _isCurse = false;
                    Debug.Log("   _isCurse = " + _isCurse);

                    _isStunned = true;
                    Debug.Log("   _isStunned = " + _isStunned);
                }
            }

            return _currentTakeDamage;
        }

        public override void Attack(PlayerBattle player, bool isRemoveArmor = true)
        {
            base.Attack(player, false);
        }

        private void Curse()
        {
            Debug.Log(_name + " Curse");

            SetArmorValues(_armorCurse);

            _isCurse = true;
            Debug.Log("   _isCurse = " + _isCurse);
        }

        private void AttackHP()
        {
            Debug.Log(_name + " AttackHP");

            AttackDamag(_attackHPDamage, _attackHPIgnoringArmor);
        }

        private void AttackCard()
        {
            Debug.Log(_name + " AttackCard");

            AttackDamagCards(0, _attackCardDamage);
        }

        private void AttackToPoison()
        {
            Debug.Log(_name + " AttackToPoison");

            PlayerToPoison();
        }
    }
}