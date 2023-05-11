using UnityEngine;

class PlatformerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float acceleration = 10;
    [SerializeField] float deceleration = 10;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float jumpSpeed = 10;

    [SerializeField] new Rigidbody2D rigidbody;

    bool isGrounded = false;

    void OnValidate()
    {
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        Vector2 velocity = rigidbody.velocity;
        if (x == 0) // Deceleration
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.fixedDeltaTime);
        }
        else // Acceleration
        {
            Vector2 accelerationVec = new Vector2(x * acceleration, 0);
            //velocity.x = x * movementSpeed;

            velocity += accelerationVec * Time.fixedDeltaTime;
            // rigidbody.AddForce(accelerationVec, ForceMode2D.Force);

            if (Mathf.Abs(velocity.x) > maxSpeed)
                velocity.x = maxSpeed * Mathf.Sign(velocity.x);
        }

        // -------------------------------------------------


        rigidbody.velocity = velocity;
    }

    private void Update()
    {
        Vector2 velocity = rigidbody.velocity;
        bool jump = Input.GetKeyDown(KeyCode.Space);

        if (jump && isGrounded)
        {
            velocity.y = jumpSpeed;
        }
        rigidbody.velocity = velocity;
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
