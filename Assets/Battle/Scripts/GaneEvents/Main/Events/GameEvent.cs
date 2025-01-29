using System;
using UnityEngine;

namespace Events.Main.Events
{
    public abstract class GameEvent : MonoBehaviour
    {
        public abstract event Action FinishedEvent;

        public abstract void StartEvent(int level);
    }
}
