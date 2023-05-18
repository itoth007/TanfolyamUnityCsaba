using UnityEngine;

class PlatformerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float acceleration = 10;
    [SerializeField] float deceleration = 10;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float jumpSpeed = 10;
    [SerializeField, Min(0)] int airJumpCount = 1;

    [SerializeField] Vector2 legPosition = new Vector2(0, -1);
    [SerializeField] float legRadius = 0.2f;

    [SerializeField] new Rigidbody2D rigidbody;


    bool isGrounded = false;
    int airJumpBudget = 0;
    float xDirection = 1;
    public Vector2 GetFacingDirection()
    {
        return xDirection * Vector2.right;
    }
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

        // --------------------------------------------------

        SetupScale(velocity.x);
    }

    void SetupScale(float x)
    {
        if (x != 0)
        {
            Vector3 scale = transform.localScale;
            xDirection = Mathf.Sign(x);
            scale.x = xDirection;
            transform.localScale = scale;
        }
    }

    void Update()
    {
        Vector2 velocity = rigidbody.velocity;
        bool jump = Input.GetKeyDown(KeyCode.Space);

        if (jump && (isGrounded || airJumpBudget > 0))
        {
            if (!isGrounded)
                airJumpBudget--;

            Debug.Log(airJumpBudget);

            velocity.y = jumpSpeed;
        }
        rigidbody.velocity = velocity;
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 point = collision.contacts[0].point;
        Vector3 legWorld = transform.TransformPoint(legPosition);
        float distance = Vector3.Distance(point, legWorld);
        if (distance < legRadius)
        {
            Debug.Log("Reload: " + airJumpBudget);
            airJumpBudget = airJumpCount;
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.matrix = transform.localToWorldMatrix;

        Vector2 p = legPosition;
        // Vector3 pWorld = transform.TransformPoint(p);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(p, legRadius);

        Gizmos.matrix = Matrix4x4.identity;
    }
}
