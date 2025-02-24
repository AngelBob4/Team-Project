using Events.Cards;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleWerewolf : EnemyDataBattle
    {
        private readonly int _passiveArmor = 1;
        private readonly int _attackClawDamage = 5;
        private readonly int _attackClawDamageDeckCard = 2;
        private readonly int _attackClawIgnoringArmor = 3;
        private readonly int _attackHowlDamageDeckCard = 1;
        private readonly int _attackHowlDamageHandCard = 2;
        private readonly int _attackHowlAddArmor = 1;
        private readonly int _attackRageHitDamage = 6;
        private readonly int _attackRageHitIgnoringArmor = -1;
        private readonly int _attackRageHitDamageDeckCard = 2;
        private readonly int _attackRageHitRegenerationHP = 2;

        private bool _isRage = false;
        private int _currentTakeDamage;

        public EnemyDataBattleWerewolf()
        {
            _name = "Оборотень";
            _level = 10;
            _hP = 15;
            _armorBar = new ColorBar();

            _attackList = new List<Action>() { AttackClaw, AttackClaw, AttackHowl };
            _cardTypeArmorWeaknessList = new List<CardType>() { CardType.Purple, CardType.Red };
        }

        public override void NewInitValue()
        {
            _isRage = false;

            base.NewInitValue();
        }

        public override void StartRound()
        {
            ArmorBar.ChangeValue(_passiveArmor);

            if (_isRage)
            {
                _newAttack = AttackRageHit;
            }
            else
            {
                base.StartRound();
            }
        }

        public override int TakeAttack(int damage, List<CardType> cardTypesList = null)
        {
            _currentTakeDamage = base.TakeAttack(damage, cardTypesList);

            if (_currentTakeDamage > 0)
            {
                if (_isRage)
                {
                    _isRage = false;
                    Debug.Log("   _isRage = " + _isRage);
                    _newAttack = _attackList[UnityEngine.Random.Range(0, _attackList.Count)];
                }
            }

            return _currentTakeDamage;
        }

        private void AttackClaw()
        {
            Debug.Log(_name + " AttackClaw");

            if (AttackDamag(_attackClawDamage, _attackClawIgnoringArmor) > 0)
            {
                AttackDamagDeckCards(_attackClawDamageDeckCard);
            }
        }

        private void AttackHowl()
        {
            Debug.Log(_name + " AttackStunnedHit");

            AttackDamagDeckCards(_attackHowlDamageDeckCard);
            AttackDamagHandCards(_attackHowlDamageHandCard);
            SetArmorValues(_attackHowlAddArmor);

            _isRage = true;
        }

        private void AttackRageHit()
        {
            Debug.Log(_name + " AttackRageHit");

            if (AttackDamag(_attackRageHitDamage, _attackRageHitIgnoringArmor) > 0)
            {
                AttackDamagDeckCards(_attackRageHitDamageDeckCard);
                RegenerationHP(_attackRageHitRegenerationHP);
                PlayerToPoison();
            }
        }
    }
}
