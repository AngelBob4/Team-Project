using System.Collections.Generic;
using UnityEngine;

namespace Runner.Optimization
{
    public class MeshCombiner : MonoBehaviour
    {
        [SerializeField] private List<MeshFilter> _sourceMeshFilters;
        [SerializeField] private MeshFilter _filter;
        [SerializeField] private Transform _allMeshes;
        
        private void Start()
        {
           // CombineMeshes();
           // print("COMBINED");
        }

        public  void CombineMeshes()
        {
            var combine = new CombineInstance[_sourceMeshFilters.Count];

            for (int i = 0; i < _sourceMeshFilters.Count; i++)
            {
                combine[i].mesh = _sourceMeshFilters[i].sharedMesh;
                combine[i].transform = _sourceMeshFilters[i].transform.localToWorldMatrix;
                _sourceMeshFilters[i].gameObject.SetActive(false);
            }

            Mesh mesh = new Mesh();
            mesh.CombineMeshes(combine);
            _filter.mesh = mesh;
            transform.gameObject.SetActive(true);

            print("Combined");
        }
    }
}
