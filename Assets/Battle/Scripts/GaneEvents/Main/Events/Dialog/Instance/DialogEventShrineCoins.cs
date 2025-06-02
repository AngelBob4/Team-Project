namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventShrineCoins : DialogEventInstance
    {
        private int _addCoins = 100;

        public DialogEventShrineCoins()
        {
            _name = "�������";
            _text = "�� ��������� ����������� �������";
            _dialogType = DialogTypes.ShrineCoins;

            AddButton("���������� [+100 �����]");
            AddButton(ExitString);
        }

        protected override void ActionButtonIndex0()
        {
            _dialogEventCommunications.PlayerGlobalData.ChangeCoins(_addCoins);
        }

        protected override void ActionButtonIndex1()
        {
            ActionButtonExit();
        }
    }
}