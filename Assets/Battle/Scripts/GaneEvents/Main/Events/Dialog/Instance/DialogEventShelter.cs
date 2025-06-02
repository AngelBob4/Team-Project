namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventShelter : DialogEventInstance
    {
        private int _changeHP = 30;

        public DialogEventShelter()
        {
            _name = "�������";
            _text = "�� �������� ���������� �����";
            _dialogType = DialogTypes.Shelter;

            AddButton("��������� [�������� ��������� �����]");
            AddButton("�������� [+" + _changeHP + " HP]");
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