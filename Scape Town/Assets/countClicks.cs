using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countClicks : MonoBehaviour
{
    public int currentClick;

    public int firstDigit;
    public int secondDigit;
    public int thirdDigit;
    public int lastDigit;

    public void Clicked()
    {
        currentClick++;
    }

    void Update()
    {

    }
}
