namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventTrap : DialogEventInstance
    {
        private int _changeHP = -15;
        private int _changeMaxHP = -5;

        public DialogEventTrap()
        {
            _name = "�������";
            _text = "�� ��������� � �������";

            AddButton("���� [" + _changeHP + " HP]");
            AddButton("���� [" + _changeMaxHP + " MaxHP]");
        }

        protected override void ActionButtonIndex0()
        {
            _dialogEventCommunications.PlayerGlobalData.ChangeHP(_changeHP);
        }

        protected override void ActionButtonIndex1()
        {
            _dialogEventCommunications.PlayerGlobalData.ChangeMaxHP(_changeMaxHP);
        }
    }
}