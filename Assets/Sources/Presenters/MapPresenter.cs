using System.Collections.Generic;

public class MapPresenter : IPresenter
{
    private MapView _view;
    private Map _model;

    public MapPresenter(MapView view, Map model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _model.MapGenerated += OnMapGeneration;
    }

    public void Disable()
    {
        _model.MapGenerated -= OnMapGeneration;
    }

    private void OnMapGeneration(List<MapCell> cells)
    {
        _view.VisualizeMap(cells);
    }
}