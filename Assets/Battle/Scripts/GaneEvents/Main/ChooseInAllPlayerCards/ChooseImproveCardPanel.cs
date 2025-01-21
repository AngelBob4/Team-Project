using Events.Cards;
using UnityEngine;

public class ChooseImproveCardPanel : ChooseInAllPlayerCardPanel
{
    [SerializeField] private ImproveCardPanel _improveCardPanel;

    protected override void OnClickCard(Card card)
    {
        _improveCardPanel.gameObject.SetActive(true);
        _improveCardPanel.ImproveCard(card.Data);

        gameObject.SetActive(false);
    }
}
