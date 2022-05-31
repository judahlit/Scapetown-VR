using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] public KeyPadControl keyPad;
    [SerializeField] public Text display;
    // Start is called before the first frame update
    void Start()
    {
        display = GameObject.FindGameObjectWithTag("Display").GetComponentInChildren<Text>();
        display.text = "";

        //keyPad = GameObject.FindGameObjectWithTag("Keypad").GetComponent<KeyPadControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KeyPadButton")
        {
            var key = other.GetComponentInChildren<Text>();
            if (key != null)
            {
                var keyFeedback =
other.gameObject.GetComponent<Buttons>();

                if (key.text == "B")
                {
                    if (display.text.Length > 0)
                    {
                        display.text = display.text.Substring(0, display.text.Length - 1);
                    }
                }
                else if (key.text == "S")
                {
                    var accessGranted = false;
                    bool onlyNumbers = int.TryParse(display.text, out int value);
                    if (onlyNumbers == true && display.text.Length > 0)
                    {
                        accessGranted = keyPad.CheckIfCorrect(System.Convert.ToInt32(display.text));
                    }
                    if (accessGranted == true)
                    {
                        display.text = "Start";
                    }
                    else
                    {
                        display.text = "Retry";
                    }
                }
                else if (key.text == "R")
                {
                    display.text = "";
                }
                else
                {
                    bool onlyNumbers = int.TryParse(display.text, out int value);
                    if (onlyNumbers == false)
                    {
                        display.text = "";
                    }
                    if (display.text.Length < 4)
                    {
                        display.text += key.text;
                    }
                    keyFeedback.keyHit = true;
                }
            }
        }
    }
}