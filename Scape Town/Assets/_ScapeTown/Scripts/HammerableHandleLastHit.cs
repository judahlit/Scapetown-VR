using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hammerable))]
public class HammerableHandleLastHit : MonoBehaviour
{
    [SerializeField] private Hammerable _ham;
    [SerializeField] private GameObject _enableTarget;

    private void Start() {
        if (_ham == null) _ham = gameObject.GetComponent<Hammerable>();
    }
    private void OnEnable() {
        _ham.LastHit += EnableObject;
    }
    private void OnDisable() {
        _ham.LastHit -= EnableObject;
    }

    void EnableObject()
    {
        _enableTarget.SetActive(true);
    }
}