using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follower : MonoBehaviour
{
    [SerializeField] float speed = 5; //speed = player's speed
    [SerializeField] Transform target; // Drag and drop, whom follows
    [SerializeField] float distance = 5; //magnitude
    [SerializeField] float cameraOffsetY = 3; // higher, than player
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 selfPoint = transform.position; //Camera - follower
        Vector3 targetPoint = target.position; // Player

        Vector3 dir = targetPoint - selfPoint;
        if (dir != Vector3.zero)
        {
            if (dir.magnitude > distance)
            {
                transform.rotation = Quaternion.LookRotation(dir); // nem kell normalizálni
                transform.position = Vector3.MoveTowards(selfPoint, targetPoint + new Vector3(0, cameraOffsetY, 0), speed * Time.deltaTime);
            }
        }
    }
}
