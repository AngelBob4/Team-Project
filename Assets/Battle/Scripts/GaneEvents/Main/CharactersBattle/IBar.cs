using System;
using UnityEngine;

namespace Events.Main.CharactersBattle
{
    public interface IBar
    {
        public event Action UpdatedBar;

        public bool IsEndlessBar { get; }

        public int CurrentValue { get; }
        public int MaxValue { get; }
    }
}
