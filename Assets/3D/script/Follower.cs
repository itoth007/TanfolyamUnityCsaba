using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Follower : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform target; // Drag and drop, whom follows
    [SerializeField] AnimationCurve speedOverDistance;
     // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 selfPoint = transform.position; //Enemy - follower
        Vector3 targetPoint = target.position; // Player

        float distance = Vector3.Distance(selfPoint, targetPoint);
        float speedMultiplier = speedOverDistance.Evaluate(distance);
        float step = speed * speedMultiplier * Time.deltaTime;
        Vector3 dir = targetPoint - selfPoint;
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir); // nem kell normalizálni
            transform.position = Vector3.MoveTowards(selfPoint, targetPoint, step);
        }
    }
}
