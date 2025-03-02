using MainGlobal;
using Reflex.Attributes;
using UnityEngine;
using Events.Main.LevelingUpPlayer;
using Events.MainGlobal.ChooseInAllPlayerCards;

namespace Events.Main.Events.Dialog
{
    public class DialogEventCommunications : MonoBehaviour
    {
        [SerializeField] private ImproveCardPanel _improveCardPanel;
        [SerializeField] private ChooseImproveCardPanel _chooseImproveCardPanel;

        private PlayerGlobalData _playerGlobalData;

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        public PlayerGlobalData PlayerGlobalData => _playerGlobalData;
        public ImproveCardPanel ImproveCardPanel => _improveCardPanel;
        public ChooseImproveCardPanel ChooseImproveCardPanel => _chooseImproveCardPanel;
    }
}
