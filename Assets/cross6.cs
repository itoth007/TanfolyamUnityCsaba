using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross6 : MonoBehaviour
{
    [SerializeField] float lineLength;
    [SerializeField] Space space; //Word oe Self
    [SerializeField] Vector3 axisX = Vector3.right;
    [SerializeField] Vector3 axisY = Vector3.up;
    [SerializeField] Vector3 axisZ = Vector3.forward;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnDrawGizmos()
    {
        D(axisX, Color.red);
        D(axisY, Color.green);
        D(axisZ, Color.blue);
    }
    private void D(Vector3 axis, Color color)
    {
        Vector3 center = transform.position; // localPosition;
        Vector3 a = center + transform.TransformDirection(axis) * lineLength;
        Vector3 b = center - transform.TransformDirection(axis) * lineLength;

        Gizmos.color = color;
        Gizmos.DrawLine(a, b);
        Gizmos.DrawSphere(a, 0.2f);
    }
}
