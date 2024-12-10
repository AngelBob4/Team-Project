using UnityEngine;
using PlayerController;
public class Tomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Time.timeScale = 0.0f;
            print("Finish!!!");
        }
    }
}
