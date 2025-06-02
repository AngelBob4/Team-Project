namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventShrineImproveCard : DialogEventInstance
    {
        public DialogEventShrineImproveCard()
        {
            _name = "�������";
            _text = "�� ��������� ����������� �������";
            _dialogType = DialogTypes.ShrineCard;

            AddButton("���������� [�������� ��������� �����]");
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