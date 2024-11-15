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

    public void ButtonClicked(int index)
    {
        if (_currentCell != null)
        {
            if (_currentCell.Index == index)
                return;

            List<MapCell> previousLevelCells = _mapCells.Where(newCell => newCell.Position.X == (_currentCell.Position.X + 1)&& _currentCell.Index != index).ToList();

            foreach (MapCell cell in previousLevelCells)
            {
                cell.DeactivateCell();
            }

            _currentCell.DeactivateCell();
        }

        _currentCell = _mapCells.FirstOrDefault(cell => cell.Index == index);
        _currentCell.PlayerArriviedToThisCell();

        foreach (int cellIndex in _currentCell.NextAvailableCellsIndexes)
        {
            _mapCells[cellIndex].ActivateCell();
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
        int defaultPercentsToMakeCell = 50;
        int extraPercentsToMakeCell = 20; 
        int centralCell = 2;

        int attemptsToMakeCell;
        int currentPercentsToMakeCell;

        _mapCells.Add(new MapCell(MapCellType.Filled, 0, centralCell, _mapCells.Count));

        for (int x = 1; x < _amountOfLevels - 1; x++)
        {
            attemptsToMakeCell = 0;

            for (int y = 0; y < _maxRoadsInlevel; y++)
            {
                currentPercentsToMakeCell = defaultPercentsToMakeCell + attemptsToMakeCell * extraPercentsToMakeCell;

                MapCellType newType;

                if (Extensions.RandomBoolWithPercents(currentPercentsToMakeCell))             
                    newType = (MapCellType)_random.Next(1, _amountOfCellTypes);
                else
                    newType = (MapCellType)_random.Next(_amountOfCellTypes);

                if (newType == MapCellType.Empty)
                    continue;

                _mapCells.Add(new MapCell(newType, x, y, _mapCells.Count));
                attemptsToMakeCell = 0;
            }
        }

        _mapCells.Add(new MapCell(MapCellType.Filled, _amountOfLevels - 1, centralCell, _mapCells.Count));
    }

    private void GenerateRoads()
    {
        List<MapCell> nextLevelCells;

        foreach (MapCell cell in _mapCells)
        {
            if (cell.Equals(_mapCells[0]) || cell.Position.X == _amountOfLevels - 2 || cell.Position.X == _amountOfLevels - 1)
            {
                nextLevelCells = _mapCells.Where(newCell => newCell.Position.X == cell.Position.X + 1).ToList();

                foreach (MapCell nextCell in nextLevelCells)
                {
                    cell.AddRoadToNextCell(nextCell.Index);
                }

                continue;
            }

            nextLevelCells = _mapCells.Where(newCell => newCell.Position.X == cell.Position.X + 1).ToList();

            MapCell directCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, cell.Position.Y)));

            if (directCell != null)
            {
                SetRoadsToDirectCells(cell, nextLevelCells, directCell.Index);
            }
            else
            {
                SetRoadsToDiagonalCells(cell, nextLevelCells);
            }
        }
    }

    private void SetRoadsToDirectCells(MapCell cell, List<MapCell> nextLevelCells, int directCellIndex)
    {
        int leftIndex = cell.Position.Y;
        int rightIndex = cell.Position.Y;
        int percentsToMakeRoadNextCell = 50;
        cell.AddRoadToNextCell(directCellIndex);

        MapCell leftCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, leftIndex)));
        MapCell rightCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, rightIndex)));

        leftIndex -= 1;
        rightIndex += 1;

        if (leftIndex >= 0)
        {
            leftCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, leftIndex)));

            if (leftCell != null && Extensions.RandomBoolWithPercents(percentsToMakeRoadNextCell))
                cell.AddRoadToNextCell(leftCell.Index);
        }

        if (rightIndex <= _amountOfLevels - 1)
        {
            rightCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, rightIndex)));

            if (rightCell != null && Extensions.RandomBoolWithPercents(percentsToMakeRoadNextCell))
                cell.AddRoadToNextCell(rightCell.Index);
        }
    }

    private void SetRoadsToDiagonalCells(MapCell cell, List<MapCell> nextLevelCells)
    {
        int leftIndex = cell.Position.Y;
        int rightIndex = cell.Position.Y;
        int counterOfLoops = 0;
        MapCell leftCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, leftIndex)));
        MapCell rightCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, rightIndex)));

        while (leftCell == null && rightCell == null && counterOfLoops < 10)
        {
            leftIndex -= 1;
            rightIndex += 1;

            leftCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, leftIndex)));
            rightCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, rightIndex)));

            if (leftIndex < 0)
                leftIndex = 0;

            if (rightIndex > _maxRoadsInlevel - 1)
                rightIndex = _maxRoadsInlevel - 1;

            counterOfLoops++;
        }

        if (leftCell != null)
            cell.AddRoadToNextCell(leftCell.Index);

        if (rightCell != null)
            cell.AddRoadToNextCell(rightCell.Index);
    }
}