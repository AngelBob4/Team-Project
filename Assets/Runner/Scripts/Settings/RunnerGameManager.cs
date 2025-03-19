using UnityEngine;

namespace Runner.Settings
{
    public class RunnerGameManager : MonoBehaviour
    {
        [SerializeField] private EntryPoint _entryPoint;
        [SerializeField] private GameObject _testMenuView;

        public void StartGame()
        {
            _entryPoint.InitAllSettingsForRunner(Enums.LocationTypes.Forest);
            _entryPoint.StartRunner();
            _testMenuView.SetActive(false);
        }

        public void EndGame()
        {

        }
    }
}
