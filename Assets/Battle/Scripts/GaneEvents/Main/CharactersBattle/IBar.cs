using System;

namespace Events.Main.CharactersBattle
{
    public interface IBar
    {
        public event Action UpdatedBar;
        public event Action<int> DamagBar;

        public bool IsEndlessBar { get; }

        public int CurrentValue { get; }
        public int MaxValue { get; }
    }
}