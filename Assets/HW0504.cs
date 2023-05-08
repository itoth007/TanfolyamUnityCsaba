using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW0504 : MonoBehaviour
{
    [SerializeField] int i1;
    [SerializeField] int i2;
    // Start is called before the first frame update
    void Start()
    {
        TwoIntExchange(i1, i2);
        
    }

    private void TwoIntExchange(int i1, int i2)
    {
        i1 = i1 * i2;
        i2 = i1 / i2;
        i1 /= i2;
        Debug.Log($"I1: {i1}, I2: {i2}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
