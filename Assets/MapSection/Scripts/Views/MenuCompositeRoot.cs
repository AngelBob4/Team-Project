using UnityEngine;
using UnityEngine.UI;
using Reflex.Attributes;
using MainGlobal;
using MapSection.Presenters;
using MapSection.Views;
using MapSection.Models;
using YG.Example;
using YG;

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
        [SerializeField] private SaveData _saveData;

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
          //  _map.Init(this);
        }

        public void Compose()
        {
            print("—ќЅ–јЋ»  ј–“” - количество селлов " + _map.MapCells.Count+ " актив €чейка " + _map.CurrentCell.Type + " ее индекс  " + _map.CurrentCell.Index);

          

            _mapFactory = new MapFactory(_mapContainer, _filledCell, _roadBetweenCells, _map,
                _mapView.transform.localScale.x);

            MapPresenter mapPresenter = new MapPresenter(_mapView, _map);

            _mapView.Init(mapPresenter, _mapFactory);
            _map.ActivateMap();

            InitVolume();
            Save();
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