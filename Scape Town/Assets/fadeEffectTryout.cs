using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeEffectTryout : MonoBehaviour
{
    public bool teleported = false;


    //public Animator transition;
    //transition.SetTrigger(Start);

    //Caching the transform for better performance. It's best to always do this.
    public Transform _transform;

    public fadeEffectTryout destination;

    //Create a GameObject in your scene and set it's position to 0.5,0.5,0, then add a GUItexture and add a texture to it.
    //Set the color to whatever you want the teleport color to be, and the alpha will be handled by this script.
    public UnityEngine.UI.Image fadeTexture;

    //Lerping speed for the fade out.
    public float fadeInSpeed;

    //This defines the offset for the teleported oject to be at when teleporting.
    public Vector3 offset;

    public AudioClip soundEffect;

    void Start()
    {
        _transform = transform;
    }

    void Update()
    {
        //Get the original color, modify it's alpha, then send it back to fadeTexture.
        Color oldColor = fadeTexture.color;

        oldColor.a = Mathf.Lerp(oldColor.a, 0, fadeInSpeed);

        fadeTexture.color = oldColor;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
        {
            if (!teleported)
            {
                destination.teleported = true;

                Color oldColor = fadeTexture.color;
                //Setting the alpha to 1 causes a flash effect.
                oldColor.a = 3;
                fadeTexture.color = oldColor;
                c.gameObject.transform.position = destination._transform.position + offset;

            }

        }
    }



    void OnTriggerExit(Collider c)
    {

        if (c.CompareTag("Player"))
        {
            teleported = false;

        }
    }

}
