using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverGrabbable : MonoBehaviour
{
    public Transform handler;

    public void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;
    }
}
