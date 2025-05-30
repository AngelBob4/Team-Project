using Events.Cards;
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

        [Inject]
        private void Inject(GlobalGame globalGame, PlayerGlobalData playerGlobalData, Map map)
        {
            _globalGame = globalGame;
            _playerGlobalData = playerGlobalData;
            _map = map;
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

            YandexGame.savesData.CardDataList = new List<CardData>();
            foreach (CardData cardData in _playerGlobalData.CardDataList)
            {
                YandexGame.savesData.CardDataList.Add(cardData);
            }
            
            YandexGame.savesData.MapCellsData = new List<MapCellData>();
            foreach (MapCell mapCell in _map.MapCells)
            {
                YandexGame.savesData.MapCellsData.Add(new MapCellData(mapCell));
            }
            

            YandexGame.SaveProgress();
            print(YandexGame.savesData.Level);
        }
    }
}