using Events.Cards;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public abstract class EnemyDataBattle: CharacterBattleData
    {
        protected string _name;
        protected int _level;
        protected int _hP;
        protected List<Action> _attackList;
        protected Action _newAttack;
        protected PlayerBattle _player;
        protected List<CardType> _cardTypeArmorWeaknessList;
        protected CardType _cardTypeArmorWeakness;
        protected bool _isStunned = false;

        public string Name => _name;
        public int Lavel => _level;

        public virtual void NewInitValue()
        {
            _hPBar = new Bar(_hP);
            _isStunned = false;

            if (_armorBar != null)
            {
                _armorBar.SetValueDefault();
            }
        }

        public virtual void Attack(PlayerBattle player, bool isRemoveArmor = true)
        {
            _player = player;

            if (isRemoveArmor && _armorBar != null)
            {
                _armorBar.SetValueDefault();
            }

            if (_newAttack == null)
                throw new System.ArgumentNullException();

            Debug.Log("--------------------START-ATTACK--------------------");
            
            if (_isStunned)
            {
                _isStunned = false;
                Debug.Log("   _isStunned = " + _isStunned);

            }
            else
            {
                _newAttack();
            }

            Debug.Log("---------------------END-ATTACK---------------------");
        }

        public virtual int TakeAttack(int damage, List<CardType> cardTypesList = null)
        {
            if (_armorBar != null && _cardTypeArmorWeakness == CardType.Null && cardTypesList != null)
            {
                foreach (CardType cardType in cardTypesList)
                {
                    if (cardType == _cardTypeArmorWeakness)
                    {
                        RemoveArmor();
                    }
                }
            }

            return DefaultTakeAttack(damage);
        }

        public virtual void StartRound()
        {
            if (_attackList == null || _attackList.Count == 0)
            {
                throw new System.NotImplementedException();
            }

            _newAttack = _attackList[UnityEngine.Random.Range(0, _attackList.Count)];
        }

        protected int AttackDamag(int damage, int ignoringArmor = 0)
        {
            if (ignoringArmor == 0)
            {
                Debug.Log("   Damage " + damage);
                return _player.TakeAttack(damage);
            }
            else
            {
                if (ignoringArmor > 0)
                {
                    Debug.Log("   Damage " + damage + " (IgnoringArmor " + ignoringArmor + ")");
                    _player.CharacterBattleData.ArmorBar.ChangeValue(-ignoringArmor);
                }
                else 
                {
                    Debug.Log("   Damage " + damage + " (AllIgnoringArmor)");
                    _player.CharacterBattleData.ArmorBar.SetValueDefault();
                }
                
                return _player.TakeAttack(damage);
            }
        }

        protected void AttackDamagDeckCards(int damageCard)
        {
            _player.TakeDamageDeckCards(damageCard);
            Debug.Log("   DamageDeckCard " + damageCard);
        }

        protected void AttackDamagHandCards(int damageCard)
        {
            _player.TakeDamageHandCards(damageCard);
            Debug.Log("   DamageHandCard " + damageCard);
        }

        protected void AddArmorValues(int addArmor)
        {
            _armorBar.ChangeValue(addArmor);
            Debug.Log("   AddArmor = " + addArmor);
        }
        
        protected void SetArmorValues(int armor, CardType cardTypeArmorWeakness = CardType.Null)
        {
            if (cardTypeArmorWeakness == CardType.Null)
            {
                _armorBar.SetNewValues(armor);
                Debug.Log("   Armor = " + armor);
            }
            else
            {
                _armorBar.SetNewValues(armor, cardTypeArmorWeakness);
                Debug.Log("   Armor " + armor + " Collor " + cardTypeArmorWeakness);
            }
        }

        protected void SetArmorAndWeakness(int armor)
        {
            _cardTypeArmorWeakness = GetRandomCardTypeWeakness();
            SetArmorValues(armor, _cardTypeArmorWeakness);

            CardType GetRandomCardTypeWeakness()
            {
                return _cardTypeArmorWeaknessList[UnityEngine.Random.Range(0, _cardTypeArmorWeaknessList.Count)];
            }
        }

        protected void RemoveArmor()
        {
            _cardTypeArmorWeakness = CardType.Null;
            _armorBar.SetValueDefault();
        }

        protected void PlayerToPoison()
        {
            _player.ToPoison();
            Debug.Log("   Отравление");
        }

        protected void RegenerationHP(int hp, bool isValidationCheck = true)
        {
            _hPBar.ChangeValue(hp, isValidationCheck);
            Debug.Log("   Regeneration " + hp);
        }
    }
}