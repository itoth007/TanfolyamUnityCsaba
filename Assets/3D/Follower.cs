using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Follower : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 selfPoint = transform.position;
        Vector3 targetPoint = target.position;

        Vector3 dir = targetPoint - selfPoint;
        if (dir != Vector3.zero)
        {
            //Vector3 dir = targetPoint - selfPoint; ////////// Ehelyett csináltuk alább
            //dir.Normalize();
            //Vector3 velocity = dir * speed;
            //transform.position += velocity * Time.deltaTime;
       //     transform.position = Vector3.MoveTowards(selfPoint, targetPoint, speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(dir); // Default a 2. paraméter Vector3.Up - Enemy befordul a player felé
        }
    }
}
