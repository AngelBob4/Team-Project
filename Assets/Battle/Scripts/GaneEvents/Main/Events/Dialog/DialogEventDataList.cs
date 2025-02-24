using Events.Cards;
using Events.Main.Events.Dialog;
using Events.Main.Events.Dialog.Instance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEventDataList
{
    private DialogEventInstance _currentEventData;
    private List<DialogEventInstance> _allEventDataList;
    private List<DialogEventInstance> _eventDataList = new List<DialogEventInstance>();

    //public IReadOnlyList<DialogEventInstance> EventDataList => _eventDataList;

    public DialogEventDataList(CardDataList AddCardDataList)
    {
        _allEventDataList = new List<DialogEventInstance>
            {
                new DialogEventMedicinalPlants(),
                new DialogEventPlacePower(),
                new DialogEventPriest(),
                new DialogEventShelter(),
                new DialogEventShrineCoins(),
                new DialogEventShrineImproveCard(),
                new DialogEventTrap(),
                new DialogEventVision(AddCardDataList)
            };
    }

    public void InitNewGame()
    {
        _eventDataList.Clear();

        foreach (DialogEventInstance instance in _allEventDataList)
        {
            _eventDataList.Add(instance);
        }
    }

    public DialogEventInstance GetRandomDialogEventInstance()
    {
        _currentEventData = _eventDataList[UnityEngine.Random.Range(0, _eventDataList.Count)];
        _eventDataList.Remove(_currentEventData); 
        return _currentEventData;
    }
}
