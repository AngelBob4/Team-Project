using UnityEngine;
using Reflex.Core;
using GameUI.Sources.Models.MapComponents;

namespace ProjectResources
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(new Map());
        }
    }
}