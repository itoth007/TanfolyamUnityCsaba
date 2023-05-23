using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Szocske : MonoBehaviour
{
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float verticalSpeed = 4;
    [SerializeField] float horizontalSpeed = 4;
    Vector3 verticalStep = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    float HorizontalStep = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void FixedUpdate()
    {
        if (verticalStep.y > 0)
            HorizontalStep += gravity * Time.fixedDeltaTime * Time.fixedDeltaTime;
        verticalStep.y -= HorizontalStep;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            velocity = new Vector3(verticalSpeed, horizontalSpeed, 0);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            velocity = new Vector3(-verticalSpeed, horizontalSpeed, 0);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            velocity = new Vector3(0, horizontalSpeed, verticalSpeed);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            velocity = new Vector3(0, horizontalSpeed, -verticalSpeed);
        verticalStep += velocity * Time.deltaTime;
        if (verticalStep.y < 0)
        {
            verticalStep.y = 0;
            HorizontalStep = 0;
            velocity = Vector3.zero;
        }
        transform.position = verticalStep;
    }
}
