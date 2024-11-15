using UnityEngine;
using UnityEngine.UI;
using Reflex.Attributes;

public class GameCompositeRoot : MonoBehaviour
{
    [SerializeField] private MapCellView _filledCell;
    [SerializeField] private Image _roadBetweenCells;
    [SerializeField] private RectTransform _mapContainer;
    [SerializeField] private MapView _mapView;

    private Map _map;
    private MapFactory _mapCellViewFactory;

    private void Awake()
    {
        Compose();
    }

    private void Compose()
    {
        _map = new Map();
        _mapCellViewFactory = new MapFactory(_mapContainer, _filledCell, _roadBetweenCells, _map);

        MapPresenter mapPresenter = new MapPresenter(_mapView, _map);

        _mapView.Init(mapPresenter, _mapCellViewFactory);
        _map.Generate();
    }
}