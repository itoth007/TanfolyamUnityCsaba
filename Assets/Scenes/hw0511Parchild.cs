using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class hw0511Parchild : MonoBehaviour
{
    [SerializeField] float angleSpeed = 90f;
    [SerializeField] float unitDistance;
    List<GameObject> children = new List<GameObject>();
    [SerializeField] float angleStep = 1f;
    Vector3 axis;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        var childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            children.Add(transform.GetChild(i).gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        angleStep = angleSpeed * Time.deltaTime;
        foreach (var child in children)
        {
            if (child.GetComponent<MeshRenderer>() != null)
            {
                distance = Vector3.Distance(child.transform.position, transform.position);
                angleStep = unitDistance / distance;
                axis = child.transform.position;
                axis.x = 0; axis.z = 0;
                child.transform.Rotate(axis, angleStep);
            }
        }
    }
}
