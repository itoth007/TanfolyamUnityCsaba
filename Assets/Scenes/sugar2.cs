using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sugar2 : MonoBehaviour
{
    [SerializeField] GameObject prototype;
    [SerializeField] float distance;
    [SerializeField] float lengthRay;
    [SerializeField] LayerMask mask;
    Vector3 smallRayVector;
    Vector3 cubeDistanceVector;
    List<GameObject> objects = new List<GameObject>();
    Vector3 prevPosition = Vector3.zero;
    Quaternion prevRotation = Quaternion.identity;
    //bool wasHit = false;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 nowPosition = transform.position;       // A sugár kezdõpontja
        Vector3 direction = transform.up;     // A sugár iránya
        Ray ray = new(transform.position, transform.up);          // Sugár

        bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, lengthRay, mask);   // A raycast elvégzése
        if(prevPosition!=nowPosition || prevRotation!= )
        //if (hit && !wasHit)
        {
            cubeDistanceVector = (hitInfo.point - transform.position);
            smallRayVector = (hitInfo.point - transform.position).normalized * distance;
            //Debug.Log("kis vektor" + );
            int i = 0;
            for (int j = 0; j < objects.Count; j++)
            {
                Destroy(objects[j]);
            }
            objects.Clear();
            while ((smallRayVector * (i + 1)).sqrMagnitude < cubeDistanceVector.sqrMagnitude)
            {
                GameObject globe;
                globe = Instantiate(prototype, transform.position + smallRayVector * (i + 1), Quaternion.identity);
                objects.Add(globe);
                i++;
            }
            //wasHit = true;
        }
        else
        {
            //wasHit = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 rayTo = transform.position + transform.up * lengthRay;
        Gizmos.DrawLine(transform.position, rayTo);
    }
}
