using Events.Cards;

namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventDataAddCard : DialogEventData
    {
        private CardDataList _cardDataList;

        public DialogEventDataAddCard(CardDataList cardDataList)
        {
            _cardDataList = cardDataList;

            _name = "����� ����";
            _text = "�� ����� ����� ����,\n" +
                " ��� ����� ����� ���� ����� ������� ������� ����� ���������";

            _stringButtons.Add("������������");
            _stringButtons.Add(ExitString);
        }

        protected override void ActionButtonIndex0()
        {
            _playerGlobalData.AddOnlyCard(_cardDataList.GetRandomCardData());
        }

        protected override void ActionButtonIndex1()
        {
            ActionButtonExit();
        }
    }
}
