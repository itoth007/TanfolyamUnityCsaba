using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    //[SerializeField] Vector3 distanceVector; // h�tulr�l
    //[SerializeField] float verticalDistance=10;
    //[SerializeField] float horizontalDistance=15;
    [SerializeField] float distance = 10; // third person kamera, first person, ha distance 0-hoz k�zeli
    public float verticalAngle = 30;
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
        // c�lponthoz k�pesti vector
        // forg�st ez biztos�tja: target.TransformVector(distanceVector)
        //transform.position = target.position + target.TransformVector(distanceVector);//h�tulr�l
        float verticalDistance = distance * Mathf.Sin(verticalAngle * Mathf.Deg2Rad);
        float horizontalDistance = distance * Mathf.Cos(verticalAngle * Mathf.Deg2Rad);
        float xDistance = distance * Mathf.Sin(horizontalAngle * Mathf.Deg2Rad);
        float zDistance = distance * Mathf.Cos(horizontalAngle * Mathf.Deg2Rad);


        Vector3 distanceVector = new Vector3(xDistance, verticalDistance, zDistance);
        // itt is lehetne: target.TransformVector(distanceVector)
        transform.position = transform.position + distanceVector;

        transform.LookAt(target); // h�tulr�l
    }
}
