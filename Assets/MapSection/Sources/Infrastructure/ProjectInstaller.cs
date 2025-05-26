using Events.Animation;
using Events.Cards;
using Events.Main.Events.Dialog;
using MainGlobal;
using MapSection.Models;
using Reflex.Core;
using UnityEngine;

namespace MapSection.Infrastructure
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private CardDataList _startCardDataList;
        [SerializeField] private CardDataList _addCardDataListInDialogEvents;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            PlayerGlobalData _playerGlobalData = new PlayerGlobalData(_startCardDataList);
            LoadingScene _loadingScene = new LoadingScene();
            DialogEventDataList _dialogEventDataList = new DialogEventDataList(_addCardDataListInDialogEvents);
            Map map = new Map();
            GlobalGame globalGame = new GlobalGame(_playerGlobalData, _loadingScene, _dialogEventDataList, map);
            map.Initialize(globalGame);

            containerBuilder.AddSingleton(map);
            containerBuilder.AddSingleton(_playerGlobalData);
            containerBuilder.AddSingleton(_loadingScene);
            containerBuilder.AddSingleton(_dialogEventDataList);
            //containerBuilder.AddSingleton(new AnimationTime());
            containerBuilder.AddSingleton(globalGame);
        }
    }
}