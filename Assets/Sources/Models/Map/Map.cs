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

    public void ButtonClicked(IndexInArray index)
    {
        if (_currentCell != null)
        {
            if (_currentCell.Index.Equals(index))
                return;

            List<MapCell> previousLevelCells = _mapCells.Where(newCell => newCell.Index.X == index.X && newCell.Index.Equals(index) == false).ToList();

            foreach (MapCell cell in previousLevelCells)
            {
                cell.DeactivateCell();
            }

            _currentCell.DeactivateCell();
        }

        _currentCell = _mapCells.FirstOrDefault(cell => cell.Index.Equals(index));
        _currentCell.PlayerArriviedToThisCell();

        foreach (IndexInArray cellIndex in _currentCell.NextAvailableCellsIndexes)
        {
            _mapCells.FirstOrDefault(cell => cell.Index.Equals(cellIndex)).ActivateCell();
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

        _mapCells.Add(new MapCell(MapCellType.Filled, 0, centralCell));

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

                _mapCells.Add(new MapCell(newType, x, y));
                attemptsToMakeCell = 0;
            }
        }

        _mapCells.Add(new MapCell(MapCellType.Filled, _amountOfLevels - 1, centralCell));
    }

    private void GenerateRoads()
    {
        int percentsToMakeRoadNextCell = 50;
        List<MapCell> nextLevelCells;

        foreach (MapCell cell in _mapCells)
        {
            if (cell.Equals(_mapCells[0]) || cell.Index.X == _amountOfLevels - 2 || cell.Index.X == _amountOfLevels - 1)
            {
                nextLevelCells = _mapCells.Where(newCell => newCell.Index.X == cell.Index.X + 1).ToList();

                foreach (MapCell nextCell in nextLevelCells)
                {
                    cell.AddRoadToNextCell(new IndexInArray(nextCell.Index.X, nextCell.Index.Y));
                }

                continue;
            }

            nextLevelCells = _mapCells.Where(newCell => newCell.Index.X == cell.Index.X + 1).ToList();

            int leftIndex = cell.Index.Y;
            int rightIndex = cell.Index.Y;
            int counterOfLoops = 0;

            MapCell leftCell = nextLevelCells.FirstOrDefault(cell => cell.Index.Equals(new IndexInArray(cell.Index.X, leftIndex)));
            MapCell rightCell = nextLevelCells.FirstOrDefault(cell => cell.Index.Equals(new IndexInArray(cell.Index.X, rightIndex)));

            if (leftCell != null || rightCell != null)
            {
                cell.AddRoadToNextCell(leftCell.Index);
                leftIndex -= 1;

                if (leftIndex >= 0)
                {
                    leftCell = nextLevelCells.FirstOrDefault(cell => cell.Index.Equals(new IndexInArray(cell.Index.X, leftIndex)));

                    if (leftCell != null && Extensions.RandomBoolWithPercents(percentsToMakeRoadNextCell))
                        cell.AddRoadToNextCell(leftCell.Index);
                }

                rightIndex += 1;

                if (rightIndex <= _amountOfLevels - 1)
                {
                    rightCell = nextLevelCells.FirstOrDefault(cell => cell.Index.Equals(new IndexInArray(cell.Index.X, rightIndex)));

                    if (rightCell != null && Extensions.RandomBoolWithPercents(percentsToMakeRoadNextCell))
                        cell.AddRoadToNextCell(rightCell.Index);
                }
            }
            else
            {
                while (leftCell == null && rightCell == null && counterOfLoops < 10)
                {
                    leftIndex -= 1;
                    rightIndex += 1;

                    leftCell = nextLevelCells.FirstOrDefault(cell => cell.Index.Equals(new IndexInArray(cell.Index.X, leftIndex)));
                    rightCell = nextLevelCells.FirstOrDefault(cell => cell.Index.Equals(new IndexInArray(cell.Index.X, rightIndex)));

                    if (leftIndex < 0)
                        leftIndex = 0;

                    if (rightIndex > _maxRoadsInlevel - 1)
                        rightIndex = _maxRoadsInlevel - 1;

                    counterOfLoops++;
                }

                if (leftCell != null)
                {
                    cell.AddRoadToNextCell(leftCell.Index);
                }

                if (rightCell != null)
                {
                    cell.AddRoadToNextCell(rightCell.Index);
                }
            }
        }
    }
}