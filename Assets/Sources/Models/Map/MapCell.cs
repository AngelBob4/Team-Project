using System;
using System.Collections.Generic;

public class MapCell
{
    private List<IndexInArray> _nextAvailableCellsIndexes;
    private readonly MapCellType _type;
    private readonly IndexInArray _index;
    private bool _isActive = false;

    public event Action Activated;
    public event Action Deactivated;
    public event Action PlayerArriviedToCell;

    public List<IndexInArray> NextAvailableCellsIndexes => new(_nextAvailableCellsIndexes);
    public MapCellType Type => _type;
    public IndexInArray Index => _index;
    public bool IsActive => _isActive;

    public MapCell(MapCellType type, int x, int y)
    {
        _nextAvailableCellsIndexes = new List<IndexInArray>();
        _index = new IndexInArray(x, y);
        _type = type;
    }

    public void AddRoadToNextCell(IndexInArray index)
    {
        _nextAvailableCellsIndexes.Add(index);
    }

    public void ActivateCell()
    {
        Activated?.Invoke();
    }

    public void DeactivateCell()
    {
        Deactivated?.Invoke();
    }

    public void PlayerArriviedToThisCell()
    {
        PlayerArriviedToCell?.Invoke();
    }
}

public struct IndexInArray
{
    private readonly int x;
    private readonly int y;

    public int X => x;
    public int Y => y;

    public IndexInArray(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}