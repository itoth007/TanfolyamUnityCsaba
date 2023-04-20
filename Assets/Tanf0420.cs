using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tanf0420 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    bool IsPrime(int n)
    {
        if (n % 2 == 0)
            return false;

        for (int i = 0; i < n / 2; i += 2) // optimalizálás n helyett n/2
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    float Min(float a, float b)
    {
        //if (a < b)
        //    return a;
        //else
        //    return b;
        return a < b ? a : b;
    }
    float Max(float a, float b)
    {
        return a > b ? a : b;
    }
    float Max1(float a, float b) => a > b ? a : b;

}
