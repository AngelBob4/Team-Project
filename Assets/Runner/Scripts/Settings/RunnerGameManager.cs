using MainGlobal;
using Reflex.Attributes;
using UnityEngine;

namespace Runner.Settings
{
    public class RunnerGameManager : MonoBehaviour
    {
        [SerializeField] private EntryPoint _entryPoint;
        [SerializeField] private GameObject _testMenuView;

        private GlobalGame _globalGame;

        [Inject]
        private void Inject(GlobalGame globalGame)
        {
            _globalGame = globalGame;
        }

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {

            _entryPoint.InitAllSettingsForRunner(_globalGame.LocationRunnerTypes);

            _entryPoint.StartRunner();
            //_testMenuView.SetActive(false);
        }

        public void EndGame()
        {
            _globalGame.StartEvent();
        }
    }
}
