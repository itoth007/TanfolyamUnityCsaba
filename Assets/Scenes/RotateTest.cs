using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    [SerializeField] float angleSpeed = 90f;
    List<Transform> children = new List<Transform>();
    float angleStep = 0f;
    Vector3 axis;
    // Start is called before the first frame update
    void Start()
    {
        var childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            children.Add(transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //LocatRotationChild1(); // Vector3
        //LocatRotationChild2(); // float numbers
        //LocateRotationAroundTheParentY1(); // parent rotates too according to parent Y
        //LocateRotationAroundTheParentY2(); // only chiled rotates according to parent Y
        LocateRotationAroundTheParentY3(); // parent rotates between x and z 45 degrees
    }
    void LocatRotationChild1() // Vector3
    {
        angleStep = angleSpeed * Time.deltaTime;
        foreach (var child in children)
        {
            axis = new Vector3(0, angleStep, 0);
            child.Rotate(axis, Space.Self); // itt lehet Space.World
        }
    }
    void LocatRotationChild2() // float numbers
    {
        angleStep = angleSpeed * Time.deltaTime;
        //foreach (Transform child in GetComponentsInChildren<Transform>()) - ezzel meg lehetett spórolni a startban a list gyártást
        foreach (var child in children)
        {
            child.Rotate(0, angleStep, 0, Space.Self); // itt lehet Space.World
        }
    }
    void LocateRotationAroundTheParentY1() // parent rotates too according to parent Y
    {
        angleStep = angleSpeed * Time.deltaTime;
        transform.Rotate(0, angleStep, 0, Space.Self); // itt lehet Space.World
    }
    void LocateRotationAroundTheParentY2() // only chiled rotates according to parent Y
    {
        Vector3 axis = transform.position;
        axis.x = 0; axis.z = 0;
        angleStep = angleSpeed * Time.deltaTime;
        foreach (var child in children)
        {
            child.RotateAround(transform.position, axis, angleStep); // itt lehet Space.World
        }
    }
    void LocateRotationAroundTheParentY3() // parent rotates between x+ and z+ 45 degrees
    {
        angleStep = angleSpeed * Time.deltaTime;
        transform.Rotate(-angleStep, 0, angleStep, Space.Self); // itt lehet Space.World
    }
    
}