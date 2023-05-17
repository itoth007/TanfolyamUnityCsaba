using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class RotateTest : MonoBehaviour
{
    [SerializeField] float angleSpeed = 90f;
    List<Transform> children = new List<Transform>();
    float angleStep = 0f;
    Vector3 axis;
    [SerializeField] Transform myCamera;
    [SerializeField] Vector3 distanceOffset = new Vector3(0, -4, 10); //hátulról
    [SerializeField] Vector3 rotationOffset = new Vector3(20, 0, 0);
    //[SerializeField] Vector3 distanceOffset = new Vector3(-10, -4, 0); Jobb oldalról merõlegesen
    //[SerializeField] Vector3 rotationOffset = new Vector3(20, -90, 0);
    //[SerializeField] Vector3 distanceOffset = new Vector3(0, -4, -10); szembõl feléd
    //[SerializeField] Vector3 rotationOffset = new Vector3(20, 180, 0);
    [SerializeField] float smoothSpeed = 0.125f; // Ha magas a szám, akkor olyan, mintha nem is lenne smooth, fixen látjuk a "pilótát" a pozícióban

    [SerializeField] Vector3 rotationVectorA = new Vector3(30, 60, 90);
    [SerializeField] Vector3 rotationVectorB = new Vector3(10, 20, 30);


    // Start is called before the first frame update
    void Start()
    { // ezt meg lehetne spórolni, lásd lentebb a kommentet
        var childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            children.Add(transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //LocatRotationChild1(); // Vector3 - rotate
        //LocatRotationChild2(); // float numbers - rotate
        //LocateRotationAroundTheParentY1(); // parent and chiled rotate together according to parent Y
        //LocateRotationAroundTheParentY2(); // only chiled rotates according to parent Y
        //LocateRotationAroundTheParentY3(); // parent rotates between local x and z 45 degrees
        //CameraFlollow(); // camera somewhere
        Examples();
    }
    void LocatRotationChild1() // Vector3 - rotate
    {
        angleStep = angleSpeed * Time.deltaTime;
        foreach (var child in children)
        {
            axis = new Vector3(0, angleStep, 0);
            child.Rotate(axis, Space.Self); // itt lehet Space.World
        }
    }
    void LocatRotationChild2() // float numbers - rotate
    {
        angleStep = angleSpeed * Time.deltaTime;
        //foreach (Transform child in GetComponentsInChildren<Transform>()) - ezzel meg lehetett spórolni a startban a list gyártást
        foreach (var child in children)
        {
            child.Rotate(0, angleStep, 0, Space.Self); // itt lehet Space.World
        }
    }
    void LocateRotationAroundTheParentY1() // parent and chiled rotate together according to parent Y
    {
        angleStep = angleSpeed * Time.deltaTime;
        transform.Rotate(0, angleStep, 0, Space.Self); // itt lehet Space.World
    }
    void LocateRotationAroundTheParentY2() // only chiled rotates according to parent Y
    {
        Vector3 axis = transform.position;
        axis.x = 0; axis.z = 0;
        angleStep = angleSpeed * Time.deltaTime;
        //foreach (Transform child in GetComponentsInChildren<Transform>()) - ezzel meg lehetett spórolni a startban a list gyártást
        foreach (var child in children)
        {
            child.RotateAround(transform.position, axis, angleStep); // itt lehet Space.World
        }
    }
    void LocateRotationAroundTheParentY3() // parent rotates between x+ and z+ koord (45 degrees)
    {
        angleStep = angleSpeed * Time.deltaTime;
        transform.Rotate(angleStep, 0, -angleStep, Space.Self); // itt lehet Space.World
    }
    void CameraFlollow() // camera somewhere - see SerializeFields
    {
        Vector3 desiredPosition = transform.position - transform.rotation * distanceOffset; //  camera position = object position minus an offset which corrected by rotation
        Vector3 smoothedPosition = Vector3.Lerp(myCamera.position, desiredPosition, smoothSpeed);
        myCamera.position = smoothedPosition;

        Quaternion desiredrotation = transform.rotation * Quaternion.Euler(rotationOffset); // camera rotation = object rotation which corrected by offset rotation
        Quaternion smoothedrotation = Quaternion.Lerp(myCamera.rotation, desiredrotation, smoothSpeed);
        myCamera.rotation = smoothedrotation;
    }
    void Examples()
    {
        Vector3 V1 = new Vector3(0, 1, 0);
        Vector3 directionY = transform.TransformDirection(V1); // Local Y axis convert into the world coord
        
        Quaternion targetRotation = Quaternion.identity;  // Ez megegyezik a (0, 0, 0) Euler szögekkel.
        targetRotation.eulerAngles = new Vector3(0, 90, 0);
        
        float angle = Quaternion.Angle(transform.rotation, targetRotation); //Returns the angle in degrees between two rotations a and b.
        
        transform.rotation = Quaternion.AngleAxis(60, Vector3.up); // 60 degree around Y = transform.Rotate(0, 60, 0);
                                                                   // de ez is ugyan az:
        Vector3 rotationVector = new Vector3(0, 60, 0);
        Quaternion rotation = Quaternion.Euler(rotationVector);
        
        float t = 0.5f;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, t);// Quaternion A quaternion interpolated between quaternions a and b.

        Vector3 targetPosition = new Vector3(1, 2, 3);
        Vector3 direction1 = targetPosition - transform.position;
                // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation1 = Quaternion.LookRotation(direction1, Vector3.up); // Creates a rotation with the specified forward and upwards directions.
        transform.rotation = rotation1;

        float speed = 2f;
        var step = speed * Time.deltaTime;
                // Rotate our transform a step closer to the target's.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step); //Rotates a rotation from towards to.

        Quaternion rotationA = Quaternion.Euler(rotationVectorA);
        Quaternion rotationB = Quaternion.Euler(rotationVectorB);
        Quaternion rotationResult = rotationA * rotationB;
        Debug.Log(rotationResult.eulerAngles);
        // (0,60,0)*(0,20,0) = (0,80,0)
        // (0,60,0)*(0,0,20) = (0,60,20)
        // (0,60,20)*(0,20,0) = (0,80,20)
        // (10,60,00)*(0,20,20) = (9.39, 80.28, 23.45)
        // (10,60,00)*(0,20,0) = (9.39, 80.28, 3.45)  // majdnem összeadás
        // (-10,60,20)*(10,-60,-20) = (21.25, 7.23, 0.00) // sorrend valszeg, elõször Z-t rotálja, majd x és y
    }
}
