using Events.Cards;

namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventDataAddCard : DialogEventData
    {
        private CardDataList _cardDataList;

        public DialogEventDataAddCard(CardDataList cardDataList)
        {
            _cardDataList = cardDataList;

            _name = "Место силы";
            _text = "Вы нашли место силы,\n" +
                " кто знает какую силу можно обрести проведя сдесь медитацию";

            _stringButtons.Add("Медитировать");
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
