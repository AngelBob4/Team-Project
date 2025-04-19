using Runner.Platforms;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.ScriptableObjects
{
    [CreateAssetMenu()]
    public class LocationType : ScriptableObject
    {
        public GameObject LastPlatformView;
        public StartPlatform StartPlatform;
        public List<Platform> PlatformVariants;
        public AudioClip AudioClip;
    }
}
