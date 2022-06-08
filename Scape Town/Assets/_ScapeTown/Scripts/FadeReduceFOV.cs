using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class FadeReduceFOV : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _ppv; 
    [SerializeField] private Renderer _handRenderer; 
    [SerializeField] private XRIDefaultInputActions _ia; 
    [SerializeField] private InputActionProperty _leftHandControls; 

    private void Start() {
        if (_ppv == null)
        {
            Debug.Log("We don't have it boys");
        }
    }

    private void Update() {
        Vector2 leftHandValue = _leftHandControls.action?.ReadValue<Vector2>() ?? Vector2.zero;

        Debug.Log(leftHandValue + " ... " + leftHandValue.ToString());
        if (leftHandValue.x != 0 && leftHandValue.y != 0)
        {
            ToggleVignette(true);
        }
        else
        {
            ToggleVignette(false);
        }
    }

    private void OnEnable() {
        _leftHandControls.action.performed += ToggleOnVignette;
        _leftHandControls.action.canceled += ToggleOffVignette;
    }
    private void OnDisable() {
        _leftHandControls.action.performed -= ToggleOnVignette;
        _leftHandControls.action.canceled -= ToggleOffVignette;
    }

    public void ToggleVignette()
    {
        _ppv.enabled = !_ppv.enabled;
    }   
    public void ToggleVignette(bool newValue)
    {
        _ppv.enabled = newValue;
    }
    public void ToggleOnVignette(InputAction.CallbackContext context)
    {
        ToggleVignette(true);
        TurnHandGreen();
    }
    public void ToggleOffVignette(InputAction.CallbackContext context)
    {
        ToggleVignette(false);
        TurnHandRed();
    }

    public void TurnHandGreen()
    {
        _handRenderer.material.color = new Color(0, 255, 0, 1);
    }
    public void TurnHandRed()
    {
        _handRenderer.material.color = new Color(255, 0, 0, 1);
    }
}
