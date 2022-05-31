using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0;

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
