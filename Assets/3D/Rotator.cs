using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Rotator : MonoBehaviour
{
    [SerializeField] float angularSpeed;
    [SerializeField] Space space; //Word oe Self
    [SerializeField] Vector3 axis = Vector3.up;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis,angularSpeed*Time.deltaTime,space);
    }
    void OnDrawGizmos()
    {
        Vector3 center = transform.position;
        Vector3 a = center + axis.normalized;
        Vector3 b = center - axis.normalized;   
        Gizmos.color = Color.yellow;    
        Gizmos.DrawLine(a, b);
    }
}
