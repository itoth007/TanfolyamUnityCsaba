using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage = 1;
// �tk�z�s  leagl�bb egyiken legyen rigidbody is legyen is Trigger
//Kinematic egyszer�bb, nincs er�s
    private void OnTriggerEnter(Collider other)
    { //Damageable genetic parameter (t�pus)
  //      Damageaable damageable = other.gameObject.GetComponent<Damageable>();
        Damageable damageable = other.GetComponent<Damageable>();
        if(damageable != null)
        {
            //     Debug.Log(other.name);
            damageable.Damage(damage);
        }
    }

    // ontrigger exit (elv�lnak) �s stay (egy�tt vannak) is van
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
