using System;
using System.Collections.Generic;
using System.Linq;
using Events.Main.Events;
using MainGlobal;
using Runner.Enums;

public class Map
{
    private readonly int _amountOfCellTypes;
    private readonly int _amountOfLevels = 9;
    private readonly int _maxRoadsInlevel = 5;
    private Random _random = new Random();

    private List<MapCell> _mapCells;
    private List<MapCell> _currentMapCells;
    private MapCell _currentCell;
    private GlobalGame _globalGame;
    
    
    public int AmountOfLevels => _amountOfLevels;
    public int MaxRoadsInlevel => _maxRoadsInlevel;


    public event Action<List<MapCell>> MapGenerated;

    public Map(GlobalGame globalGame)
    {
        _globalGame = globalGame;
        _amountOfCellTypes = Enum.GetNames(typeof(MapCellType)).Length;
        _mapCells = new List<MapCell>();
    }

    public void ButtonClicked(int index)
    {
        _globalGame.SetEvent(EventsType.Battle);
        _globalGame.SetLocationRunner(LocationTypes.Cemetery);
        _globalGame.StartRunner();
        
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
            if (cell.Index == _mapCells[0].Index || 
                cell.Position.X == _amountOfLevels - 2 || 
                cell.Index == _mapCells[_mapCells.Count - 1].Index)
            {
                nextLevelCells = _mapCells.Where(newCell => newCell.Position.X == cell.Position.X + 1).ToList();

                foreach (MapCell nextCell in nextLevelCells)
                {
                    cell.AddRoadToNextCell(nextCell);
                }

                continue;
            }

            nextLevelCells = _mapCells.Where(newCell => newCell.Position.X == cell.Position.X + 1).ToList();

            MapCell directCell = nextLevelCells.FirstOrDefault(newCell => newCell.Position.Y == cell.Position.Y);

            if (directCell != null)
            {
                SetRoadsToDirectCells(cell, nextLevelCells, directCell.Index);
            }
            else
            {
                SetRoadsToDiagonalCells(cell, nextLevelCells);
            }

            SetRoadsToUnavailableCells();
        }
    }

    private void SetRoadsToDirectCells(MapCell cell, List<MapCell> nextLevelCells, int directCellIndex)
    {
        int leftIndex = cell.Position.Y;
        int rightIndex = cell.Position.Y;
        int percentsToMakeRoadNextCell = 50;
        cell.AddRoadToNextCell(_mapCells[directCellIndex]);

        MapCell leftCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, leftIndex)));
        MapCell rightCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, rightIndex)));

        leftIndex -= 1;
        rightIndex += 1;

        if (leftIndex >= 0)
        {
            leftCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, leftIndex)));

            if (leftCell != null && Extensions.RandomBoolWithPercents(percentsToMakeRoadNextCell))
                cell.AddRoadToNextCell(leftCell);
        }

        if (rightIndex <= _amountOfLevels - 1)
        {
            rightCell = nextLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, rightIndex)));

            if (rightCell != null && Extensions.RandomBoolWithPercents(percentsToMakeRoadNextCell))
                cell.AddRoadToNextCell(rightCell);
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
            cell.AddRoadToNextCell(leftCell);

        if (rightCell != null)
            cell.AddRoadToNextCell(rightCell);
    }

    private void SetRoadsToUnavailableCells()
    {
        int leftIndex;
        int rightIndex;
        int counterOfLoops;
        MapCell leftCell;
        MapCell rightCell;

        foreach (MapCell unavailableCell in _mapCells)
        {
            if (unavailableCell.IsAvailable || _mapCells[0] == unavailableCell)
                continue;
            
            List<MapCell> previousLevelCells = _mapCells.Where(newCell => newCell.Position.X == unavailableCell.Position.X - 1).ToList();
            counterOfLoops = 0;
            leftIndex = unavailableCell.Position.Y;
            rightIndex = unavailableCell.Position.Y;
            leftCell = previousLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, leftIndex)));
            rightCell = previousLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, rightIndex)));

            while (leftCell == null && rightCell == null && counterOfLoops < 10)
            {
                leftIndex -= 1;
                rightIndex += 1;

                leftCell = previousLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, leftIndex)));
                rightCell = previousLevelCells.FirstOrDefault(cell => cell.Position.Equals(new PositionOnMap(cell.Position.X, rightIndex)));

                if (leftIndex < 0)
                    leftIndex = 0;

                if (rightIndex > _maxRoadsInlevel - 1)
                    rightIndex = _maxRoadsInlevel - 1;

                counterOfLoops++;
            }

            if (leftCell != null)
                leftCell.AddRoadToNextCell(unavailableCell);

            if (rightCell != null)
                rightCell.AddRoadToNextCell(unavailableCell);
        }
    }
}