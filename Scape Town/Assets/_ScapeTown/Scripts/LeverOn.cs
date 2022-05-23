using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOn : MonoBehaviour
{
    [SerializeField] GameObject lever;
    [SerializeField] GameObject moveObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == lever.name)
        {
            moveObject.transform.position += new Vector3(1, 0, 0);
            Debug.Log("On");
        }
        else
        {
            Debug.Log("not lever");
            Debug.Log(other.name);
        }
        
    }
}
