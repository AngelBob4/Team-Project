using Events.Main.Events;
using MainGlobal;
using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour
{
    [SerializeField] private GameObject _cellsContainer;
    [SerializeField] private GameObject _roadsContainer;
    [SerializeField] private ImagesSO _allImages;

    private Dictionary<EventsType, Sprite> _sprites;

    private MapFactory _mapFactory;
    private IPresenter _presenter;
    private GlobalGame _globalGame;

    private List<MapCellView> _mapCellViews;

    [Inject]
    public void Inject(GlobalGame globalGameData)
    {
        _globalGame = globalGameData;
    }

    public void Init(IPresenter presenter, MapFactory mapFactory)
    {
        gameObject.SetActive(false);
        _presenter = presenter;
        gameObject.SetActive(true);

        _mapFactory = mapFactory;
    }

    private void OnEnable()
    {
        _sprites = new Dictionary<EventsType, Sprite>()
        {
         {EventsType.Null, _allImages.Null},
         {EventsType.Shop, _allImages.Shop},
         {EventsType.Boss, _allImages.Boss},
         {EventsType.Battle, _allImages.Battle},
         {EventsType.Dialog, _allImages.Dialog},
        };

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
            newView.InitImage(_sprites[mapCell.Type]);
            _mapCellViews.Add(newView);
        }

        for (int x = 0; x < cells.Count; x++)
        {
            List<int> nextAvailableCells = new List<int>(cells[x].NextAvailableCellsIndexes);

            if (nextAvailableCells.Count != 0)
            {
                for (int i = 0; i < nextAvailableCells.Count; i++)
                {
                    //Debug.Log(_mapCellViews[nextAvailableCells[i]]);
                    _mapFactory.CreateRoad(_mapCellViews[x], _mapCellViews[nextAvailableCells[i]], _roadsContainer.transform);
                }
            }
        }
    }
}