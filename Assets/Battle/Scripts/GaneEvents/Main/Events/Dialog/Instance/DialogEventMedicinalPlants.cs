using Events.Cards;

namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventMedicinalPlants : DialogEventInstance
    {
        private int _addHP = 30;
        private int _addMaxHP = 10;
        private int _addCoins = 50;

        public DialogEventMedicinalPlants()
        {
            _name = "�������� ��������";
            _text = "�� ����� ������ �� ������� ������ �������� �����";

            AddButton("������� �������� ����� [������������ HP " + _addHP +"]");
            AddButton("������� ����� ����� [��������� ���HP " + _addMaxHP + "]");
            AddButton("������� �������� [�������� " + _addCoins + " �����]");
        }

        protected override void ActionButtonIndex0()
        {
            _dialogEventCommunications.PlayerGlobalData.ChangeHP(_addHP);
        }

        protected override void ActionButtonIndex1()
        {
            _dialogEventCommunications.PlayerGlobalData.ChangeMaxHP(_addMaxHP);
        }

        protected override void ActionButtonIndex2()
        {
            _dialogEventCommunications.PlayerGlobalData.ChangeCoins(_addCoins);
        }
    }
}
