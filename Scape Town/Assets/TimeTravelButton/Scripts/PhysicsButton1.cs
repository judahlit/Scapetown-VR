using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton1 : MonoBehaviour
{
    // Serialized floats that store the threshold that has to be met to identify a button press. And the deadzone that ignores accidental input.
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;
    [SerializeField] GameObject spawnable;
    [SerializeField] GameObject spawnLocation;

    // Not used in prefab version.
    /*
    public GameObject house;
    public GameObject house2;
    public GameObject house3;
    
    */
    public GameObject textToShow;
    // The material that the skybox changes to when the player presses the button.
    public Material skyboxMat;

    // Variables to store whether or not the butten is pressed, what the start position is of the button as a vector and
    // the configurable joint used to make the button physics work.
    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    // Eventsystems.
    public UnityEvent onPressed, onReleased;

    void Start()
    {
        // When the script is first loaded get the starting position of the button, and the configurable joint.
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        // Constantly check whether or not the threshold has been met and if the button hasn't already been pressed.
        // If the button has not been pressed and the threshold is met, the Pressed method gets executed.
        // Otherwise the Released method gets executed.
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        // Float used to store the distance traveled of the button.
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

        GameObject spawned = Instantiate(spawnable);
        spawned.GetComponent<Transform>().position = spawnLocation.transform.position;



        /*
        var cubeRenderer1 = house.GetComponent<Renderer>();
        cubeRenderer1.material.SetColor("_Color", Color.yellow);

        var cubeRenderer2 = house2.GetComponent<Renderer>();
        cubeRenderer2.material.SetColor("_Color", Color.red);

        var cubeRenderer3 = house3.GetComponent<Renderer>();
        cubeRenderer3.material.SetColor("_Color", Color.gray);
        
        */
        //textToShow.SetActive(true);
        //RenderSettings.skybox = skyboxMat;
        //RenderSettings.fog = true;
        

    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Button Released");
    }
}
