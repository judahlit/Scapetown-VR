using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteAppear : MonoBehaviour
{
    [SerializeField]private Image numberImage;
    // Start is called before the first frame update
    
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Hands") {
            numberImage.enabled = true;
            Debug.Log("Testing 1");
        }
        else{
            Debug.Log("Testing 3");
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.CompareTag("Hands")) {
            numberImage.enabled = false;
            Debug.Log("Testing 2");
        }
    }
}
