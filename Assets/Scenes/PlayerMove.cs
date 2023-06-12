using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float angularSpeed = 90;
    [SerializeField] Transform cameraTransform;

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
            x += 1f; // 0.1f; // 0.1 ->Turn in small circle
        if (leftButton)
            x -= 1f; // 0.1f; // 0.1 ->Turn in small circle
        float z = 0;
        if (upButton)
            z += 1;
        // If camera is not behind you
        //if (downButton)
        //    z -= 1f; // 0.1f; // 0.1 ->Turn in small circle

        // OR

        // If camera is behind you
        if (downButton)
            x += 0.1f; // It is turn // 0.1f; // 0.1 ->Turn in small circle

        // That is better, if camera really behind you, If horozontalAngle not zero in CameraFollower that is not good solution
        Vector3 cameraRight = cameraTransform.right; // Transform.left is minus right
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 dir = x * cameraRight + z * cameraForward;

        // OR

        //// That gives less good feeling, but it is better if there is horosontalAngle in CameraFollower
        //Vector3 dir = new Vector3(x,0,z);
        dir.y = 0;
        return dir.normalized;
    }
}
