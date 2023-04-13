using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW0330 : MonoBehaviour
{
    [SerializeField] int divideWhat; // what divede
    [SerializeField] int divisor;    // with what
    [SerializeField] int number;
    [SerializeField] int baseNumber;
    [SerializeField] int exponent;
    [SerializeField] int szorzo1;
    [SerializeField] int szorzo2;
    // Start is called before the first frame update
    void Start()
    {
        // Osztás szövegesen OnValidate-val
        szamitogepSzerepe();
        osszegzes();
        fizzBuzz();
        hatvanyozas();
        szorzotabla();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnValidate()
    {
        Debug.Log($"{divideWhat}-ban/ben a {divisor} megvan {divideWhat / divisor} és a maradék {divideWhat % divisor}");
    }
    private void szamitogepSzerepe()
    {
        int a = 2, b = 4, c = 5;
        string d = "D", e = "E", f = "F";

        var x1 = a + b + c; //int 11
        var x2 = a + b + e; //string  "24E"
        var x3 = b + d + c; // string "4D5"
        var x4 = f + a + b; // string "F24"
        //        Debug.Log(x4);
        var x5 = a + b * c; //int 22
        x5 /= 8;    // int 2
        var x6 = x5 / b; //int 0
        x6++; //int 1
        var x7 = x6 / 2f; //float 0.5
        x7--; //float -0.5
        var x8 = -1 * x7; // float 0.5
        x8 *= x8; //float 0.25
        //       Debug.Log("X8: "+x8);  

    }
    private void osszegzes()
    {
        int sum = 0;
        for (int i = 0; i < number; i++)
        {
            sum += i + 1;
        }
        Debug.Log("Összegzés eredménye: " + sum);
    }
    private void fizzBuzz()
    {
        string s = "";
        if (number % (3 * 5) == 0)
        {
            s = "FizzBuzz";
        }
        else if (number % 3 == 0)
        {
            s = "Fizz";
        }
        else if (number % 5 == 0)
        {
            s = "Buzz";
        }
        else
        {
            s = "";
            for (int i = 0; i < number; i++)
            {
                s = s + (i + 1);
            }
        }
        Debug.Log("FizzBuzz eredménye:" + s);
    }
    private void hatvanyozas()
    {
        int result = 1;
        for (int i = 0; i < exponent; i++)
        {
            result *= baseNumber;
        }
        Debug.Log("Hatványozás eredménye: " + result);
    }
    private void szorzotabla()
    {
        Debug.Log("Szorzótábla:");
        for (int i = 1; i <= szorzo1; i++)
        {
            for (int j = 1; j <= szorzo2; j++)
            {
                Debug.Log(j + " * " + i + " = " + i * j);
            }
        }
    }
}
