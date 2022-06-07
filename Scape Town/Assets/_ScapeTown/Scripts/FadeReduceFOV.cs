using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class FadeReduceFOV : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _ppv; 
    [SerializeField] private XRIDefaultInputActions _ia; 

    private void Start() {
        if (_ppv != null)
        {
            Debug.Log("We don't have it boys");
        }
    }

    private void OnEnable() {
        _ia.XRILeftHandLocomotion.Move.performed += ToggleOnVignette;
        _ia.XRILeftHandLocomotion.Move.canceled += ToggleOffVignette;
    }
    private void OnDisable() {
        _ia.XRILeftHandLocomotion.Move.performed -= ToggleOnVignette;
        _ia.XRILeftHandLocomotion.Move.canceled -= ToggleOffVignette;
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
    }
    public void ToggleOffVignette(InputAction.CallbackContext context)
    {
        ToggleVignette(false);
    }
}
