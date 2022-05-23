using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadControl : MonoBehaviour
{
    [SerializeField] int correctCombination;
    public bool accessGranted = false;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(accessGranted == true) {
            //accessGranted = false;
        }
    }
    public bool CheckIfCorrect(int combination) {
        if(combination == correctCombination) {
            accessGranted = true;
        return true;
    }
    return false;
    }
}
