using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gravity : MonoBehaviour
{
    [SerializeField] Vector3 gravity1Vector = new Vector3(0, -9.81f, 0);
    [SerializeField] Vector3 gravity2Vector = new Vector3(0, 1f, 0);
    [SerializeField] float distance = 2;
    [SerializeField] Transform magnet;
    ConstantForce gravityForce;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform childrenTransform in GetComponentsInChildren<Transform>())
        {
            if (childrenTransform != transform)
            {
                childrenTransform.GetComponent<Rigidbody>().useGravity = false;
                childrenTransform.AddComponent<ConstantForce>();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform childrenTransform in GetComponentsInChildren<Transform>())
        {
            if (childrenTransform != transform)
            {
                gravityForce = childrenTransform.GetComponent<ConstantForce>();
                gravityForce.force = (Vector3.Distance(childrenTransform.position, magnet.position) < distance) ? gravity2Vector : gravity1Vector;
            }
        }
    }
}
