using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public delegate void Notify();
    public event Notify ColorSwaped = delegate {};

    [SerializeField] private GameObject _target;
    [SerializeField] private Color _color1;
    [SerializeField] private Color _color2;

    private Material _targetRendererMaterial;
    
    public bool _selected;  

    private void Start() {
        _targetRendererMaterial = _target.GetComponent<Renderer>().material;
        _targetRendererMaterial.color = _color1;
        _selected = false;
    }

    public void SwapColor()
    {
        if (_selected == false)
        {
            _targetRendererMaterial.color = _color2;
            _selected = true;
        }
        else
        {
            _targetRendererMaterial.color = _color1;
            _selected = false;
        }

        ColorSwaped.Invoke();
    }
}
