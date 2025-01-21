namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventPlacePower : DialogEventInstance
    {
        private int _priceCount = -30;

        public DialogEventPlacePower()
        {
            _name = "����� ����";
            _text = "�� �������� ����� ����";

            AddButton("������������ [�������� ��������� �����]");
            AddButton("�������� ������ [�������� ����� �� �����, " + _priceCount + " Coins]", _priceCount);
            AddButton(ExitString);
        }

        protected override void ActionButtonIndex0()
        {
            _dialogEventCommunications.ImproveCardPanel.ImproveRandomCard();
        }

        protected override void ActionButtonIndex1()
        {
            _dialogEventCommunications.PlayerGlobalData.Coins.ChangeValue(_priceCount);
            _dialogEventCommunications.ChooseImproveCardPanel.Init();
        }

        protected override void ActionButtonIndex2()
        {
            ActionButtonExit();
        }
    }
}
