using System.Collections.Generic;
using UnityEngine;

namespace Runner.ScriptableObjects
{
    [CreateAssetMenu()]
    public class Advices : ScriptableObject
    {
        public List<string> EducationAdvices = new List<string>();
    }
}
