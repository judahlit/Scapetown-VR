using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] float _speed;

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, _speed * Time.deltaTime, 0);
    }
}
