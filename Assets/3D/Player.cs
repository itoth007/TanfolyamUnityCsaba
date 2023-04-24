using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float angularSpeed = 180; //If the player rotate,
                                               //not suddenly, but continously
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = GetPlayerDirection(); // 4 arrowkeys
        if (direction != Vector3.zero)
        {
            Vector3 velocity = direction * speed;
            transform.position += velocity * Time.deltaTime;
            // After rotation the player target direction
            Quaternion targetAngle = Quaternion.LookRotation(direction);
            // current rotation state
            Quaternion currentAngle = transform.rotation; 
            float step = angularSpeed * Time.deltaTime;
            // that will set that the player rotates continously
            transform.rotation = Quaternion.RotateTowards(currentAngle, targetAngle, step); 
        }
    }
    Vector3 GetPlayerDirection()
    {
        bool upButton = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool downButton = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Y);
        bool rightButton = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.S);
        bool leftButton = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        float x = 0;
        if (rightButton)
            x += 1;
        if (leftButton)
            x -= 1;
        float z = 0;
        if (upButton)
            z += 1;
        if (downButton)
            z -= 1;
        Vector3 dir = new Vector3(x, 0, z);
        dir.Normalize(); // That needs if I press Up and left together dont be quicker
        return dir;
    }
}
