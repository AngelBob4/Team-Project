using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _transforms = new List<Transform>(); 

    public bool IsAllWindowsAreTurnedOff() 
    {
        foreach (Transform transforms in _transforms)
        {
            if (transforms.gameObject.activeSelf == true)
            {
                Debug.Log(transform.gameObject.name + " true");
                return false;
            }
        }
         
        return true;
    }

    public void TurnOffAlllWindows()
    {
        foreach (Transform transforms in _transforms)
        {
            transform.gameObject.SetActive(false);
        }
    }
}