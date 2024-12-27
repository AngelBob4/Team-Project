using Runner.Settings;
using UnityEngine;

namespace RunnerUI
{
    public class TestMenu : MonoBehaviour
    {
        [SerializeField] private EntryPoint _entryPoint;
        [SerializeField] private GameObject _testMenuView;

        public void NewGameButtonPressed()
        {
            // собрали карту
            // создали набор событии(бой,диалог,магазин)
            // собрали вьюшки для ранера и запустили:
            // Ранер: в зависимости от того в какой точке карты находится игрок, и к какому поинту идет передается вид СО
            // СО содержит:
            // музыку, вьюшки, количество жизней

            _entryPoint.InitAllSettingsForRunner();
            _testMenuView.SetActive(false);
        }
    }
}
