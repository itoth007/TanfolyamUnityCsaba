using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GyorsLassu : MonoBehaviour
{
    [SerializeField] Transform otherTransform;
    [SerializeField] float acceleration;
    [SerializeField] float desceleration;
    [SerializeField] float limit;
    float distance;
    Vector3 velocity = Vector3.zero;
    bool stopped = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (otherTransform != null)
        {
            distance = Vector3.Distance(transform.position, otherTransform.position);
            if (distance > limit)
                velocity += (otherTransform.position - transform.position).normalized * acceleration * Time.fixedDeltaTime;
            else
                velocity = Vector3.MoveTowards(velocity,Vector3.zero,desceleration * Time.fixedDeltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
            transform.position += velocity * Time.deltaTime;

    }
    void OnDrawGizmos()
    {
        if (otherTransform == null) return;

        Gizmos.color = Color.red; // Átlátszó piros
        Gizmos.DrawWireSphere(otherTransform.position, limit);
    }
}
