using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    /*
    public GameObject house;
    public GameObject house2;
    public GameObject house3;
    

    public GameObject textToShow;

    */

    public Material skyboxMat;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("Button Pressed");

        /*
        var cubeRenderer1 = house.GetComponent<Renderer>();
        cubeRenderer1.material.SetColor("_Color", Color.yellow);

        var cubeRenderer2 = house2.GetComponent<Renderer>();
        cubeRenderer2.material.SetColor("_Color", Color.red);

        var cubeRenderer3 = house3.GetComponent<Renderer>();
        cubeRenderer3.material.SetColor("_Color", Color.gray);
        textToShow.SetActive(true);
        */

        RenderSettings.skybox = skyboxMat;
        RenderSettings.fog = true;
        

    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Button Released");
    }
}
