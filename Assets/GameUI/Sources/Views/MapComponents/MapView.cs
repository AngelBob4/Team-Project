using System.Collections.Generic;
using UnityEngine;
using GameUI.Sources.Factory;
using GameUI.Sources.Infrastructure;
using GameUI.Sources.Models.MapComponents;

namespace GameUI.Sources.Views.MapComponents
{
    public class MapView : MonoBehaviour
    {
        [SerializeField] private GameObject _cellsContainer;
        [SerializeField] private GameObject _roadsContainer;

        private MapFactory _mapFactory;
        private IPresenter _presenter;

        private List<MapCellView> _mapCellViews;

        public void Init(IPresenter presenter, MapFactory mapFactory)
        {
            gameObject.SetActive(false);
            _presenter = presenter;
            gameObject.SetActive(true);

            _mapFactory = mapFactory;
        }

        private void OnEnable()
        {
            _presenter?.Enable();
        }

        private void OnDisable()
        {
            _presenter?.Disable();
        }

        public void VisualizeMap(List<MapCell> cells)
        {
            _mapCellViews = new List<MapCellView>();

            foreach (MapCell mapCell in cells)
            {
                MapCellView newView = _mapFactory.CreateCell(mapCell, _cellsContainer.transform, mapCell.Position);
                _mapCellViews.Add(newView);
            }

            for (int x = 0; x < cells.Count; x++)
            {
                List<int> nextAvailableCells = new List<int>(cells[x].NextAvailableCellsIndexes);

                if (nextAvailableCells.Count != 0)
                {
                    for (int i = 0; i < nextAvailableCells.Count; i++)
                    {
                        _mapFactory.CreateRoad(_mapCellViews[x],
                            _mapCellViews[nextAvailableCells[i]],
                            _roadsContainer.transform);
                    }
                }
            }
        }
    }
}