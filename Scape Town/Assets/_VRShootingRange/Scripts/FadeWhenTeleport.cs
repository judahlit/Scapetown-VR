using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FadeWhenTeleport : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private InputActionAsset actionAsset;

    //when teleport is trigger
    private bool teleportTrigger = false;

    
    void Start()
    {
        //teleportTrigger = the true or false of teleport button pressed from VR


        //teleportTrigger =
        //actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Select");
    }

    



    // Update is called once per frame
    void Update()
    {
        if (teleportTrigger)
        {
            Fade();
            teleportTrigger=false;
        }
    }

    

    private void Fade()
    {
        animator.SetTrigger("Start");

    }

    
}
