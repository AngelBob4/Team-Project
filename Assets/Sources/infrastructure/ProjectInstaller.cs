using Events.Cards;
using Events.Main.Events.Dialog;
using MainGlobal;
using Reflex.Core;
using UnityEngine;

public class ProjectInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private CardDataList _startCardDataList;
    [SerializeField] private CardDataList _addCardDataListInDialogEvents;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        //PlayerBattleCharacterData _playerBattleCharacterData = new PlayerBattleCharacterData();
        PlayerGlobalData _playerGlobalData = new PlayerGlobalData(_startCardDataList);
        LoadingScene _loadingScene = new LoadingScene();
        DialogEventDataList _dialogEventDataList = new DialogEventDataList(_addCardDataListInDialogEvents);

        containerBuilder.AddSingleton(new Map());
        containerBuilder.AddSingleton(_playerGlobalData);
        containerBuilder.AddSingleton(_loadingScene);
        containerBuilder.AddSingleton(_dialogEventDataList);
       // containerBuilder.AddSingleton(_playerBattleCharacterData);
        containerBuilder.AddSingleton(new GlobalGame(_playerGlobalData, _loadingScene, _dialogEventDataList));
    }
}