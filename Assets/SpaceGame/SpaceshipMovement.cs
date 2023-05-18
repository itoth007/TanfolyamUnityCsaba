using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{

    [SerializeField] float maxSpeed = 10;
    [SerializeField] float acceleration = 5;
    [SerializeField] float angularSpeed = 180;
    [SerializeField] float drag = 1;

    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if (x != 0)
        {
            transform.Rotate(0, 0, angularSpeed * -x * Time.deltaTime);
        }

    }
    private void FixedUpdate()
    {
        float y = Input.GetAxis("Vertical"); // lehet itt, mert nem pillanatszerû a key
        if (y > 0)
        {
            velocity += (Vector2)transform.up * (acceleration * Time.fixedDeltaTime);
            if (velocity.magnitude > maxSpeed)
            {
                velocity = velocity.normalized * maxSpeed;
            }
        }
        transform.position += (Vector3)transform.up * Time.fixedDeltaTime;
        velocity-=velocity * (drag)* Time.fixedDeltaTime;
            }
}
