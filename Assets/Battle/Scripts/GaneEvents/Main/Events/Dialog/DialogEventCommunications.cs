using Events.MainGlobal;
using UnityEngine;

public class DialogEventCommunications : MonoBehaviour
{
    [SerializeField] private PlayerGlobalData _playerGlobalData;
    [SerializeField] private ImproveCardPanel _improveCardPanel;
    [SerializeField] private ChooseImproveCardPanel _chooseImproveCardPanel;

    public PlayerGlobalData PlayerGlobalData => _playerGlobalData;
    public ImproveCardPanel ImproveCardPanel => _improveCardPanel;
    public ChooseImproveCardPanel ChooseImproveCardPanel => _chooseImproveCardPanel;
}
