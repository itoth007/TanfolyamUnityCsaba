using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robbanás : MonoBehaviour
{
    [SerializeField] float radius = 1;
    [SerializeField] float force = 1;
    [SerializeField] float up = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(Robbed), 2f); // 2s after explosion
    }
    void Robbed()
    {
        transform.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, up, ForceMode.Impulse);
        Destroy(gameObject,1f);
    }
}
