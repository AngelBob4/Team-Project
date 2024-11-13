using UnityEngine;
using UnityEngine.UI;

public class GameCompositeRoot : MonoBehaviour
{
    [SerializeField] private MapCellView _filledCell;
    [SerializeField] private Image _roadBetweenCells;
    [SerializeField] private RectTransform _mapContainer;
    [SerializeField] private MapView _mapView;

    private MapFactory _mapCellViewFactory;

    private void Start()
    {
        Compose();
    }

    private void Compose()
    {
        Map map = new Map();

        _mapCellViewFactory = new MapFactory(_mapContainer, _filledCell, _roadBetweenCells, map);

        MapPresenter mapPresenter = new MapPresenter(_mapView, map);

        _mapView.Init(mapPresenter, _mapCellViewFactory);

        map.Generate();
    }
}