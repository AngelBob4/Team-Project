using Events.Cards;
using Events.Hand;
using Events.Main.CharactersBattle.Enemies;
using MainGlobal;
using Events.View;
using System;
using UnityEngine;
using UnityEngine.UI;
using Reflex.Attributes;

namespace Events.Main.CharactersBattle
{
    public class PlayerBattle : MonoBehaviour
    {
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private PlayerHand _playerHand;
        [SerializeField] private Image _poisonedView;

        public event Action Died;

        private const int StartQuantityCardsPlayerTakes = 2;
        private const int MaxQuantityCardsPlayerTakes = 5;
        private const int StartPassiveArmor = 0;
        private const int MaxPassiveArmor = 5;
        private const int ChangeStaminaToUpdatedDeck = -1;

        private PlayerGlobalData _playerGlobalData;
        private int _quantityCardsPlayerTakes = 2;
        private int _damageToDepletion = 10;
        private int _quantityCardsPlayerTakesInNewRound;
        private int _passiveArmor = 55;
        private Bar _stamina;
        private bool _isPoisoned = false;
        private CharacterBattleData _characterBattleData;

        public CharacterBattleData CharacterBattleData => _characterBattleData;

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        private void Awake()
        {
            _passiveArmor = StartPassiveArmor;
            _quantityCardsPlayerTakes = StartQuantityCardsPlayerTakes;

            _playerGlobalData.SetPlayerBattle(this);
        }

        private void OnEnable()
        {
            _playerHand.UpdatedDeck += TakeDamageDepletion;

            if(_characterBattleData != null )
            {
                _characterBattleData.Died += Die;
            }
        }
        
        private void OnDisable()
        {
            _playerHand.UpdatedDeck -= TakeDamageDepletion;

            if (_characterBattleData != null)
            {
                _characterBattleData.Died -= Die;
            }
        }

        public void InitNewBattle()
        {
            if (_characterBattleData != null)
            {
                _characterBattleData.Died -= Die;
            }

            _characterBattleData = new CharacterBattleData(_playerGlobalData.HPBar, new ColorBar());

            _characterBattleData.Died += Die;

            _characterView.SetCharacter(_characterBattleData);

            _stamina = _playerGlobalData.Stamina;

            SetPoisoning(false);

            _quantityCardsPlayerTakesInNewRound = _quantityCardsPlayerTakes;
            _playerHand.SetDeck(_playerGlobalData.CardDataList);

            StartRound();
        }

        public void Attack(Enemy enemy)
        {
            if (_isPoisoned)
            {
                _characterBattleData.DefaultTakeDamage(_playerHand.CombinationHand.CardsCount);

                SetPoisoning(false);
            }

            _characterBattleData.ArmorBar.ChangeValue(_playerHand.CombinationHand.GetEffects(CardEffectType.Shield));

            enemy.TakeAttack(_playerHand.CombinationHand.GetEffects(CardEffectType.Wound), _playerHand.CombinationHand.GetCardsType());
            _quantityCardsPlayerTakesInNewRound = _quantityCardsPlayerTakes + _playerHand.CombinationHand.GetEffects(CardEffectType.TakeCards);

            _playerHand.MoveCardsCombinationToDiscard();
        }

        public int TakeAttack(int damage)
        {
            return _characterBattleData.DefaultTakeAttack(damage);
        }

        public void TakeDamageCards(int hand, int deck)
        {
            if(_playerHand.Hand.GetCardsCount() < hand) 
            {
                deck += hand - _playerHand.Hand.GetCardsCount();
                hand = _playerHand.Hand.GetCardsCount();
            }

            _playerHand.MoveCardHendToDiscard(hand); //Скидываем карты с руки

            //Скидываем карты с колоды
        }

        //public void TakeDamageDeckCards(int cards)
        //{
        //    for (int i = 0; i < cards; i++)
        //    {
        //        _playerHand.MoveCardDeckToDiscard();
        //    }
        //}
        //
        //public void TakeDamageHandCards(int cards)
        //{
        //    for (int i = 0; i < cards; i++)
        //    {
        //        //_playerHand.MoveCardHendToDiscard();
        //    }
        //}

        public void ToPoison()
        {
            SetPoisoning(true);
        }

        private void SetPoisoning(bool value)
        {
            _isPoisoned = value;
            _poisonedView.gameObject.SetActive(value);
        }

        public virtual void StartRound()
        {
            _characterBattleData.ArmorBar.SetNewValues(_passiveArmor);
            _playerHand.TakeCardFromDeck(_quantityCardsPlayerTakesInNewRound);
        }

        private void TakeDamageDepletion()
        {
            if (_stamina.CurrentValue > 0)
            {
                _stamina.ChangeValue(ChangeStaminaToUpdatedDeck);
            }
            else
            {
                _characterBattleData.DefaultTakeDamage(_damageToDepletion);
            }
        }

        private void Die()
        {
            Died?.Invoke();
        }
    }
}