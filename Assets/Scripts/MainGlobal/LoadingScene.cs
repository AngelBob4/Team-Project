using UnityEngine.SceneManagement;

namespace MainGlobal
{
    public class LoadingScene
    {
        private readonly int sceneIdStartGame = 0;
        private readonly int sceneIdStartEvent = 1;
        private readonly int sceneIdStartMap = 2;
        private readonly int sceneIdStartRuner = 3;

        public void LoadScene(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }

        public void LoadSceneStartGame()
        {
            LoadScene(sceneIdStartGame);
        }

        public void LoadSceneEvent()
        {
            LoadScene(sceneIdStartEvent);
        }

        public void LoadSceneMap()
        {
            LoadScene(sceneIdStartMap);
        }

        public void LoadSceneRuner()
        {
            LoadScene(sceneIdStartRuner);
        }
    }
}
