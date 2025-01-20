using UnityEngine;
using UnityEngine.UI;
using Reflex.Attributes;
using GameUI.Sources.Presenters;
using GameUI.Sources.Factory;
using GameUI.Sources.Models.MapComponents;

namespace GameUI.Sources.Views.MapComponents
{
    public class MapCompositeRoot : MonoBehaviour
    {
        [Header("Map")]
        [SerializeField] private MapCellView _filledCell;
        [SerializeField] private Image _roadBetweenCells;
        [SerializeField] private RectTransform _mapBackground;
        [SerializeField] private MapView _mapView;

        private Map _map;
        private MapFactory _mapFactory;

        [Inject]
        private void Inject(Map map)
        {
            _map = map;
        }

        private void Awake()
        {
            Compose();
        }

        private void Compose()
        {
            _mapFactory = new MapFactory(_mapBackground, _filledCell, _roadBetweenCells, _map);

            MapPresenter mapPresenter = new MapPresenter(_mapView, _map);

            _mapView.Init(mapPresenter, _mapFactory);
            _map.Generate();
        }
    }
}