using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float destroyTime;
    [SerializeField] float maxDistance;
    float startTime;
    Vector3 startPosition;
    private void Start()
    {
        Invoke(nameof(DestroySelf), destroyTime);
        startPosition = transform.position;
        //startTime = Time.time;
    }
    private void Update()
    {
        //    float age = Time.time - startTime;
        //    if (age > destroyTime)
        //    {
        //        Destroy(gameObject);
        //    }
        if((startPosition-transform.position).magnitude  > maxDistance) {
            DestroySelf();
        }
    }
void DestroySelf() => Destroy(gameObject);
}
