using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _targetPosition;

    public void StartBtn ()
    {
        //SceneManager.LoadScene("ScapeTown");
        _player.position = _targetPosition;
    }
}
