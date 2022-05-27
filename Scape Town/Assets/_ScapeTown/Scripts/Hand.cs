using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Animator _animator;
    private string _animatorGripParam = "Grip";

    private float _gripTarget = 0;
    private float _gripCurrent = 0;
    [SerializeField] private float _gripSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }

    internal void SetGrip(float value)
    {
        _gripTarget = value;
    }

    void AnimateHand()
    {
        if (_gripCurrent != _gripTarget)
        {
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * _gripSpeed);
            _animator.SetFloat(_animatorGripParam, _gripCurrent);
        }
    }
}
