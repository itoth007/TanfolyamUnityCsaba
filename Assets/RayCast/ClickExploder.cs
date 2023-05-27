using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExploder : MonoBehaviour
{
    [SerializeField] Transform cursorTransform; //Ezen van a particle system
    [SerializeField] LayerMask clickMass;// mely layerekre érvényes a lövés
    [SerializeField] float range = 10; // milyen távolságra van hatása a lövedék becsapódásának
    [SerializeField] float maxImpulse = 10; // impulse mértéke
    ParticleSystem particleSys;
    Renderer cursorRenderer;
    AudioSource audioSource;
    private void Start()
    {
        particleSys = cursorTransform.GetComponent<ParticleSystem>();
        cursorRenderer = cursorTransform.GetComponent<Renderer>();
        audioSource = cursorTransform.GetComponent<AudioSource>();

    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition; 
        Ray ray = Camera.main.ScreenPointToRay(mousePos); // nem lövünk, csak nézzúk, hogy hol a sugár vége.

        bool isHit = Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, clickMass); // click maly layer nevek érdekese számunkra
        //cursorTransform.gameObject.SetActive(isHit); // ehelyett következõ sor
        cursorRenderer.enabled = isHit; // nem akarjuk látni a plane-en kívül a mous-t, de a robbanás ne szûnjön meg, ha a mouse-t elvisszük. Ezzel csak nem láthtóvá vagy láthatóvá tesszük mouse-t

        if (isHit)
        {
            // Debug.Log($"Hit:  {hit.collider.name}   -   {hit.point}");
            cursorTransform.position = hit.point; // itt legyen a robbantás
            if (Input.GetMouseButtonDown(0))
            {
                Explode(hit.point);
            }
        }
    }
    void Explode(Vector3 point)
    {
        particleSys.Play();
        audioSource.Play();
        Rigidbody[] allRigidBodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in allRigidBodies)
        {
            Vector3 distanceVector = rb.position - point; // közel azonos, mint transform.position
            float distance = distanceVector.magnitude;
            if (distance > range) continue;
            //lökés
            Vector3 direction = distanceVector / distance; //normalizálás
            float m = 1 - (distance / range); // messzebb gyengébb a hatása, mint közel
            float impulse = maxImpulse * m;
            rb.AddForce(direction * impulse, ForceMode.Impulse);
            // rb.velocity += direction * impulse / rb.mass ; // ez pont ugyanaz, mint az elõzõ sor
            // rb.velocity += direction * impulse / rb.mass * Time.deltaTime; // ez pont ugyanaz, mint az elõzõ sor de folyamatos - fújás, szívás
        }
    }
}
