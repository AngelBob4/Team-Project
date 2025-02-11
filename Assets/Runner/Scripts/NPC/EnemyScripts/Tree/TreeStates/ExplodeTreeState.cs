using Unity.VisualScripting;
using UnityEngine;

namespace Runner.NonPlayerCharacters.StateMachine
{
    public class ExplodeTreeState : TreeState
    {
        protected readonly Animator Animator;

        private const string IsHitting = nameof(IsHitting);

        public ExplodeTreeState(TreeStateMachine treeStateMachine, Animator animator) : base(treeStateMachine)
        {
          Animator = animator;
        }

        public override void Enter()
        {
            Animator.SetBool(IsHitting, true);
         
        }

        public override void Exit()
        {
            Animator.SetBool(IsHitting, false);
        }

        public override void Update()
        {
            
        }

        private void Explode()
        {

        }
    }
}

