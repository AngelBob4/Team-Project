using Events.MainGlobal;
using System;
using System.Collections.Generic;

namespace Events.Main.Events.Dialog
{
    public abstract class DialogEventData
    {
        protected const string ExitString = "”йти";

        protected string _name;
        protected string _text;

        public string Name => _name;
        public string Text => _text;

        protected PlayerGlobalData _playerGlobalData;

        protected List<string> _stringButtons = new List<string>();

        public List<string> StringButtons => _stringButtons;

        public void OnClickButton(int button, PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;

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
    }
}
