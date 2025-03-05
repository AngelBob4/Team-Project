using Runner.NonPlayerCharacters.StateMachine;
using Runner.Platforms;
using Runner.PlayerController;
using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    public class EvilTree : MonoBehaviour
    {
        [SerializeField] private GameObject _demon;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private Platform _platform;
        [SerializeField] private float _speed;

        private TreeStateMachine _treeStateMachine;

        private void OnEnable()
        {
            _treeStateMachine = new TreeStateMachine();

            _treeStateMachine.AddState(new IdleTreeState(_treeStateMachine));
            _treeStateMachine.AddState(new SendBotTreeState(_treeStateMachine, _demon.transform, _speed,_rigidbody));
            _treeStateMachine.AddState(new ExplodeTreeState(_treeStateMachine, _animator));

            _treeStateMachine.SetState<IdleTreeState>();

            _platform.PlayerSteppedOnPlatform += OnPlayerSteppedOnPlatform;
            _platform.PlayerSteppedOutOfThePlatform += OnPlayerSteppedOutOfThePlatform;
        }

        private void OnDisable()
        {
            _platform.PlayerSteppedOnPlatform -= OnPlayerSteppedOnPlatform;
            _platform.PlayerSteppedOutOfThePlatform -= OnPlayerSteppedOutOfThePlatform;
        }

        private void Update()
        {
            _treeStateMachine?.Update();
        }

        private void OnPlayerSteppedOnPlatform(Player player)
        {         
            _treeStateMachine.SetState<SendBotTreeState>();
        }

        private void OnPlayerSteppedOutOfThePlatform(Player player)
        {
            _treeStateMachine.SetState<IdleTreeState>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Player player))
            {
                _treeStateMachine.SetState<ExplodeTreeState>();
            }
        }
    }
}
