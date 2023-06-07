using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnes : MonoBehaviour
{
    [SerializeField] float minForce = 10f;
    [SerializeField] float maxForce = 30f;

    GameObject[] planetsArray = new GameObject[0];
    List<GameObject> planets = new List<GameObject>();
    List<float> forceOfPlanets = new List<float>();
    Vector3[] velocity = new Vector3[0];
    // Start is called before the first frame update
    void Start()
    {
        planetsArray = FindObjectsOfType<GameObject>();
        var k = 0;
        for (int i = 0; i < planetsArray.Length; i++)
        {
            if (planetsArray[i].layer == 10 || planetsArray[i].layer == 11) //Planet vonz vagy taszit
            {
                planets.Add(planetsArray[i]);
                float force = Random.Range(minForce, maxForce);
                if (planetsArray[i].layer == 10)
                    forceOfPlanets.Add(force);
                else
                    forceOfPlanets.Add(-force);
                k++;
            }
        }
        velocity = new Vector3[k];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            Vector3 forceVector = Vector3.zero;
            velocity[i] = Vector3.zero;
            for (int j = 0; j < planets.Count; j++)
            {
                if (i != j)
                {
                    Vector3 direction;
                    float distance = Vector3.Distance(planets[i].transform.position, planets[j].transform.position);
                    if (distance != 0)
                    {
                        direction = (planets[j].transform.position - planets[i].transform.position).normalized;
                        if (forceOfPlanets[i]* forceOfPlanets[j] < 0) // vonzák egymást
                            forceVector += direction * Mathf.Abs(forceOfPlanets[i] * forceOfPlanets[j]) / (distance*distance);
                        else
                            forceVector -= direction * Mathf.Abs(forceOfPlanets[i] * forceOfPlanets[j]) / (distance * distance);
                        //planets[i].transform.position += forceVector * Time.fixedDeltaTime;
                        planets[i].GetComponent<Rigidbody>().velocity = forceVector*Time.fixedDeltaTime;
                    }
                }
            }
        }

    }
}
