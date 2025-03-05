using UnityEngine;

namespace Runner.NonPlayerCharacters.StateMachine
{
    public class SendBotTreeState : TreeState
    {
        private Vector3 _offset = new Vector3(0, 4f, 0);

        protected readonly Rigidbody RB;
        protected readonly Transform Transform;
        protected readonly float Speed;

        public SendBotTreeState(TreeStateMachine treeStateMachine, Transform transform, float speed, Rigidbody rB) : base(treeStateMachine)
        {
            Transform = transform;
            Speed = speed;
            RB = rB;
        }

        public override void Enter()
        {
            ChangeDemonRigidbodySettings(false);
            Transform.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            ChangeDemonRigidbodySettings(true);
            Transform.gameObject.SetActive(false);
            Transform.position = Transform.parent.position + _offset;
        }

        public override void Update()
        {
            Move();
        }

        private void Move()
        {
            Transform.position += Transform.forward * Speed * Time.deltaTime;
        }

        private void ChangeDemonRigidbodySettings(bool isTrue)
        {
            RB.isKinematic = isTrue;
        }
    }
}