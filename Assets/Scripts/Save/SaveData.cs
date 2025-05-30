using System.Collections.Generic;
using MainGlobal;
using MapSection.Models;
using Reflex.Attributes;
using UnityEngine;
using YG;

namespace MapSection
{
    public class SaveData : MonoBehaviour
    {
        //[SerializeField] InputField integerText;
        //[SerializeField] InputField stringifyText;
        //[SerializeField] Toggle[] booleanArrayToggle;
        private Map _map;
        private GlobalGame _globalGame;
        private PlayerGlobalData _playerGlobalData;

        [Inject]
        private void Inject(GlobalGame globalGame)
        {
            _globalGame = globalGame;
        }

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        [Inject]
        private void Inject(Map map)
        {
            _map = map;
        }

        // private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
        //private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

        private void Awake()
        {
            //if (YandexGame.SDKEnabled)
            // GetLoad();
        }

        public void Save()
        {
            //YandexGame.savesData.money = int.Parse(integerText.text);
            //YandexGame.savesData.newPlayerName = stringifyText.text.ToString();

            // for (int i = 0; i < booleanArrayToggle.Length; i++)
            //    YandexGame.savesData.openLevels[i] = booleanArrayToggle[i].isOn;

            YandexGame.savesData.Coins = _playerGlobalData.Coins.CurrentValue;
            YandexGame.savesData.LanternLight = _playerGlobalData.LanternLight.CurrentValue;
            YandexGame.savesData.HP = _playerGlobalData.HPBar.CurrentValue;
            YandexGame.savesData.Level = _globalGame.Level;

            //YandexGame.savesData.StructureCells = new()
            //{
            //    new CellStructure(_map.MapCells[0].NextAvailableCellsIndexes,_map.MapCells[0].Type,
            //    _map.MapCells[0],_map.MapCells[0].Position, _map.MapCells[0].Index )
            //};


            YandexGame.savesData.CurrentCell = _map.CurrentCell;
            YandexGame.savesData.CurrentCellIndex = _map.CurrentCell.Index;

            YandexGame.SaveProgress();
            print(YandexGame.savesData.Level);
        }

        public void Load() => YandexGame.LoadProgress();

        public void GetLoad()
        {
            //_playerGlobalData.InitOldPlayer(YandexGame.savesData.HP, YandexGame.savesData.Coins, YandexGame.savesData.LanternLight);
            //пока временно делаю загрузку из глобал гейм

            //integerText.text = string.Empty;
            //stringifyText.text = string.Empty;

            // integerText.placeholder.GetComponent<Text>().text = YandexGame.savesData.money.ToString();
            // stringifyText.placeholder.GetComponent<Text>().text = YandexGame.savesData.newPlayerName;

            // for (int i = 0; i < booleanArrayToggle.Length; i++)
            //    booleanArrayToggle[i].isOn = YandexGame.savesData.openLevels[i];
        }
    }
}