using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPathmover : MonoBehaviour
{
    [SerializeField] Vector3[] points;
    [SerializeField] float speed = 2;
    [SerializeField] LineRenderer lineRenderer;

    void OnValidate()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        UpdateLineRenderer();
    }


    int targetIndex;

    private void Start()
    {
        transform.position = points[0];
        targetIndex = 1;
    }

    void Update()
    {
        Vector3 target = points[targetIndex];
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            targetIndex++;

            if (targetIndex >= points.Length)
                targetIndex = 0;
        }

        UpdateLineRenderer();
    }

    void UpdateLineRenderer()
    {
        if (lineRenderer == null)
            return;

        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        foreach (var point in points)
        {
            Gizmos.DrawSphere(point, 0.2f);
        }

        for (int i = 0; i < points.Length; i++)
        {
            Vector3 p1 = points[i];
            int i2 = (i + 1) % points.Length;
            Vector3 p2 = points[i2];
            Gizmos.DrawLine(p1, p2);
        }

    }
}
