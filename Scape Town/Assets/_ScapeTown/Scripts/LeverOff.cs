using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOff : MonoBehaviour
{
    [SerializeField] GameObject lever;
    [SerializeField] GameObject moveObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == lever.name)
        {
            moveObject.transform.position += new Vector3(-1, 0, 0);
            Debug.Log("Off");
        }
        else
        {
            Debug.Log("not lever");
            Debug.Log(other.name);
        }
    }
}
