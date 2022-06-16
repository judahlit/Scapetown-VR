using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammerable : MonoBehaviour
{
    public delegate void Notify();
    public event Notify LastHit;


    [SerializeField] GameObject hammer;
    [SerializeField] GameObject hammerable;
    [SerializeField] GameObject screwSpot;
    int hitCount;
    [SerializeField] int maxHits;
    [SerializeField] float moveDist;

    [Header("Audio")]
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip firstHit;
    [SerializeField] AudioClip lastHit;
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
        hammer = GameObject.Find("Hammer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("triggered by: "+other.name);
        
        if (other.transform.parent.name == hammer.name)//hit by a child of the hammer
        {
            //Debug.Log("hammer hit");
            if (hitCount < maxHits)
            {
                hitCount++;
                hammerable.transform.position += new Vector3(0, moveDist, 0);
                Debug.Log("hit no: "+hitCount);
                if(hitCount < maxHits){
                    // Consecutive hits
                    audio.clip = firstHit;
                    audio.Play();
                }
                else {
                    // Last hit
                    LastHit.Invoke();
                    audio.clip = lastHit;
                    audio.Play();
                    screwSpot.gameObject.SetActive(false);
                }
            }
            else
            {
                //Debug.Log("screw is in");
            }

        }
    }
}
