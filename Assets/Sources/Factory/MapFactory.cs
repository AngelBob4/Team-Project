using UnityEngine;
using UnityEngine.UI;

public class MapFactory
{
    private RectTransform _mapView;
    private MapCellView _filledTemplate;
    private Image _roadTemplate;
    private Map _map;

    private float _width;
    private float _height;

    private readonly int _amountOfLevels;
    private readonly int _maxRoadsInlevel;

    public MapFactory(RectTransform mapView, MapCellView filledTemplate, Image roadTemplate, Map map)
    {
        _map = map;
        _mapView = mapView;
        _filledTemplate = filledTemplate;
        _roadTemplate = roadTemplate;

        _width = _mapView.sizeDelta.x;
        _height = _mapView.sizeDelta.y;

        _amountOfLevels = _map.AmountOfLevels;
        _maxRoadsInlevel = _map.MaxRoadsInlevel;
    }

    public MapCellView CreateCell(MapCell cell, Transform container, IndexInArray position)
    {
        float widthBewteenCells = _width / _maxRoadsInlevel;
        float heightBewteenCells = _height / _amountOfLevels;

        Vector3 newPosition = new Vector3(widthBewteenCells * position.Y,
            heightBewteenCells * position.X,
            0);

        Vector3 containerOffset = _mapView.position / 2;
        newPosition += containerOffset;

        MapCellView newCell = cell.Type switch
        {
            MapCellType.Filled => Object.Instantiate(_filledTemplate, newPosition, Quaternion.identity, container),
            _ => Object.Instantiate(_filledTemplate, newPosition, Quaternion.identity, container),
        };

        MapCellPresenter mapCellPresenter = new MapCellPresenter(newCell, cell, _map);
        newCell.Init(mapCellPresenter);

        return newCell;
    }

    public Image CreateRoad(IndexInArray firstCell, IndexInArray secondCell, Transform container)
    {
        float widthBewteenCells = _width / _maxRoadsInlevel;
        float heightBewteenCells = _height / _amountOfLevels;

        Vector3 firstCellPosition = new Vector3(widthBewteenCells * firstCell.Y,
            heightBewteenCells * firstCell.X,
            0);

        Vector3 secondCellPosition = new Vector3(widthBewteenCells * secondCell.Y,
        heightBewteenCells * secondCell.X,
        0);

        Vector3 newPosition = (firstCellPosition + secondCellPosition) / 2;
        Vector3 containerOffset = _mapView.position / 2;
        newPosition += containerOffset;

        float angle = Vector2.SignedAngle(Vector2.up, secondCellPosition - firstCellPosition);
        Image newRoad = Object.Instantiate(_roadTemplate, newPosition, Quaternion.Euler(0, 0, angle), container);

        float length = (secondCellPosition - firstCellPosition).magnitude;
        newRoad.rectTransform.sizeDelta = new Vector2(newRoad.rectTransform.sizeDelta.x, length);

        return newRoad;
    }
}