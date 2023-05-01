using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HW0427 : MonoBehaviour
{
    [SerializeField] int n;
    [SerializeField] int[] tomb;
    [SerializeField] int fibo;
    [SerializeField] string szoveg;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Szamjegyek összege: {Szamjegyosszeg(n)}");
        Debug.Log($"Fordított tömb: {ForditottTomb(tomb)[0]}{ForditottTomb(tomb)[1]}{ForditottTomb(tomb)[2]}{ForditottTomb(tomb)[3]}");
        Fibo(fibo);
        Debug.Log($"Karakterszámláló: {Karszaml(szoveg)}");
    }

    // Update is called once per frame
    void Update()
    {

    }
    int Szamjegyosszeg(int n)
    {
        int osszeg = 0;
        do
        {
            osszeg += n % 10;
            if (n / 10 == 0)
                return osszeg;
            else
                n /= 10;
        }
        while (true);
    }
    int[] ForditottTomb(int[] t)
    {
        int length = t.Length;
        int[] tInverz = new int[length];
        for (int i = 0; i < length; i++)
        {
            tInverz[length - i - 1] = t[i];
        }
        return tInverz;
    }

    void Fibo(int fibo)
    {
        int elozo = 0;
        int mostani = 1;
        int kovetkezo = 0;
        if (fibo < 2)
        {
            Debug.Log("Fibo hiba");
        }
        else
        {
            Debug.Log(0);
            Debug.Log(1);
            for (int i = 2; i <= fibo; i++)
            {
                kovetkezo = elozo + mostani;
                Debug.Log(kovetkezo);
                elozo = mostani;
                mostani = kovetkezo;
            }
        }

    }
    int Karszaml(string sz)
    {
        if (sz != null)
        {
            sz = sz.ToUpper();
            char[] szArray = sz.ToCharArray();
            List<char> talaltBetuk = new List<char>();
            talaltBetuk.Add(szArray[0]);
            bool found = false;
            for (int i = 1; i < szArray.Length; i++)
            {
                found = false;
                for (int j = 0; j < talaltBetuk.Count; j++)
                {
                    if (szArray[i] == talaltBetuk[j])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    talaltBetuk.Add(szArray[i]);
            }
            return talaltBetuk.Count;
        }
        return 0;
    }
}
