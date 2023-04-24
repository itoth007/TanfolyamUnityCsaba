using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW0420 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //WriteNumbersWithSumOfDigits(12);
        //LegkisebbKozosTobbszoros(12, 16);
        VectorMinus(new Vector3(0, 1, 2), new Vector3 (0,1,3));
    }

    // Update is called once per frame
    void Update()
    {

    }
    void VectorMinus(Vector3 a, Vector3 b)
    {
        Debug.Log((b - a).normalized);
    }
    void LegkisebbKozosTobbszoros(int n, int m)
    {
        int i = Mathf.Max(n, m);
        while (i % n != 0 || i % m != 0)
        {
            i++;
        }
        Debug.Log($"Ez a szám {i}");
    }
    void WriteNumbersWithSumOfDigits(int n)
    {
        int numbersFound = 0;      // Hány elemet találtunk eddig
        for (int i = 1; numbersFound < n; i++) // Végignézzük az összes számot
        {                                      // addig, amíg nem találok eleget.
            if (SumOfDigits(i) == n) // Ha a számjegyek összege megegyezik a számmal,
            {
                // Kiírjuk a számot a feladat szerint.     (Csak az egyik kell)
                //          Console.WriteLine(i);  // Parancsori kiíratás
                Debug.Log(i);          // Unity kiíratás

                numbersFound++;        // Jegyzem, hogy eggyel több megvan
                                       // (Ha ezt kihagyjuk, végtelen ciklust kapunk)
            }
        }
    }

    // Segédfüggvény
    int SumOfDigits(int n)    // A számjegyek összege
    {
        int sum = 0;            // Az összeg nulláról indul
        while (n != 0)          // Addig megyek el, amig a számom nem nulla
        {
            int digit = n % 10;   // Veszem az utoló számjegyet
            sum += digit;         // Növelem az összeget a számjegy értékével
            n /= 10;              // Levágom az utolsó számjegyet
        }
        return sum;
    }
}
