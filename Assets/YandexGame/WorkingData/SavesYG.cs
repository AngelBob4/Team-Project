
using Events.Cards;
using MapSection.Models;
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        //public int money = 1;                       // Можно задать полям значения по умолчанию
        //public string newPlayerName = "Hello!";
        //public bool[] openLevels = new bool[3];

        // Ваши сохранения
        public bool IsSave;
        public int Coins;
        public int LanternLight;
        public int HP;
        public int MaxHP;
        public int Level = 1;
        public List<CardData> CardDataList;
        public List<MapCellData> MapCellsData;
        public Map Map;


        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива
            IsSave = false;
            //openLevels[1] = true;
        }
    }
}
