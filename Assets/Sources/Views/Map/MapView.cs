using System.Collections.Generic;
using UnityEngine;

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

        foreach (MapCell cell in cells)
        {
            _mapCellViews.Add(_mapFactory.CreateCell(cell, _cellsContainer.transform, cell.Index));

            List <IndexInArray> nextAvailableCells = new List<IndexInArray>(cell.NextAvailableCellsIndexes);

            for (int i = 0; i < nextAvailableCells.Count; i++)
            {
                _mapFactory.CreateRoad(cell.Index,
                    nextAvailableCells[i],
                    _roadsContainer.transform);
            }
        }
    }
}