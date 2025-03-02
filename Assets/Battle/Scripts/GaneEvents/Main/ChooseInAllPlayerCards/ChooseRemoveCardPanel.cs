using Events.Cards;

namespace Events.MainGlobal.ChooseInAllPlayerCards
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