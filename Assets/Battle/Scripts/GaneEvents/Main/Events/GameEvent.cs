using UnityEngine;

namespace Events.Main.Events
{
    public abstract class GameEvent : MonoBehaviour
    {
        private const int Level = -1;

        public int DefaultLevel => Level;

        public abstract void StartEvent(int level = Level);
    }
}