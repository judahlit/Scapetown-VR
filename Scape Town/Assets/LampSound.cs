using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSound : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip lampSound;
    // Start is called before the first frame update
    void Start()
    {
        audio.clip = lampSound;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
