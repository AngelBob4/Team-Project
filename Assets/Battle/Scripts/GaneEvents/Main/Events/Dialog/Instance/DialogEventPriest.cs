namespace Events.Main.Events.Dialog.Instance
{
    public class DialogEventPriest : DialogEventInstance
    {
        private int _changeHP = 30;
        private int _priceCountTreatment = -35;
        private int _priceCountImproveCard = -70;

        public DialogEventPriest()
        {
            _name = "Священник";
            _text = "Вы встречаете священика";

            AddButton("Получить лечение [+" + _changeHP + " HP, " + _priceCountTreatment + " Coins]", _priceCountTreatment);
            AddButton("Плучить благословление [Улучшить рандомную карту, " + _priceCountTreatment + " Coins]", _priceCountImproveCard);
            AddButton(ExitString);
        }

        protected override void ActionButtonIndex0()
        {
            _dialogEventCommunications.PlayerGlobalData.Coins.ChangeValue(_priceCountTreatment);
            _dialogEventCommunications.PlayerGlobalData.ChangeHP(_changeHP);
        }

        protected override void ActionButtonIndex1()
        {
            _dialogEventCommunications.PlayerGlobalData.Coins.ChangeValue(_priceCountImproveCard);
            _dialogEventCommunications.ImproveCardPanel.ImproveRandomCard();
        }

        protected override void ActionButtonIndex2()
        {
            ActionButtonExit();
        }
    }
}
