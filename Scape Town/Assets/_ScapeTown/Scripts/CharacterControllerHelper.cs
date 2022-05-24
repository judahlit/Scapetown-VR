using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterControllerHelper : MonoBehaviour
{
    [SerializeField] private XROrigin _xrOrigin;
    [SerializeField] private CharacterController _cc;
    [SerializeField] private CharacterControllerDriver _ccDriver;

    // Start is called before the first frame update
    void Start()
    {
        _xrOrigin = GetComponent<XROrigin>();
        _cc = GetComponent<CharacterController>();
        _ccDriver = GetComponent<CharacterControllerDriver>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
    }
    
    /// <summary>
    /// Updates the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
    /// based on the camera's position.
    /// </summary>
    protected virtual void UpdateCharacterController()
    {
        if (_xrOrigin == null || _cc == null)
            return;

        var height = Mathf.Clamp(_xrOrigin.CameraInOriginSpaceHeight, _ccDriver.minHeight, _ccDriver.maxHeight);

        Vector3 center = _xrOrigin.CameraInOriginSpacePos;
        center.y = height / 2f + _cc.skinWidth;

        _cc.height = height;
        _cc.center = center;
    }

}
