using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float angularSpeed = 180;
    // Start is called before the first frame update
    void Start()
    {
        //Transform t = transform; // bonyolult                         ctrl kc ctrl ku komment be és ki
        //Vector3 p = t.position;
        //Debug.Log(p);
        //t.position = new Vector3(2, 3, 4);
        //transform.position= new Vector3(2, 3, 4); // egyszerûbb
        //Debug.Log("Magasság" + transform.position.y);
        //// transform.position.x = 3f; ez nem mûködik
        //Vector3 pos = transform.position; // ez mûködik
        //pos.y = 3;
        //transform.position= pos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = GetInputDirection();
        if (direction != Vector3.zero)
        {
            Vector3 velocity = direction * speed;
            transform.position += velocity * Time.deltaTime;
            Quaternion targetRot = Quaternion.LookRotation(direction);
            Quaternion currentRot = transform.rotation;
            float step = angularSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(currentRot, targetRot, step);    
  //          transform.rotation = Quaternion.LookRotation(direction);
        }
    }
    Vector3 GetInputDirection()
    {
        bool upButton = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A);
        bool downButton = Input.GetKey(KeyCode.DownArrow);
        bool rightButton = Input.GetKey(KeyCode.RightArrow);
        bool leftButton = Input.GetKey(KeyCode.LeftArrow);

        float x = 0;
        if (rightButton)
        {
            x += 1;
        }
        if (leftButton)
        {
            x -= 1;
        }
        float z = 0;
        if (upButton)
        {
            z += 1;
        }
        if (downButton)
        {
            z -= 1;
        }
        Vector3 d = new Vector3(x, 0, z);
        d.Normalize();
        return d;
    }
}
