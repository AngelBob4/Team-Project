using Runner.Platforms;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.ScriptableObjects
{
    [CreateAssetMenu()]
    public class AllRunnerSettings : ScriptableObject
    {
        public GameObject StartPlatformView;
        public GameObject LastPlatformView;
        public List<Platform> PlatformVariants;
        public AudioClip AudioClip;
    }
}
