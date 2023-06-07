using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sugar2 : MonoBehaviour
{
    [SerializeField] GameObject prototype;
    [SerializeField] float distance = 1;
    [SerializeField] float lengthRay = 12;
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
        Vector3 nowPosition = transform.position + 3 * transform.up;       // A sugár kezdõpontja az ágyu vége
        Quaternion nowRotation = transform.rotation;
        if (prevPosition != nowPosition || prevRotation != nowRotation)
        {
            Ray ray = new(nowPosition, transform.up);          // Sugár
            bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, lengthRay, mask);   // A raycast elvégzése
            if (hit)
            {
                cubeDistanceVector = hitInfo.point - nowPosition;
                smallRayVector = cubeDistanceVector.normalized * distance;
                ObjectDestroy();
                int i = 0;
                while ((smallRayVector * (i + 1)).magnitude < cubeDistanceVector.magnitude)
                {
                    objects.Add(Instantiate(prototype));
                    objects[i].transform.position = nowPosition + smallRayVector * (i + 1);
                    i++;
                }
            }
            else
            {
                ObjectDestroy();
            }
            prevPosition = nowPosition;
            prevRotation = nowRotation;
        }
    }
    private void ObjectDestroy()
    {
        for (int j = 0; j < objects.Count; j++)
        {
            Destroy(objects[j]);
        }
        objects.Clear();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 rayTo = transform.position + 3 * transform.up + transform.up * lengthRay;
        Gizmos.DrawLine(transform.position + 3 * transform.up, rayTo);
        Gizmos.DrawSphere(transform.position + 3 * transform.up, 0.1f);
    }
}
