using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Lookat : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 targetOffset;
    [SerializeField] bool enableVertical = true;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPoint = target.position + targetOffset;
        Vector3 selfPoint = transform.position;
        Vector3 dir = targetPoint - selfPoint;
        if (!enableVertical)
            dir.y = 0;
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir); // nem kell normalizálni
        }
    }
}
