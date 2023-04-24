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
        Debug.Log($"Ez a sz�m {i}");
    }
    void WriteNumbersWithSumOfDigits(int n)
    {
        int numbersFound = 0;      // H�ny elemet tal�ltunk eddig
        for (int i = 1; numbersFound < n; i++) // V�gign�zz�k az �sszes sz�mot
        {                                      // addig, am�g nem tal�lok eleget.
            if (SumOfDigits(i) == n) // Ha a sz�mjegyek �sszege megegyezik a sz�mmal,
            {
                // Ki�rjuk a sz�mot a feladat szerint.     (Csak az egyik kell)
                //          Console.WriteLine(i);  // Parancsori ki�rat�s
                Debug.Log(i);          // Unity ki�rat�s

                numbersFound++;        // Jegyzem, hogy eggyel t�bb megvan
                                       // (Ha ezt kihagyjuk, v�gtelen ciklust kapunk)
            }
        }
    }

    // Seg�df�ggv�ny
    int SumOfDigits(int n)    // A sz�mjegyek �sszege
    {
        int sum = 0;            // Az �sszeg null�r�l indul
        while (n != 0)          // Addig megyek el, amig a sz�mom nem nulla
        {
            int digit = n % 10;   // Veszem az utol� sz�mjegyet
            sum += digit;         // N�velem az �sszeget a sz�mjegy �rt�k�vel
            n /= 10;              // Lev�gom az utols� sz�mjegyet
        }
        return sum;
    }
}
