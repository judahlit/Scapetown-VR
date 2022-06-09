using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawable : MonoBehaviour
{
    [SerializeField] GameObject saw;
    
    [SerializeField] int sawMaxCount;
    int sawCount;
    [SerializeField] Vector3 moveSpot;

    [SerializeField] GameObject uselessHalf;
    [SerializeField] GameObject puzzleHalf;

    [Header("Audio")]

    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip sawFirst;
    [SerializeField] AudioClip sawLast;

    // Start is called before the first frame update
    void Start()
    {
        sawCount = 0;
        saw = GameObject.Find("Hand_saw");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("triggered by: " + other.name);

        if (other.name == saw.name)
        {
            //Debug.Log("saw cut");
            if (sawCount < sawMaxCount)
            {
                sawCount++;
                this.transform.position += moveSpot;
                //Debug.Log("saw cut no: " + sawCount);
                if(sawCount % 2 == 0) {
                    audio.clip = sawFirst;
                    audio.Play();
                }
                else {
                    audio.clip = sawLast;
                    audio.Play();
                }
            }
            else
            {
                this.gameObject.SetActive(false);
                this.transform.parent.gameObject.SetActive(false);
                uselessHalf.gameObject.SetActive(true);
                puzzleHalf.gameObject.SetActive(true);
                //Debug.Log("sawn: " + sawCount);
            }

        }
    }
}
