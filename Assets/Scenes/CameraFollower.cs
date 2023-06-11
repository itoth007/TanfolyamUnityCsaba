using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float distance = 10; // third person camera, first person, if distance almost 0
    public float verticalAngle = 60;
    public float horizontalAngle = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        FreshCamera();
    }
    void FreshCamera()
    {
        float verticalDistance = distance * Mathf.Sin(verticalAngle * Mathf.Deg2Rad);
        float horizontalDistance = distance * Mathf.Cos(verticalAngle * Mathf.Deg2Rad);

        float xDistance = horizontalDistance * Mathf.Sin(horizontalAngle * Mathf.Deg2Rad);
        float zDistance = horizontalDistance * Mathf.Cos(horizontalAngle * Mathf.Deg2Rad);

        //Vector3 distanceVector = new Vector3(0, verticalDistance, -horizontalDistance); // It can be plus
        Vector3 distanceVector = new Vector3(xDistance, verticalDistance, -zDistance);

        // If camera is not behind you
        //transform.position = target.position + distanceVector;

        //OR

        // If camera is behind you
        transform.position = target.position + target.TransformVector(distanceVector);

        transform.LookAt(target); 

        }
}
