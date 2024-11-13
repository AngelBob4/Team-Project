using System;
using System.Collections.Generic;

public class MapCell
{
    private List<PositionInArray> _nextAvailableCellsIndexes;
    private readonly MapCellType _type;
    private readonly PositionInArray _index;
    private bool _isActive = false;

    public event Action Activated;
    public event Action Deactivated;
    public event Action PlayerArriviedToCell;

    public List<PositionInArray> NextAvailableCellsIndexes => new(_nextAvailableCellsIndexes);
    public MapCellType Type => _type;
    public PositionInArray Index => _index;
    public bool IsActive => _isActive;

    public MapCell(MapCellType type, int x, int y)
    {
        _nextAvailableCellsIndexes = new List<PositionInArray>();
        _index = new PositionInArray(x, y);
        _type = type;
    }

    public void AddRoadToNextCell(int x, int y)
    {
        PositionInArray newCellIndex = new PositionInArray(x, y);
        _nextAvailableCellsIndexes.Add(newCellIndex);
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

public struct PositionInArray
{
    private readonly int x;
    private readonly int y;

    public int X => x;
    public int Y => y;

    public PositionInArray(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}