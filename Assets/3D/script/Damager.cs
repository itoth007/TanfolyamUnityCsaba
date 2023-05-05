using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage = 1;
// ütközés  leaglább egyiken legyen rigidbody is legyen is Trigger
//Kinematic egyszerûbb, nincs erõs
    private void OnTriggerEnter(Collider other)
    { //Damageable genetic parameter (típus)
  //      Damageaable damageable = other.gameObject.GetComponent<Damageable>();
        Damageable damageable = other.GetComponent<Damageable>();
        if(damageable != null)
        {
            //     Debug.Log(other.name);
            damageable.Damage(damage);
        }
    }

    // ontrigger exit (elválnak) és stay (együtt vannak) is van
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
