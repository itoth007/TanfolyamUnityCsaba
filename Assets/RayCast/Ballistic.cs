using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistic : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;

    [SerializeField] float startSpeed = 5f;
    [SerializeField] Vector3 gravity = new Vector3(0, -9.81f, 0);
    [SerializeField] float duration = 2f;
    [SerializeField] int drawEveryNPoint = 10;

    void OnValidate()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();
    }

    void Update() // a lövedéket azonban már rigidbody val kell csinálni
    {
        List<Vector3> points = new List<Vector3>();

        Vector3 position = transform.position;
        Vector3 velocity = transform.up * startSpeed;

        int index = 0;
        for (float t = 0; t < duration; t += Time.fixedDeltaTime)
        {
            velocity += gravity * Time.fixedDeltaTime;
            position += velocity * Time.fixedDeltaTime;

            if (index % drawEveryNPoint == 0)
                points.Add(position);

            index++;
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}
