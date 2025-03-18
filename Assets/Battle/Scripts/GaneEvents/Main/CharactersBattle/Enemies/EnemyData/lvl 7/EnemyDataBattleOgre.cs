using Events.Cards;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleOgre : EnemyDataBattle
    {
        private readonly int _passiveArmor = 2;
        private readonly int _attackHitDamage = 4;
        private readonly int _attackHitDamageCard = 2;
        private readonly int _attackHitIgnoringArmor = 2;
        private readonly int _attackStunnedHitDamage = 2;
        private readonly int _attackStunnedHitIgnoringArmor = -1;
        private readonly int _attackStunnedHitDamageCard = 2;
        private readonly int _attackRageHitDamage = 6;
        private readonly int _attackRageHitIgnoringArmor = 4;
        private readonly int _attackRageHitDamageCard = 2;
        private readonly int _attackRoarDamageCard = 3;

        private bool _isRage = false;
        private int _currentTakeDamage;

        public EnemyDataBattleOgre()
        {
            _name = "Îãð";
            _level = 7;
            _hP = 10;
            _armorBar = new ColorBar();

            _attackList = new List<Action>() { AttackHit, AttackStunnedHit, AttackRoar };
            _cardTypeArmorWeaknessList = new List<CardType>() { CardType.Yellow, CardType.Red };
        }

        public override void NewInitValue()
        {
            _isRage = false;

            base.NewInitValue();
        }

        public override void StartRound()
        {
            ArmorBar.SetNewValues(_passiveArmor);

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

        private void AttackHit()
        {
            Debug.Log(_name + " AttackHit");

            if (AttackDamag(_attackHitDamage, _attackHitIgnoringArmor) > 0)
            {
                AttackDamagCards(0, _attackHitDamageCard);
            }
        }

        private void AttackStunnedHit()
        {
            Debug.Log(_name + " AttackStunnedHit");

            AttackDamag(_attackStunnedHitDamage, _attackStunnedHitIgnoringArmor);
            AttackDamagCards(0, _attackStunnedHitDamageCard);
        }

        private void AttackRoar()
        {
            Debug.Log(_name + " AttackRoar");

            AttackDamagCards(0, _attackRoarDamageCard);

            _isRage = true;
            Debug.Log("   _isRage = " + _isRage);
        }

        private void AttackRageHit()
        {
            Debug.Log(_name + " AttackRageHit");

            if (AttackDamag(_attackRageHitDamage, _attackRageHitIgnoringArmor) > 0)
            {
                AttackDamagCards(0, _attackRageHitDamageCard);
            }

            _isRage = false;
            Debug.Log("   _isRage = " + _isRage);
        }
    }
}