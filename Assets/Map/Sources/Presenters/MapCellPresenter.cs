using System.Collections.Generic;

public class MapCellPresenter : IPresenter
{
    private MapCellView _view;
    private MapCell _model;
    private Map _map;

    public MapCellPresenter(MapCellView view, MapCell model, Map map)
    {
        _view = view;
        _model = model;
        _map = map;
    }

    public void Enable()
    {
        _model.Activated += OnActivating;
        _model.Deactivated += OnDeactivating;
        _model.PlayerArriviedToCell += OnPlayerArrivingToCell;
        _view.ButtonClicked += OnButtonClicked;
    }

    public void Disable()
    {
        _model.Activated -= OnActivating;
        _model.Deactivated -= OnDeactivating;
        _model.PlayerArriviedToCell -= OnPlayerArrivingToCell;
        _view.ButtonClicked -= OnButtonClicked;
    }

    private void OnActivating()
    {
        _view.TurnOn();
    }

    private void OnDeactivating()
    {
        _view.TurnOff();
    }

    private void OnPlayerArrivingToCell()
    {
        _view.SetRed();
    }

    private void OnButtonClicked()
    {
        _map.ButtonClicked(_model.Index);
    }
}