using Events.Cards;
using Events.Hand;
using Events.MainGlobal;
using Events.View;
using System;
using UnityEngine;

namespace Events.Main.CharactersBattle
{
    public class PlayerBattle : CharacterBattle
    {
        [SerializeField] private PlayerGlobalData _playerGlobalData;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private BarView _staminaBarView;
        [SerializeField] private PlayerHand _playerHand;

        public override event Action Died;

        private const int StartQuantityCardsPlayerTakes = 2;
        private const int MaxQuantityCardsPlayerTakes = 5;
        private const int StartPassiveArmor = 0;
        private const int MaxPassiveArmor = 5;
        private const int ChangeStaminaToUpdatedDeck = -1;

        private int _quantityCardsPlayerTakes = 2;
        private int _damageToDepletion = 10;
        private int _quantityCardsPlayerTakesInNewRound;
        private int _passiveArmor = 55;
        private Bar _stamina;

        private void OnEnable()
        {
            _playerHand.UpdatedDeck += TakeDamageDepletion;
            _playerGlobalData.Died += Died;
        }

        private void OnDisable()
        {
            _playerHand.UpdatedDeck -= TakeDamageDepletion;
            _playerGlobalData.Died -= Died;
        }

        public void InitNewPlayer()
        {
            _hPBar = _playerGlobalData.HPBar;
            _armorBar = new Bar();
            _characterView.SetCharacter(this);

            _stamina = _playerGlobalData.Stamina;
            _staminaBarView.SetBar(_stamina);

            _passiveArmor = StartPassiveArmor;
            _quantityCardsPlayerTakes = StartQuantityCardsPlayerTakes;
        }

        public void InitNewBattle()
        {
            _quantityCardsPlayerTakesInNewRound = _quantityCardsPlayerTakes;
            _playerHand.SetDeck(_playerGlobalData.CardDataList);

            StartRound();
        }

        public override void Attack(ICharacter character)
        {
            _armorBar.ChangeValue(_playerHand.CombinationHand.GetEffects(CardEffectType.Shield));

            character.TakeAttack(_playerHand.CombinationHand.GetEffects(CardEffectType.Wound));
            _quantityCardsPlayerTakesInNewRound = _quantityCardsPlayerTakes + _playerHand.CombinationHand.GetEffects(CardEffectType.TakeCards);

            _playerHand.MoveCardsCombinationToDiscard();
        }

        public override void TakeAttack(int damage)
        {
            DefaultTakeAttack(damage);
        }

        public void TakeDamageCards(int cards)
        {
            for (int i = 0; i < cards; i++)
            {
                _playerHand.MoveCardToDiscard();
            }
        }

        public override void StartRound()
        {
            _armorBar.SetNewValues(_passiveArmor);
            _playerHand.TakeCardFromDeck(_quantityCardsPlayerTakesInNewRound);
        }

        protected override void DefaultTakeDamage(int damage)
        {
            _playerGlobalData.ChangeHP(-damage);
        }

        private void TakeDamageDepletion()
        {
            if (_stamina.CurrentValue > 0)
            {
                _stamina.ChangeValue(ChangeStaminaToUpdatedDeck);
            }
            else
            {
                DefaultTakeDamage(_damageToDepletion);
            }
        }
    }
}
