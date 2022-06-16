using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTransformPositionsInEditor : MonoBehaviour
{
    [SerializeField] private Transform[] _transforms;
    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        foreach(Transform curr in _transforms)
        {
            Gizmos.DrawSphere(curr.position, 0.05f);
        }
    }
}
