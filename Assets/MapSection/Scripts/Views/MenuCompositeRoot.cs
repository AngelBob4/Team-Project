using UnityEngine;
using UnityEngine.UI;
using Reflex.Attributes;
using MainGlobal;
using MapSection.Presenters;
using MapSection.Views;
using MapSection.Models;
using YG.Example;

namespace MapSection
{
    public class MenuCompositeRoot : MonoBehaviour
    {
        [Header("Map")]
        [SerializeField] private MapCellView _filledCell;
        [SerializeField] private Image _roadBetweenCells;
        [SerializeField] private RectTransform _mapContainer;
        [SerializeField] private MapView _mapView;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Saves _saveData;
        
        private Map _map;
        private MapFactory _mapFactory;
        private GlobalGame _globalGame;

        [Inject]
        private void Inject(Map map)
        {
            _map = map;
        }

        [Inject]
        private void Inject(GlobalGame globalGame)
        {
            _globalGame = globalGame;
        }

        private void Awake()
        {
            Compose();
        }

        private void Compose()
        {
            InitVolume();
            Save();

            _mapFactory = new MapFactory(_mapContainer, _filledCell, _roadBetweenCells, _map,
                _mapView.transform.localScale.x);

            MapPresenter mapPresenter = new MapPresenter(_mapView, _map);

            _mapView.Init(mapPresenter, _mapFactory);
            _map.ActivateMap();
        }

        private void InitVolume()
        {
            _audioSource.volume = _globalGame.BackgroundMusicVolume;
        }

        private void Save()
        {
            _saveData.Save();
        }
    }
}