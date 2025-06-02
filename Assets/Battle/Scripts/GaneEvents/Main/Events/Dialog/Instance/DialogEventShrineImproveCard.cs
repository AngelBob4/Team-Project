namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventShrineImproveCard : DialogEventInstance
    {
        public DialogEventShrineImproveCard()
        {
            _name = "Святыня";
            _text = "Вы встретили придорожную святыню";
            _dialogType = DialogTypes.ShrineCard;

            AddButton("Помолиться [Улучшить рандомную карту]");
            AddButton(ExitString);
        }

        protected override void ActionButtonIndex0()
        {
            _dialogEventCommunications.ImproveCardPanel.ImproveRandomCard();
        }

        protected override void ActionButtonIndex1()
        {
            ActionButtonExit();
        }
    }
}