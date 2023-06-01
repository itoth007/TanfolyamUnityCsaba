using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] Bounds teleportArea;
    //public int GetValue() => value;
    public int Value => value; // ez ugyanaz mint a kommentezett és ez az egész a seria.. helyett privattal

    public void Jump()
    {
        float x = Random.Range(teleportArea.min.x, teleportArea.max.x);
        float y = Random.Range(teleportArea.min.y, teleportArea.max.y);
        float z = Random.Range(teleportArea.min.z, teleportArea.max.z);
        transform.position = new Vector3(x, y, z);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(teleportArea.center, teleportArea.size);
    }
}
