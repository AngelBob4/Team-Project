using Runner.Settings;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerAnimations : MonoBehaviour
    {
        private const string Run = nameof(Run);
        private const string Die = nameof(Die);

        [SerializeField] private Animator _animator;
        [SerializeField] private EntryPoint _entryPoint;

        private void Update()
        {
            if (_entryPoint.IsRunnerStarted)
            {
                _animator.SetBool(Run, true);
            }
        }

        public void SetDeathAnimation()
        {
            _animator.SetTrigger(Die);
        }
    }
}
