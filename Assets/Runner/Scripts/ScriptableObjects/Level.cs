using UnityEngine;

namespace Runner.ScriptableObjects
{
    [CreateAssetMenu()]
    public class Level : ScriptableObject
    {
        public int LevelNumber;
        public int PlatformsAmount;
        public int EnemiesAmount;
        public LocationType LocationType;
        public Color Color;
    }
}