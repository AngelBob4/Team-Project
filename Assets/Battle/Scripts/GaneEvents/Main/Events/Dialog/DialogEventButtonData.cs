namespace Events.Main.Events.Dialog
{
    public class DialogEventButtonData
    {
        private string _string;
        private int _priceCount;

        public string String => _string;
        public int PriceCount => _priceCount;

        public DialogEventButtonData(string @string, int priceCount = 0)
        {
            _string = @string;
            _priceCount = priceCount;
        }
    }
}