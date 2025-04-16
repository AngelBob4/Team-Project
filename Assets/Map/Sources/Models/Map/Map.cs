using System;
using System.Collections.Generic;
using System.Linq;
using Events.Main.Events;
using MainGlobal;
using Runner.Enums;
using UnityEngine;
using Random = System.Random;

public class Map
{
    private readonly int _amountOfCellTypes;
    private int _amountOfLevels = 9;
    private int _maxRoadsInlevel = 5;
    private Random _random = new Random();
    
    private List<MapCell> _mapCells;
    private List<MapCell> _currentMapCells;
    private MapCell _currentCell;
    private GlobalGame _globalGame;
    
    public int AmountOfLevels => _amountOfLevels;
    public int MaxRoadsInlevel => _maxRoadsInlevel;
    public bool IsEmpty => _mapCells.Count == 0;

    public event Action<List<MapCell>> MapGenerated;

    public void Initialize(GlobalGame globalGame)
    {
        _globalGame = globalGame;
    }

    public Map()
    {
        _amountOfCellTypes = Enum.GetNames(typeof(EventsType)).Length;
        _mapCells = new List<MapCell>();
    }

    public void ButtonClicked(int index)
    {
        if (_currentCell != null)
        {
            if (_currentCell.Index == index)
                return;

            List<MapCell> previousLevelCells = _mapCells.Where(newCell =>
                newCell.Position.X == (_currentCell.Position.X + 1) && _currentCell.Index != index).ToList();

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
        
        _globalGame.SetEvent(_currentCell.Type);
      //  _globalGame.SetLocationRunner(LocationTypes.Cemetery);
        _globalGame.StartRunner();
    }

    public void ActivateMap()
    {
        if (_currentCell == null)
        {
            MapGenerated?.Invoke(_mapCells);
            _mapCells[0].ActivateCell();
            return;
        }

        MapGenerated?.Invoke(_mapCells);
        
        foreach (int cellIndex in _currentCell.NextAvailableCellsIndexes)
        {        
            _mapCells[cellIndex].ActivateCell();
        }

        foreach (var cell in _mapCells)
        {
            if (cell.IsActivated)
            {
                cell.PlayerArriviedToThisCell();
            }
        }
    }

    public void RestartGame()
    {
        _currentCell = null;
        _amountOfLevels = 9;
        _maxRoadsInlevel = 5;
        _mapCells.Clear();
        GenerateCells();
        GenerateRoads();
        MapGenerated?.Invoke(_mapCells);
        
        _mapCells[0].ActivateCell();
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

        _mapCells.Add(new MapCell(EventsType.Battle, 0, centralCell, _mapCells.Count));

        for (int x = 1; x < _amountOfLevels - 1; x++)
        {
            attemptsToMakeCell = 0;

            for (int y = 0; y < _maxRoadsInlevel; y++)
            {
                currentPercentsToMakeCell = defaultPercentsToMakeCell + attemptsToMakeCell * extraPercentsToMakeCell;

                EventsType newType;

                if (Extensions.RandomBoolWithPercents(currentPercentsToMakeCell))             
                    newType = (EventsType)_random.Next(1, _amountOfCellTypes - 1);
                else
                    newType = (EventsType)_random.Next(0, _amountOfCellTypes - 1);

                if (newType == EventsType.Null)
                    continue;

                _mapCells.Add(new MapCell(newType, x, y, _mapCells.Count));
                attemptsToMakeCell = 0;
            }
        }

        _mapCells.Add(new MapCell(EventsType.Boss, _amountOfLevels - 1, centralCell, _mapCells.Count));
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