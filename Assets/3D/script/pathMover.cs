using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathMover : MonoBehaviour
{
    [SerializeField] Transform t1, t2;
    [SerializeField] Color c1, c2 = Color.white;
    [SerializeField] Transform movable;
    [SerializeField] float speed = 2;
    [SerializeField, Range(0, 1)] float startPoint = 0.5f;

    Vector3 nextTarget;
    void OnValidate()
    {
        movable.position = Vector3.Lerp(t1.position, t2.position, startPoint);
    }

    void Start()
    {
        Vector3 p1 = t1.position;
        Vector3 p2 = t2.position;

        // Vector3 p = startPoint * p2 + (1 - startPoint) * p1;

        Vector3 p = Vector3.Lerp(p1, p2, startPoint);


        nextTarget = t2.position;
        movable.position = p;
    }

    void Update()
    {
        movable.position =
            Vector3.MoveTowards(movable.position, nextTarget, speed * Time.deltaTime);

        if (movable.position == nextTarget)
        {
            //if(nextTarget == point1)
            //    nextTarget = point2;
            //else
            //    nextTarget = point1;

            nextTarget = nextTarget == t1.position ? t2.position : t1.position;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = c1;
        Gizmos.DrawSphere(t1.position, 0.2f);

        Gizmos.color = c2;
        Gizmos.DrawSphere(t2.position, 0.2f);

        Gizmos.color = Color.Lerp(c1,c2,startPoint);
        Gizmos.DrawLine(t1.position, t2.position);
    }
}
