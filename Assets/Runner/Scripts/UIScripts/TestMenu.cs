using Runner.Settings;
using UnityEngine;

namespace Runner.UI
{
    public class TestMenu : MonoBehaviour
    {
        [SerializeField] private EntryPoint _entryPoint;
        [SerializeField] private GameObject _testMenuView;

        public void NewGameButtonPressed()
        {
            //1 - индекс СОшки, содержащей настройки сцены : музыку, вьюшки, врагов и т д (Пока их две: 0 - кладбище, 1 - лес)
            //2 - количество жизней
            //3 - количество платформ до финиша 
            //4 - количество масла в фонаре
            // ? деньги и энергия

            _entryPoint.InitAllSettingsForRunner(0, 7, 15, 4);
            _entryPoint.StartRunner();
            _testMenuView.SetActive(false);
        }
    }
}
