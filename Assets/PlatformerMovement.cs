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
    int airJumpBudget;
    public float xDirection = 1;
    private void Start()
    {
        airJumpBudget = airJumpCount;

    }
    public Vector2 GetFacingDirection()
    {
        return xDirection * Vector2.right;
    }
    void OnValidate()
    {
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() // Fixed!!!
    {
        float x = Input.GetAxis("Horizontal"); // -1, 0 or +1

        Vector2 velocity = rigidbody.velocity; // actual rigidbody velocity
        if (x == 0) // Deceleration
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.fixedDeltaTime); // between velocity.x and 0
        }
        else // Acceleration
        {
            Vector2 accelerationVec = new Vector2(x * acceleration, 0);
            velocity += accelerationVec * Time.fixedDeltaTime;
            if (Mathf.Abs(velocity.x) > maxSpeed)
                velocity.x = maxSpeed * Mathf.Sign(velocity.x); // Mathf.Sign -1 os +1
        }
        rigidbody.velocity = velocity; // write back to rigidbody

        SetupScale(velocity.x); // with scale tun the gun left or right (there ar other solution too)
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

    void Update() // it is why not in FixedUpdate? - Getkeydown
    {
        Vector2 velocity = rigidbody.velocity;
        bool jump = Input.GetKeyDown(KeyCode.Space);
        if (jump && (isGrounded || airJumpBudget > 0))
        {
            if (!isGrounded)
                airJumpBudget--;
            velocity.y = jumpSpeed;
        }
        rigidbody.velocity = velocity;    
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 point = collision.contacts[0].point;
        Vector3 legWorld = transform.TransformPoint(legPosition);
        float distance = Vector3.Distance(point, (Vector2)legWorld); // same level - Vector2
        if (distance < legRadius)
        {
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
