namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventShelter : DialogEventInstance
    {
        private int _changeHP = 30;

        public DialogEventShelter()
        {
            _name = "Убежище";
            _text = "Вы находите безопасное место";
            _dialogType = DialogTypes.Shelter;

            AddButton("Осмотреть [Улучшить рандомную карту]");
            AddButton("Отдыхать [+" + _changeHP + " HP]");
            AddButton(ExitString);
        }

        protected override void ActionButtonIndex0()
        {
            _dialogEventCommunications.ImproveCardPanel.ImproveRandomCard();
        }

        protected override void ActionButtonIndex1()
        {
            _dialogEventCommunications.PlayerGlobalData.ChangeHP(_changeHP);
        }

        protected override void ActionButtonIndex2()
        {
            ActionButtonExit();
        }
    }
}