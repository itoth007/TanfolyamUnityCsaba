using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExploder : MonoBehaviour
{
    [SerializeField] Transform cursorTransform; //Ezen van a particle system
    [SerializeField] LayerMask clickMass;// mely layerekre �rv�nyes a l�v�s
    [SerializeField] float range = 10; // milyen t�vols�gra van hat�sa a l�ved�k becsap�d�s�nak
    [SerializeField] float maxImpulse = 10; // impulse m�rt�ke
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
        Ray ray = Camera.main.ScreenPointToRay(mousePos); // nem l�v�nk, csak n�zz�k, hogy hol a sug�r v�ge.

        bool isHit = Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, clickMass); // click maly layer nevek �rdekese sz�munkra
        //cursorTransform.gameObject.SetActive(isHit); // ehelyett k�vetkez� sor
        cursorRenderer.enabled = isHit; // nem akarjuk l�tni a plane-en k�v�l a mous-t, de a robban�s ne sz�nj�n meg, ha a mouse-t elvissz�k. Ezzel csak nem l�tht�v� vagy l�that�v� tessz�k mouse-t

        if (isHit)
        {
            // Debug.Log($"Hit:  {hit.collider.name}   -   {hit.point}");
            cursorTransform.position = hit.point; // itt legyen a robbant�s
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
            Vector3 distanceVector = rb.position - point; // k�zel azonos, mint transform.position
            float distance = distanceVector.magnitude;
            if (distance > range) continue;
            //l�k�s
            Vector3 direction = distanceVector / distance; //normaliz�l�s
            float m = 1 - (distance / range); // messzebb gyeng�bb a hat�sa, mint k�zel
            float impulse = maxImpulse * m;
            rb.AddForce(direction * impulse, ForceMode.Impulse);
            // rb.velocity += direction * impulse / rb.mass ; // ez pont ugyanaz, mint az el�z� sor
            // rb.velocity += direction * impulse / rb.mass * Time.deltaTime; // ez pont ugyanaz, mint az el�z� sor de folyamatos - f�j�s, sz�v�s
        }
    }
}
