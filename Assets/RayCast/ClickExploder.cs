using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExploder : MonoBehaviour
{
    [SerializeField] Transform cursorTransform;
    [SerializeField] LayerMask clickMass;
    [SerializeField] float range = 10;
    [SerializeField] float maxImpulse = 10;
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
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        bool isHit = Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, clickMass);
        //cursorTransform.gameObject.SetActive(isHit);
        cursorRenderer.enabled = isHit;

        if (isHit)
        {
            // Debug.Log($"Hit:  {hit.collider.name}   -   {hit.point}");
            cursorTransform.position = hit.point;
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
            Vector3 distanceVector = rb.position - point;
            float distance = distanceVector.magnitude;
            if (distance > range) continue;
            //lökés
            Vector3 direction = distanceVector / distance;
            float m = 1 - (distance / range);
            float impulse = maxImpulse * m;
            rb.AddForce(direction * impulse, ForceMode.Impulse);
            // rb.velocity += direction * impulse / rb.mass ; // ez pont ugyanaz, mint az elõzõ sor
            // rb.velocity += direction * impulse / rb.mass * Time.deltaTime; // ez pont ugyanaz, mint az elõzõ sor de folyamatos - fújás, szívás
        }
    }
}
