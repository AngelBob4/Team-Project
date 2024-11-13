using System;
using System.Collections.Generic;
using System.Linq;

public class Map
{
    private readonly int _amountOfCellTypes;
    private readonly int _amountOfLevels = 5;
    private readonly int _maxRoadsInlevel = 5;
    private Random _random = new Random();

    private List<MapCell> _mapCells;
    private MapCell _currentCell;

    public int AmountOfLevels => _amountOfLevels;
    public int MaxRoadsInlevel => _maxRoadsInlevel;


    public event Action<List<MapCell>> MapGenerated;

    public Map()
    {
        _amountOfCellTypes = Enum.GetNames(typeof(MapCellType)).Length;
        _mapCells = new List<MapCell>();
    }

    public void ButtonClicked(PositionInArray index)
    {
        if (_currentCell != null)
        {
            if (_currentCell.Index.Equals(index))
            {
                return;
            }

            List<MapCell> previousLevelCells = _mapCells.Where(newCell => newCell.Index.X == index.X && newCell.Index.Equals(index) == false).ToList();

            foreach (MapCell cell in previousLevelCells)
            {
                cell.DeactivateCell();
            }

            _currentCell.DeactivateCell();
        }

        _currentCell = _mapCells.FirstOrDefault(cell => cell.Index.Equals(index));
        _currentCell.PlayerArriviedToThisCell();

        List<MapCell> nextLevelCells = _mapCells.Where(newCell => newCell.Index.X == _currentCell.Index.X + 1).ToList();

        foreach (MapCell nextCell in nextLevelCells)
        {
            nextCell.ActivateCell();
        }
    }

    public void Generate()
    {
        GenerateCells();
        GenerateRoads();

        MapGenerated?.Invoke(_mapCells);

        _mapCells[0].ActivateCell();
    }

    private void GenerateCells()
    {
        int startCell = _random.Next(0, _maxRoadsInlevel - 1);
        _mapCells.Add(new MapCell(MapCellType.Filled, 0, startCell));

        for (int x = 1; x < _amountOfLevels - 1; x++)
        {
            for (int y = 0; y < _maxRoadsInlevel; y++)
            {
                MapCellType newType = (MapCellType)_random.Next(_amountOfCellTypes);

                if (newType == MapCellType.Empty)
                    continue;

                _mapCells.Add(new MapCell(newType, x, y));
            }
        }

        int endCell = _random.Next(0, _maxRoadsInlevel - 1);
        _mapCells.Add(new MapCell(MapCellType.Filled, _amountOfLevels - 1, endCell));
    }

    private void GenerateRoads()
    {
        foreach (MapCell cell in _mapCells)
        {
            List<MapCell> nextLevelCells = _mapCells.Where(newCell => newCell.Index.X == cell.Index.X + 1).ToList();

            foreach (MapCell nextCell in nextLevelCells)
            {
                if (nextCell.Type == MapCellType.Filled)
                {
                    cell.AddRoadToNextCell(nextCell.Index.X, nextCell.Index.Y);
                }
            }
        }
    }
}