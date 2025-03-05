using Runner.PlayerController;
using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    public class Soul : MonoBehaviour
    {
        [SerializeField] private int _soulsAmount;

        public int SoulsAmount => _soulsAmount;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
