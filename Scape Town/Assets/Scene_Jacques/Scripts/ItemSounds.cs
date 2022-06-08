using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSounds : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip itemGrab;
    public AudioClip itemDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Testing() {
        audio.clip = itemGrab;
        audio.Play();
    }

    public void TestingAlt() {
        audio.clip = itemDrop;
        audio.Play();
    }
}
