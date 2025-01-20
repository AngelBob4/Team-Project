using UnityEngine;
using Reflex.Core;
using GameUI.Sources.Models.MapComponents;
using GameUI.Sources.Models;

namespace ProjectResources
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(new Map());
            containerBuilder.AddSingleton(new SceneHandler());
        }
    }
}