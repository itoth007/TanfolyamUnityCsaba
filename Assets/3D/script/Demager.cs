using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demager : MonoBehaviour
{
    [SerializeField] int damage = 1;
// ütközés  leaglább egyiken legyen rigidbody is legyen is Trigger
//Kinematic egyszerûbb, nincs erõs
    private void OnTriggerEnter(Collider other)
    { //Demageble genetic parameter (típus)
  //      Demageble damageble = other.gameObject.GetComponent<Demageble>();
        Demageble damageble = other.GetComponent<Demageble>();
        if(damageble != null)
        {
            //     Debug.Log(other.name);
            damageble.Damage(damage);
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
