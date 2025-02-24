using Events.Cards;

namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventVision : DialogEventInstance
    {
        private CardDataList _cardDataList;

        public DialogEventVision(CardDataList cardDataList)
        {
            _cardDataList = cardDataList;

            _name = "Видение";
            _text = "Вы видете болезненые видения из прошлого,\n" +
                "тем не менее это полезный опыт, который может помочь в приключении";

            AddButton("Наблюдать [+1 карты, -10 HP]");
            AddButton("Забыть");
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
