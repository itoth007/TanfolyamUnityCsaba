using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPathmover : MonoBehaviour
{
    [SerializeField] Vector3[] points;
    [SerializeField] float speed = 2;
    int targetIndex;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[0];
        targetIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = points[targetIndex % points.Length];
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target)
        {
            targetIndex++;
            //if(targetIndex >= points.Length)
            //{
            //    targetIndex = 0;
            //}
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (var point in points)
        {
            Gizmos.DrawSphere(point, 0.2f);
        }
        for (var i = 0; i < points.Length; i++)
        {
            Vector3 p1 = points[i];
            int i2 = (i + 1)%points.Length;
            Vector3 p2 = points[i2];
            Gizmos.DrawLine(p1, p2);
        }
    }
}
