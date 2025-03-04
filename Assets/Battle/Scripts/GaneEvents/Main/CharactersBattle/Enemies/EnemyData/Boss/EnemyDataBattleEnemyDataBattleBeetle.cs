using Events.Cards;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleBeetle: EnemyDataBattle
    {
        private readonly int _passiveArmor = 2;
        private readonly int _attackWebDamage = 1;
        private readonly int _attackWebIgnoringArmor = 3; 
        private readonly int _attackWebDamageHandCard = 3;

        private readonly int _attackAcidDamage = 4;
        private readonly int _attackAcidIgnoringArmor = 2;
        private readonly int _attackAcidDamageCard = 1;

        private readonly int _attackBiteDamage = 6;
        private readonly int _attackBiteDamageDeckCard = 3;

        private int _currentDamage;
        private CardType _cardTypeAttackAcidWeakness = CardType.Yellow;
        private CardType _cardTypeWedWeakness = CardType.Yellow;
        private List<CardType> _currentCardTypeTakeDamageList = new List<CardType>();
        private bool _isWeb = false;

        public EnemyDataBattleBeetle()
        {
            _name = "Жук (Кащей)";
            _level = 10;
            _hP = 16;
            _armorBar = new ColorBar();

            _attackList = new List<Action>() { AttackWeb, AttackAcid };
            _cardTypeArmorWeaknessList = new List<CardType>() { CardType.Yellow, CardType.Red };
        }

        public override void NewInitValue()
        {
            _isWeb = false;
            _currentCardTypeTakeDamageList.Clear();

            base.NewInitValue();
        }

        public override int TakeAttack(int damage, List<CardType> cardTypesList = null)
        {
            _currentCardTypeTakeDamageList.Clear();

            foreach (CardType cardType in cardTypesList)
            {
                _currentCardTypeTakeDamageList.Add(cardType);
            }

            if(_isWeb && _currentCardTypeTakeDamageList.Contains(_cardTypeWedWeakness))
            {
                _isWeb = false;
                Debug.Log("   _isWeb = " + _isWeb);
                GenerateNewAttack();
            }

            return base.TakeAttack(damage, cardTypesList);
        }

        public override void StartRound()
        {
            ArmorBar.ChangeValue(_passiveArmor);

            if (_isWeb)
            {
                _newAttack = AttackBite;
            }
            else
            {
                base.StartRound();
            }
        }

        private void AttackWeb()
        {
            Debug.Log(_name + " AttackWeb");

            _currentDamage = AttackDamag(_attackWebDamage, _attackWebIgnoringArmor);

            if (_currentDamage > 0)
            {
                AttackDamagHandCards(_attackWebDamageHandCard);

                _isWeb = true;
                Debug.Log("   _isWeb = " + _isWeb);
            }
        }

        private void AttackAcid()
        {
            Debug.Log(_name + " AttackAcid");

            if (_currentCardTypeTakeDamageList.Contains(_cardTypeAttackAcidWeakness))
            {
                _currentDamage = AttackDamag(_attackAcidDamage, _attackAcidIgnoringArmor);
            }
            else
            {
                _currentDamage = AttackDamag(_attackAcidDamage, _ignoringAllArmor);
            }

            if (_currentDamage > 0)
            {
                PlayerToPoison();
                AttackDamagDeckCards(_attackAcidDamageCard);
                AttackDamagHandCards(_attackAcidDamageCard);
            }
        }

        private void AttackBite()
        {
            Debug.Log(_name + " AttackBite");

            if (AttackDamag(_attackBiteDamage, _ignoringAllArmor) > 0)
            {
                PlayerToPoison();
                AttackDamagDeckCards(_attackBiteDamageDeckCard);
            }
        }
    }
}