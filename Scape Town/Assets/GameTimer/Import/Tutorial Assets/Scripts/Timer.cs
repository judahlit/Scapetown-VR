using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    [Header("Time Values")]
    [Range(0,60)]
    public int seconds;
    [Range(0, 60)]
    public int minutes;
    [Range(0, 60)]
    public int hours;

    public Color fontColor;

    public bool showMilliseconds;

    private float currentSeconds;
    private int timerDefault;

    void Start()
    {
        // Global var for color of font
        timerText.color = fontColor;
        // Set default timer to 0
        timerDefault = 0;
        // Apply basic time, minute and hour logic to update the timer default value.
        timerDefault += (seconds + (minutes * 60) + (hours * 60 * 60));
        currentSeconds = timerDefault;
    }

    void Update()
    {
        // If time has ran out, execute the TimeUp method.
        if((currentSeconds -= Time.deltaTime) <= 0)
        {
            TimeUp();
        }
        // Otherwise update the timer text with the correct value.
        else
        {
            if(showMilliseconds)
                timerText.text = TimeSpan.FromSeconds(currentSeconds).ToString(@"hh\:mm\:ss\:fff");
            else
                timerText.text = TimeSpan.FromSeconds(currentSeconds).ToString(@"hh\:mm\:ss");
        }
    }

    private void TimeUp()
    {
        // Execute after time has run out.

        Debug.Log("Time's up!");
        
        if (showMilliseconds)
            timerText.text = "00:00:00:000";
        else
            timerText.text = "00:00:00";
    }
}
