using MainGlobal;
using Reflex.Attributes;
using Runner.Settings.StateMachine;
using UnityEngine;

namespace Runner.Settings
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private EntryPoint _entryPoint;

        private LevelStateMachine _levelStateMachine;
        private PlayerGlobalData _playerGlobalData;

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        private void Awake()
        {
            _levelStateMachine = new LevelStateMachine();
            _levelStateMachine.AddState(new InitializeLevelState(_levelStateMachine,_entryPoint));
            _levelStateMachine.AddState(new GameOverLevelState(_levelStateMachine));

            _levelStateMachine.SetState<InitializeLevelState>();
        }

        private void OnEnable()
        {
            _playerGlobalData.Died += Die;
        }

        private void OnDisable()
        {
            _playerGlobalData.Died -= Die;
        }

        private void Die()
        {
            _levelStateMachine.SetState<GameOverLevelState>();
        }
    }
}
