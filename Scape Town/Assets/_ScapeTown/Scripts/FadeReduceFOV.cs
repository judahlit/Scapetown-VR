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
    [SerializeField] private InputActionProperty _rightHandControls; 

    private void Start() {
        if (_ppv == null)
        {
            Debug.Log("We don't have it boys");
        }
    }

    private void Update() {
        Vector2 leftHandValue = _leftHandControls.action?.ReadValue<Vector2>() ?? Vector2.zero;
        Vector2 rightHandValue = _rightHandControls.action?.ReadValue<Vector2>() ?? Vector2.zero;

        Debug.Log(leftHandValue + " ... " + leftHandValue.ToString());
        if (leftHandValue.x != 0 && leftHandValue.y != 0 ||
            rightHandValue.x != 0 && rightHandValue.y != 0)
        {
            ToggleVignette(true);
        }
        else
        {
            ToggleVignette(false);
        }
    }

    public void ToggleVignette()
    {
        _ppv.enabled = !_ppv.enabled;
    }   
    public void ToggleVignette(bool newValue)
    {
        _ppv.enabled = newValue;
    }
}
