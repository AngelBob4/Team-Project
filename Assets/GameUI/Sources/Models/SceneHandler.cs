using System.Collections.Generic;
using UnityEngine.SceneManagement;
using GameUI.Sources.Enums;

namespace GameUI.Sources.Models
{
    public class SceneHandler
    {
        private Dictionary<SceneType, int> Scenes = new Dictionary<SceneType, int>();

        public SceneHandler()
        {
            CreateSceneDictionary();
            LoadScenes();
        }

        public void ChangeScene(SceneType sceneType)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(Scenes[sceneType]));
        }

        private void CreateSceneDictionary()
        {
            Scenes.Add(SceneType.Menu, 0);
            Scenes.Add(SceneType.Map, 1);
            Scenes.Add(SceneType.Runner, 2);
            Scenes.Add(SceneType.Battle, 3);
        }

        private void LoadScenes()
        {
            foreach (var scene in Scenes)
            {
                SceneManager.LoadSceneAsync(scene.Value, LoadSceneMode.Additive);
            }
        }
    }
}