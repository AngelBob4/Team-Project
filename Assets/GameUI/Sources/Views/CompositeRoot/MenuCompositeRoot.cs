using GameUI.Sources.Models;
using GameUI.Sources.Presenters;
using Reflex.Attributes;
using UnityEngine;

namespace GameUI.Sources.Views.MapComponents
{
    public class MenuCompositeRoot : MonoBehaviour
    {
        [SerializeField] private MenuView _menuView;

        private Menu _menu;
        private MenuPresenter _menuPresenter;

        private SceneHandler _sceneHandler;

        private void Start()
        {
            _menu = new Menu(_sceneHandler);

            _menuPresenter = new MenuPresenter(_menu, _menuView);
        }

        [Inject]
        private void Inject(SceneHandler sceneHandler)
        {
            _sceneHandler = sceneHandler;
        }
    }
}