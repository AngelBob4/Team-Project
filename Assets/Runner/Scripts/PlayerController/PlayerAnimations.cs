using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerAnimations : MonoBehaviour
    {
        private const string Run = nameof(Run);
        private const string Die = nameof(Die);

        [SerializeField] private Animator _animator;

        public void SetRunAnimation()
        {
            _animator.SetTrigger(Run);
        }

        public void SetDeathAnimation()
        {
            _animator.SetTrigger(Die);
        }
    }
}
