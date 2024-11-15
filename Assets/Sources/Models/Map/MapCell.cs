using System;
using System.Collections.Generic;

public class MapCell
{
    private List<int> _nextAvailableCellsIndexes;
    private readonly MapCellType _type;
    private readonly PositionOnMap _position;
    private readonly int _index;

    public event Action Activated;
    public event Action Deactivated;
    public event Action PlayerArriviedToCell;

    public List<int> NextAvailableCellsIndexes => new(_nextAvailableCellsIndexes);
    public MapCellType Type => _type;
    public PositionOnMap Position => _position;
    public int Index => _index;

    public MapCell(MapCellType type, int x, int y, int index)
    {
        _nextAvailableCellsIndexes = new List<int>();
        _position = new PositionOnMap(x, y);
        _type = type;
        _index = index;
    }

    public void AddRoadToNextCell(int index)
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

public struct PositionOnMap
{
    private readonly int x;
    private readonly int y;

    public int X => x;
    public int Y => y;

    public PositionOnMap(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}