using Events.Cards;
using UnityEngine;

public class ChooseImproveCardPanel : ChooseInAllPlayerCardPanel
{
    [SerializeField] private ImproveCardPanel _improveCardPanel;

    private const int MaxLevelCard = 2;

    protected override void OnClickCard(Card card)
    {
        _improveCardPanel.gameObject.SetActive(true);
        _improveCardPanel.ImproveCard(card.Data);

        gameObject.SetActive(false);
    }

    public override void Init(int maxLevel = MaxLevelCard)
    {
        base.Init(maxLevel);
    }
}
