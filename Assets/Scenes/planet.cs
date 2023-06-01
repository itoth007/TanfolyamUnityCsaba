using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class planet : MonoBehaviour
{
    [SerializeField] float gravity = 2f;
    List<GameObject> planets = new List<GameObject>();
    GameObject[] planetsArray = new GameObject[0];
    float[] massOfPlanets = new float[0];
    Vector3[] velocity = new Vector3[0];
    // Start is called before the first frame update
    void Start()
    {
        planetsArray = FindObjectsOfType<GameObject>();
        var k = 0;
        for (int i = 0; i < planetsArray.Length; i++)
        {
            if (planetsArray[i].layer == 10) //Planet layer
            {
                planets.Add(planetsArray[i]);
                k++;
            }
        }
        massOfPlanets = new float[k];
        velocity = new Vector3[k];
        for (int i = 0; i < k; i++) // all planet
        {
            var planetRadian = planets[i].transform.localScale.x;
            massOfPlanets[i] = planetRadian * planetRadian * planetRadian * 3.14f * 4 / 3; // globe m3
            //velocity[i] = new Vector3(planetRadian % 3, planetRadian % 5, planetRadian % 7); //addhoc
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            Vector3 acceleration = Vector3.zero;
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
                        acceleration = direction * (gravity * massOfPlanets[j] / distance);
                        velocity[i] += acceleration * Time.fixedDeltaTime;
                        planets[i].transform.position = Vector3.MoveTowards(planets[i].transform.position, planets[j].transform.position, (velocity[i]*Time.fixedDeltaTime).magnitude);

                        //Debug.Log($"{planets[i].name} {planets[j].name} {massOfPlanets[j]} {Vector3.Distance(planets[i].transform.position, planets[j].transform.position)}");
                        //Debug.Log(acceleration);
                    }
                }
            }
            //Debug.Log("acceleration " + acceleration);
        }
    }
    private void Update()
    {
        for (int i = 0; i < planets.Count; i++)
        {

            //planets[i].transform.position += velocity[i] * Time.deltaTime;
        }
    }
}
