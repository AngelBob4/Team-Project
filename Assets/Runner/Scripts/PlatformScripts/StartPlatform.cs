using Runner.Optimization;
using UnityEngine;

namespace Runner.Platforms
{
    public class StartPlatform : MonoBehaviour
    {
        [SerializeField] private MeshCombiner _meshCombiner;

        public void CombineMeshes()
        {
            _meshCombiner.CombineMeshes();
        }
    }
}