using Events.Cards;

namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventVision : DialogEventInstance
    {
        private CardDataList _cardDataList;

        public DialogEventVision(CardDataList cardDataList)
        {
            _cardDataList = cardDataList;

            _name = "�������";
            _text = "�� ������ ���������� ������� �� ��������,\n" +
                "��� �� ����� ��� �������� ����, ������� ����� ������ � �����������";

            AddButton("��������� [+1 �����, -10 HP]");
            AddButton("������");
        }

        protected override void ActionButtonIndex0()
        {
            _dialogEventCommunications.PlayerGlobalData.AddOnlyCard(_cardDataList.GetRandomCardData());
        }

        protected override void ActionButtonIndex1()
        {
            ActionButtonExit();
        }
    }
}
