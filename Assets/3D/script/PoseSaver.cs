using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseSaver : MonoBehaviour
{
    [SerializeField] string uniqID; // játékos v Enemy
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(uniqID + "position x"))
        {
            float x = PlayerPrefs.GetFloat(uniqID + "position x");
            float z = PlayerPrefs.GetFloat(uniqID + "position z");
            transform.position = new Vector3(x, 0, z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        PlayerPrefs.SetFloat(uniqID + "position x", x);
        PlayerPrefs.SetFloat(uniqID + "position z", z);
    }
    void DeleteSaveData()
    {
        PlayerPrefs.DeleteKey(uniqID + "position x");
        PlayerPrefs.DeleteKey(uniqID + "position z");
    }
}
