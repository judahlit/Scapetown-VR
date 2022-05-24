using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    [SerializeField] GameObject lever;
    [SerializeField] GameObject moveObject;
    [SerializeField] GameObject otherEnd;
    [SerializeField] Vector3 direction;
    bool usedLast;

    private void Start()
    {
        usedLast = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == lever.name)
        {
            if (!usedLast)
            {
                moveObject.transform.position += new Vector3(-1, 0, 0);
                Debug.Log("Off");
                usedLast = true;
                otherEnd.gameObject.GetComponent<LeverTrigger>().usedLast = false;
            }
            
        }
        else
        {
            Debug.Log("not lever");
            Debug.Log(other.name);
        }
    }
}
