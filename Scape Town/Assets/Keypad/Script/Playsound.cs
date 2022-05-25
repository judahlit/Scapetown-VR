using UnityEngine;
using System.Collections;

public class Playsound : MonoBehaviour 

{
	public GameObject clickCounter;
	public int[] enteredCode;
	public int btnClick;
	public int thisBtn;

	public int comb1 = 5;
	public int comb2 = 2;
	public int comb3 = 7;
	public int comb4 = 9;

	public bool isGreen;

	public int firstDigit;
	public int secondDigit;
	public int thirdDigit;
	public int lastDigit;

	public void Clicky (){
		clickCounter.gameObject.GetComponent<countClicks>().Clicked();

		if (clickCounter.gameObject.GetComponent<countClicks>().currentClick == 1)
        {
			Debug.Log("First button =" + thisBtn);
			clickCounter.gameObject.GetComponent<countClicks>().firstDigit = thisBtn;
			firstDigit = thisBtn;
		}
		else if (clickCounter.gameObject.GetComponent<countClicks>().currentClick == 2)
        {
			Debug.Log("Second button =" + thisBtn);
			clickCounter.gameObject.GetComponent<countClicks>().secondDigit = thisBtn;
			secondDigit = thisBtn;
		}
		else if (clickCounter.gameObject.GetComponent<countClicks>().currentClick == 3)
        {
			Debug.Log("Third button =" + thisBtn);
			clickCounter.gameObject.GetComponent<countClicks>().thirdDigit = thisBtn;
			thirdDigit = thisBtn;
		}
        else if(clickCounter.gameObject.GetComponent<countClicks>().currentClick == 4)
        {
			Debug.Log("Final button =" + thisBtn);
			clickCounter.gameObject.GetComponent<countClicks>().lastDigit = thisBtn;
			lastDigit = thisBtn;
			//Debug.Log("Final combination entered:" + clickCounter.gameObject.GetComponent<countClicks>().firstDigit + clickCounter.gameObject.GetComponent<countClicks>().secondDigit + clickCounter.gameObject.GetComponent<countClicks>().thirdDigit + clickCounter.gameObject.GetComponent<countClicks>().lastDigit);
		}

        if (isGreen)
        {
            if (clickCounter.gameObject.GetComponent<countClicks>().firstDigit == comb1 && clickCounter.gameObject.GetComponent<countClicks>().secondDigit == comb2 && clickCounter.gameObject.GetComponent<countClicks>().thirdDigit == comb3 && clickCounter.gameObject.GetComponent<countClicks>().lastDigit == comb4)
            {
				Debug.Log("Correct");
            }
            else { 
				Debug.Log("Incorrect");
            }
        }
		
		GetComponent<AudioSource>().Play();
	}


}
