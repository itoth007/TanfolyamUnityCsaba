using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demager : MonoBehaviour
{
    [SerializeField] int damage = 1;
// �tk�z�s  leagl�bb egyiken legyen rigidbody is legyen is Trigger
//Kinematic egyszer�bb, nincs er�s
    private void OnTriggerEnter(Collider other)
    { //Demageble genetic parameter (t�pus)
  //      Demageble damageble = other.gameObject.GetComponent<Demageble>();
        Demageble damageble = other.GetComponent<Demageble>();
        if(damageble != null)
        {
            //     Debug.Log(other.name);
            damageble.Damage(damage);
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
