using Events.Cards;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleRobber : EnemyDataBattle
    {
        private readonly int _attackFeintDamage = 1;
        private readonly int _attackFeintDamageCard = 3;
        private readonly int _attackFeintAddArmor = 2;
        private readonly int _attackAttackHitDamage = 3;
        private readonly int _attackAttackHitIgnoringArmor = 1;
        private readonly int _attackStrongBlowDamage = 5;
        private readonly int _attackStrongBlowDamageCard = 2;
        private readonly int _attackStrongBlowIgnoringArmor = 2;
        private readonly int _passiveArmor = 1;

        private bool _isFeint = false;
        private int _currentTakeDamage;

        public EnemyDataBattleRobber()
        {
            _name = "Разбойник";
            _level = 4;
            _hP = 8;
            _armorBar = new ColorBar();

            _attackList = new List<Action>() { AttackHit, AttackHit, AttackFeint };
            _cardTypeArmorWeaknessList = new List<CardType>() { CardType.Yellow, CardType.Green };
        }

        public override void NewInitValue()
        {
            _isFeint = false;

            base.NewInitValue();
        }

        public override int TakeAttack(int damage, List<CardType> cardTypesList = null)
        {
            _currentTakeDamage = base.TakeAttack(damage, cardTypesList);

            if (_currentTakeDamage > 0)
            {
                if(_isFeint)
                {
                    _isFeint = false;
                    Debug.Log("   _isFeint = " + _isFeint);

                    _isStunned = true;
                    Debug.Log("   _isStunned = " + _isStunned);
                }
            }

            return _currentTakeDamage;
        }

        public override void StartRound()
        {
            ArmorBar.SetNewValues(_passiveArmor);

            if (_isFeint)
            {
                _newAttack = AttackStrongBlow;
            }
            else
            {
                base.StartRound();
            }
        }

        private void AttackHit()
        {
            Debug.Log(_name + " AttackHit");

            AttackDamag(_attackAttackHitDamage, _attackAttackHitIgnoringArmor);
        }

        private void AttackFeint()
        {
            Debug.Log(_name + " AttackFeint");

            AttackDamag(_attackFeintDamage);
            
            AttackDamagCards(0, _attackFeintDamageCard);

            SetArmorAndWeakness(_attackFeintAddArmor);

            _isFeint = true;
            Debug.Log("   _isFeint = " + _isFeint);
        }

        private void AttackStrongBlow()
        {
            Debug.Log(_name + " AttackStrongBlow");

            AttackDamag(_attackStrongBlowDamage, _attackStrongBlowIgnoringArmor);

            AttackDamagCards(0, _attackStrongBlowDamageCard);

            _isFeint = false;
            Debug.Log("   _isFeint = " + _isFeint);
        }
    }
}
