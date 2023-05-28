using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class sugar : MonoBehaviour
{
    [SerializeField] Transform[] transforms;
    [SerializeField] float lengthRay;
    [SerializeField] LayerMask mask;
    Vector3 smallRayVector;

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position;       // A sugár kezdõpontja
        Vector3 direction = transform.forward;     // A sugár iránya
        Ray ray = new(transform.position, transform.up);          // Sugár

        bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, lengthRay, mask);   // A raycast elvégzése
        if (hit)
        {
            smallRayVector = (hitInfo.point - transform.position) / (transforms.Length + 1);
            //Debug.Log("kis vektor" + );
        }
        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].gameObject.SetActive(hit);
            if (hit)
                transforms[i].position = transform.position + (smallRayVector * (i + 1));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 rayTo = transform.position + transform.up * lengthRay;
        Gizmos.DrawLine(transform.position, rayTo);
    }
}
