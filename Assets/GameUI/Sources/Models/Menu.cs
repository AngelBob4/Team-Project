using GameUI.Sources.Enums;

namespace GameUI.Sources.Models
{
    public class Menu
    {
        private SceneHandler _sceneHandler;

        public Menu(SceneHandler sceneHandler)
        {
            _sceneHandler = sceneHandler;
        }

        public void StartGame()
        {
            _sceneHandler.ChangeScene(SceneType.Map);
        }
    }
}