using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeTextColor : MonoBehaviour
{
    [SerializeField] List<TMP_Text> _list;
    [SerializeField] Color _targetColor;
    [SerializeField] Color _targetColorOutline;

    // Start is called before the first frame update
    void Start()
    {
        ChangeColor();
    }
    
    public void ChangeColor()
    {
        foreach(TMP_Text tar in _list)
        {
            tar.color = _targetColor;
            tar.outlineColor = _targetColorOutline;
        }
    }
}
