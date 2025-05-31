using Events.Cards;
using Events.Main.Events.Dialog;
using Events.Main.Events.Dialog.Instance;
using MainGlobal;
using MapSection.Models;
using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace MapSection
{
    public class Saves : MonoBehaviour
    {
        private GlobalGame _globalGame;
        private PlayerGlobalData _playerGlobalData;
        private Map _map;
        private DialogEventDataList _dialogEventDataList;

        [Inject]
        private void Inject(GlobalGame globalGame, PlayerGlobalData playerGlobalData, Map map, DialogEventDataList dialogEventDataList)
        {
            _globalGame = globalGame;
            _playerGlobalData = playerGlobalData;
            _map = map;
            _dialogEventDataList = dialogEventDataList;
        }

        private void Awake()
        {
           // if (YandexGame.SDKEnabled)
              //  GetLoad();
        }

        public void Save()
        {
            YandexGame.savesData.IsSave = true;
            YandexGame.savesData.Coins = _playerGlobalData.Coins.CurrentValue;
            YandexGame.savesData.LanternLight = _playerGlobalData.LanternLight.CurrentValue;
            YandexGame.savesData.HP = _playerGlobalData.HPBar.CurrentValue;
            YandexGame.savesData.MaxHP = _playerGlobalData.HPBar.MaxValue;
            YandexGame.savesData.Level = _globalGame.Level;
            
            YandexGame.savesData.dialogEventIndexs = _dialogEventDataList.GetIndexDialogEvents();

            YandexGame.savesData.CardDataSaveList.Clear();
            foreach (CardData cardData in _playerGlobalData.CardDataList)
            {
                YandexGame.savesData.CardDataSaveList.Add(new CardDataSave(cardData));
            }

            YandexGame.savesData.IndexCurrentCell = _map.IndexCurrentCell;

            YandexGame.savesData.MapCellsData.Clear();
            foreach (MapCell mapCell in _map.MapCells)
            {
                YandexGame.savesData.MapCellsData.Add(new MapCellData(mapCell));
            }

            YandexGame.SaveProgress();
        }
    }
}