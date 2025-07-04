using System.Collections.Generic;
using MapSection.Infrastructure;
using MapSection.Models;
using MapSection.Views;
using Reflex.Attributes;

namespace MapSection.Presenters
{
    public class MapPresenter : IPresenter
    {
        private Map _model;
        private MapView _view;

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
}