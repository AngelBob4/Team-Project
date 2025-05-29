using System.Collections.Generic;
using Events.Main.Events;
using MapSection.Models;
using UnityEngine.UIElements;

public struct CellStructure
{
    public List<int> NextAvialableCellIndexes;
    public  EventsType Type;
    public PositionOnMap Position;
    public int Index;

    //public CellStructure(EventsType type)
    //{
    //    Type = type;
    //}
}
