using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] KeyCode fireKey = KeyCode.Return;
    [SerializeField] float projectileSpeed;

    [SerializeField] GameObject projectilePrototype;

    PlatformerMovement mover;

    void Start()
    {
        mover = GetComponentInParent<PlatformerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            GameObject newProjectile = Instantiate(projectilePrototype);
            newProjectile.transform.position = transform.position;
            Rigidbody2D newRB = newProjectile.GetComponent<Rigidbody2D>();
            newRB.velocity = projectileSpeed * mover.GetFacingDirection();
        }
    }
}
