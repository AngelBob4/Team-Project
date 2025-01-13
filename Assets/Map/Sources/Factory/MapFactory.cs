using UnityEngine;
using UnityEngine.UI;

public class MapFactory
{
    private Map _map;
    private RectTransform _mapView;
    private MapCellView _filledTemplate;
    private Image _roadTemplate;

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

    public MapCellView CreateCell(MapCell cell, Transform container, PositionOnMap position)
    {
        float widthBewteenCells = _width / _maxRoadsInlevel;
        float heightBewteenCells = _height / _amountOfLevels;

        Vector3 newPosition = new Vector3(widthBewteenCells * position.Y,
            heightBewteenCells * position.X,
            0);
        Vector3 containerOffset = new Vector3(_mapView.rect.width, 
            _mapView.rect.height, 
            0) / 2;

        newPosition -= containerOffset;

        Vector3 generationOffset = new Vector3(widthBewteenCells ,heightBewteenCells, 0) / 2;
        newPosition += generationOffset;


        MapCellView newCell = cell.Type switch
        {
            MapCellType.Filled => Object.Instantiate(_filledTemplate, newPosition, Quaternion.identity, container),
            _ => Object.Instantiate(_filledTemplate, Vector3.zero, Quaternion.identity, container),
        };

        newCell.gameObject.transform.localPosition = newPosition;

        MapCellPresenter mapCellPresenter = new MapCellPresenter(newCell, cell, _map);
        newCell.Init(mapCellPresenter);

        return newCell;
    }

    public Image CreateRoad(MapCellView firstCell, MapCellView secondCell, Transform container)
    {
        Vector3 firstCellPosition = firstCell.transform.position;
        Vector3 secondCellPosition = secondCell.transform.position;

        Vector3 newPosition = (firstCellPosition + secondCellPosition) / 2;

        float angle = Vector2.SignedAngle(Vector2.up, secondCellPosition - firstCellPosition);
        Image newRoad = Object.Instantiate(_roadTemplate, newPosition, Quaternion.Euler(0, 0, angle), container);

        float length = (secondCellPosition - firstCellPosition).magnitude;
        newRoad.rectTransform.sizeDelta = new Vector2(newRoad.rectTransform.sizeDelta.x, length);

        return newRoad;
    }
}