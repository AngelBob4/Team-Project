using Events.Cards;
using Events.Hand;
using Events.View;
using UnityEngine;

namespace Events.MainGlobal
{
    public class ChooseRemoveCardPanel : ChooseInAllPlayerCardPanel
    {
        protected override void OnClickCard(Card card)
        {
            _playerGlobalData.RemoveCard(card.Data);

            gameObject.SetActive(false);
        }
    }
}
