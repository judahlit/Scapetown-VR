using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTeleport : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip tp;
    [SerializeField] AudioClip steps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TeleportSound() {
        audio.clip = tp;
        audio.Play();
    }
    public void stepsSound() {
        audio.clip = steps;
        audio.Play();
    }
}
