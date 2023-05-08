using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float angle;
    [SerializeField] Transform target; // Drag and drop, whom follows
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 selfPoint = transform.position; //Enemy 
        Vector3 targetPoint = target.position; // Victim

        Vector3 dir = targetPoint - selfPoint; //dirction
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angle * Time.deltaTime);
            //        transform.position = Vector3.MoveTowards(selfPoint, target.position, speed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
