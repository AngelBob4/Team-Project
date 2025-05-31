using Events.Cards;
using Events.Main.Events.Dialog.Instance;
using System.Collections.Generic;

namespace Events.Main.Events.Dialog
{
    public class DialogEventDataList
    {
        private DialogEventInstance _currentEventData;
        private Dictionary<int,DialogEventInstance> _allEventDataList;
        private List<DialogEventInstance> _eventDataList = new List<DialogEventInstance>();

        public DialogEventDataList(CardDataList AddCardDataList)
        {
            int index = 1;
            _allEventDataList = new Dictionary<int, DialogEventInstance>
            {
                { index++, new DialogEventMedicinalPlants() },
                { index++, new DialogEventPlacePower() },
                { index++, new DialogEventPriest() },
                { index++, new DialogEventShelter() },
                { index++, new DialogEventShrineCoins() },
                { index++, new DialogEventShrineImproveCard() },
                { index++, new DialogEventTrap() },
                { index++, new DialogEventVision(AddCardDataList) }
            };
        }

        public void InitNewGame()
        {
            _eventDataList.Clear();

            foreach (DialogEventInstance eventData in _allEventDataList.Values)
            {
                _eventDataList.Add(eventData);
            }
        }

        public void LoadDialogEvents(List<int> indexs) 
        {
            _eventDataList.Clear();

            foreach (int index in indexs)
            {
                _eventDataList.Add(_allEventDataList[index]);
            }
        }

        public List<int> GetIndexDialogEvents()
        {
            List<int> indexs = new List<int>();

            foreach (int index in _allEventDataList.Keys)
            {
                if (_eventDataList.Contains(_allEventDataList[index]))
                {
                    indexs.Add(index);
                }
            }

            return indexs;
        }

        public DialogEventInstance GetRandomDialogEventInstance()
        {
            _currentEventData = _eventDataList[UnityEngine.Random.Range(0, _eventDataList.Count)];
            _eventDataList.Remove(_currentEventData);
            return _currentEventData;
        }
    }
}