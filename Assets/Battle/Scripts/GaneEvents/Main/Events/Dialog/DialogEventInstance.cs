using Events.MainGlobal;
using System;
using System.Collections.Generic;

namespace Events.Main.Events.Dialog
{
    public abstract class DialogEventInstance
    {
        protected const string ExitString = "”йти";

        protected string _name;
        protected string _text;

        public string Name => _name;
        public string Text => _text;

        protected DialogEventCommunications _dialogEventCommunications;

        protected List<DialogEventButtonData> _dialogEventButtonDataList = new List<DialogEventButtonData>();

        public List<DialogEventButtonData> DialogEventButtonDataList => _dialogEventButtonDataList;

        public void OnClickButton(int button, DialogEventCommunications dialogEventCommunications)
        {
            _dialogEventCommunications = dialogEventCommunications;

            switch (button)
            {
                case 0:
                    ActionButtonIndex0();
                    break;

                case 1:
                    ActionButtonIndex1();
                    break;

                case 2:
                    ActionButtonIndex2();
                    break;

                case 3:
                    ActionButtonIndex3();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected virtual void ActionButtonIndex0()
        {
            throw new NotImplementedException();
        }

        protected virtual void ActionButtonIndex1()
        {
            throw new NotImplementedException();
        }

        protected virtual void ActionButtonIndex2()
        {
            throw new NotImplementedException();
        }

        protected virtual void ActionButtonIndex3()
        {
            throw new NotImplementedException();
        }

        protected void ActionButtonExit()
        {

        }

        protected void AddButton(string @string, int priceCount = 0)
        {
            _dialogEventButtonDataList.Add(new DialogEventButtonData(@string, priceCount));
        }
    }
}
