using Events.Main.Events;
using MapSection.Models;
using System.Collections.Generic;
using UnityEngine;

public struct MapCellData 
{
    public List<int> NextAvailableCellsIndexes;

    public EventsType Type;
    public int Index;

    public bool IsAvailable;
    public bool IsActivated;
    
    public int X;
    public int Y;

    //public void SetValye(int i)
    //{
    //    Index = i;
    //}

    public MapCellData(MapCell mapCell)
    {
        Type = mapCell.Type;
        X = mapCell.Position.X;
        Y = mapCell.Position.Y;
        Index = mapCell.Index;
    
        NextAvailableCellsIndexes = new List<int>();
    
        foreach (int  i in mapCell.NextAvailableCellsIndexes)
        {
            NextAvailableCellsIndexes.Add(i);
        }
    
        IsAvailable = mapCell.IsAvailable;
        IsActivated = mapCell.IsActivated;

        //if(IsAvailable)
        //{
        //    Debug.Log("Save True!!!!!!!!!!!!!!!");
        //}
    }
}
