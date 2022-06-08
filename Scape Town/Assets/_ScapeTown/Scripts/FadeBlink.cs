using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlink : MonoBehaviour
{
    [SerializeField] private Image _img;

    private float _fadeStatus = 0; 
    public bool _isTeleportationMoment = false; // Used to detect when is the right moment to teleport.
    public bool _fadingInProcess = false;

    public void Blink(float initialDelay, float fadeoutDuration, float fadeinDuration)
    {
        if (_fadingInProcess == false)
        {
            StartCoroutine(BlinkCoroutine(initialDelay, fadeoutDuration, fadeinDuration));
        }

    }

    private IEnumerator BlinkCoroutine(float initialDelay, float fadeoutDuration, float fadeinDuration)
    {
        _fadingInProcess = true;
        yield return new WaitForSeconds(initialDelay);

        // fade in
        while(_fadeStatus < 1)
        {
            _fadeStatus += 1 * 1000 / fadeoutDuration * Time.deltaTime;
            _img.color = new Color(_img.color.r, _img.color.g, _img.color.b, _fadeStatus);
            yield return new WaitForEndOfFrame();
        }
        _fadeStatus = 1;


        // Let know
        _isTeleportationMoment = true;
        yield return new WaitForEndOfFrame();
        _isTeleportationMoment = false;

        // fade out
        while(_fadeStatus > 0)
        {
            _fadeStatus -= 1 * 1000 / fadeinDuration * Time.deltaTime;
            _img.color = new Color(_img.color.r, _img.color.g, _img.color.b, _fadeStatus);
            yield return new WaitForEndOfFrame();
        }
        _fadeStatus = 0;

        _fadingInProcess = false;
    }
    
}
