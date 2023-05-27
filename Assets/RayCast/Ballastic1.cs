using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballastic1 : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float startSpeed = 7f;

    void Update() // a lövedéket azonban már rigidbody val kell csinálni
    {
        if (Input.GetKeyDown(KeyCode.Return)) // volt lövés
        {
            GameObject newProjectile = Instantiate(projectile);
            newProjectile.transform.position = transform.position + transform.up; // ne a közepétõl, hanem az elejébõl jöjjön a lövedék.
            Rigidbody newRB = newProjectile.GetComponent<Rigidbody>();
            newRB.velocity = startSpeed * transform.up;
            Debug.Log(transform.TransformDirection(transform.up));
        }
    }

}
