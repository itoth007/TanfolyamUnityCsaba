using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballastic1 : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float startSpeed = 7f;

    void Update() // a l�ved�ket azonban m�r rigidbody val kell csin�lni
    {
        if (Input.GetKeyDown(KeyCode.Return)) // volt l�v�s
        {
            GameObject newProjectile = Instantiate(projectile);
            newProjectile.transform.position = transform.position + transform.up; // ne a k�zep�t�l, hanem az elej�b�l j�jj�n a l�ved�k.
            Rigidbody newRB = newProjectile.GetComponent<Rigidbody>();
            newRB.velocity = startSpeed * transform.up;
            Debug.Log(transform.TransformDirection(transform.up));
        }
    }

}
