namespace Runner.NonPlayerCharacters.StateMachine
{
    public abstract class TreeState
    {
        protected readonly TreeStateMachine TreeStateMachine;

        public TreeState(TreeStateMachine treeStateMachine)
        {
            TreeStateMachine = treeStateMachine;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
