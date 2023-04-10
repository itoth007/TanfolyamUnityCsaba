using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class boolSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bool b1 = true;
        bool b2 = false;
        b1 = false; b2 = false;

        int i1 = 33;
        int i2 = 77;
        bool intAreWqueal = i1== i2;
        bool i1higheri2 = i1 > i2;
        bool i1noteqi2 = i1 != i2;
        bool stringeq = "aa" == "AA"; //false

        int ammo = 50;
        bool isAlive = true;
        bool haveAmmo = ammo > 0;
        bool canShoot = isAlive && haveAmmo;

        float height = 12;
        bool canAirJum = false;
        bool canJump = canAirJum || height == 0; //false

        bool isInAir = height > 0;
        bool isGrounded = !isInAir;

        bool b3 = b1 ^ b2; //XOR kizáró vagy : Mint OR csak True OR True eredménye false  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
