using GameUI.Sources.Infrastructure;
using GameUI.Sources.Models;

namespace GameUI.Sources.Presenters
{
    public class MenuPresenter : IPresenter
    {
        private Menu _menu;
        private MenuView _menuView;

        public MenuPresenter(Menu menu, MenuView menuView)
        {
            _menu = menu;
            _menuView = menuView;
        }

        public void Enable()
        {
            _menuView.PlayButtonClicked += OnPlayButtonClicked;
        }

        public void Disable()
        {
            _menuView.PlayButtonClicked -= OnPlayButtonClicked;
        }

        private void OnPlayButtonClicked()
        {
            _menu.StartGame();
        }
    }
}