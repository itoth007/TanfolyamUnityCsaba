using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hw0504CubeMover : MonoBehaviour
{
    [SerializeField] float speed = 1f;
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
        }
    }
    Vector3 GetPlayerDirection()
    {
        bool upButton = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool downButton = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Y);
        bool rightButton = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.S);
        bool leftButton = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        float x = 0;
        float z = 0;
        if (rightButton)
            x += 1f; 
        else
        if (leftButton)
            x -= 1f; 
        else
        if (upButton)
            z += 1f;
        else
        if (downButton)
            z -= 1f; 


        Vector3 dir = new Vector3(x, 0, z); // Globális térben
        dir.Normalize(); // That needs if I press Up and left together dont be quicker

        dir.y = 0;
        return dir;
    }
}
