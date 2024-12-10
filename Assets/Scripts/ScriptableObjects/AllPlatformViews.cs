using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AllPlatformViews : ScriptableObject
{
    public GameObject StartPlatformView;
    public GameObject LastPlatformView;
    public List<Platform> PlatformVariants;
}
