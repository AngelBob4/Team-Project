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
            _name = "Лечебные растения";
            _text = "Вы нашли поляну на которой растут лечебные травы";

            AddButton("Сделать лечебное зелье [Восстановить HP " + _addHP +"]");
            AddButton("Сделать зелье жизни [Увеличить МасHP " + _addMaxHP + "]");
            AddButton("Собрать прозапас [Получить " + _addCoins + " монет]");
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
