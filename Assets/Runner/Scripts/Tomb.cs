using UnityEngine;
using Runner.PlayerController;

namespace Runner
{
    public class Tomb : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                print("Finish!!!");

            }
        }
    }
}
