using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Tanf0413 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() // ez egy spec met�dus, b�r nincs visszat�r�si k�dja
    {
        Method(); // met�dusok haszn�lata - Ha van visszat�r�s az met�dus, ha nincs visszat�r�s void-os, akkor az elj�r�s
        VectorPractice(); //vectorok
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Method()
    {
        // math
        int a = -45;
        int abs = Mathf.Abs(a);
        int min = Mathf.Min(a, 10);
        int max = Mathf.Max(a, 10, -5, 1); // t�bb is lehet
        int myAbs = MyAbs(a);
        float power = Mathf.Pow(23.5f, 3.5f); // hatv�ny nem felt�tln�l eg�sz
        float power1 = MyPow(23.5f, (int)3.5f); // val�j�ban 3 lesz az exponent
        float sign = Mathf.Sign(-254); // minusz �rt�kn�l minusz 1-et ad vissza, ha plusz, akkor plusz 1-et
        float sign1 = MySign(a - 254);
        MultipleTable(10, 10); // Met�dus, de lehet bel�le visszat�r�s return-nal, csak �rt�k n�lk�l
        float f = Mathf.Clamp(power, -10, 0); // ctrl-space felhozza a mathf lehet�s�geit
        f = Mathf.Clamp01(power);
        f = Mathf.Ceil(f); // felfel� kerek�t
        f = Mathf.Floor(f); //lefel� kerek�t
        f = Mathf.Round(f); // kerek�t
        int i;
        i = Mathf.CeilToInt(f); // felfel� kerek�t
        i = Mathf.FloorToInt(f); //lefel� kerek�t
        i = Mathf.RoundToInt(f); // kerek�t
        f = Mathf.Pow(f, 5);
        f = Mathf.Sqrt(f);
        f = Mathf.Pow(f, 1 / 3f); // k�bgy�k


    }
    int MyAbs(int num)
    {
        int myAbs;
        if (num < 0)
        {
            myAbs = -num;

        }
        else
        {
            myAbs = num;
        }
        return myAbs;
    }
    float MyPow(float baseNumber, int exponent)
    {
        float result = 1;
        for (int i = 0; i < exponent; i++)
        {
            result *= baseNumber;
        }
        return result;
    }
    float MySign(float number)
    {
        if (number < 0) // nem kell a {} mert csak egy parancs van az �gban
            return -1;
        else
            return 1;
    }
    void MultipleTable(int szorzo1, int szorzo2) // ez elj�r�s, de met�dus/f�ggv�ny
    {
        Debug.Log("Szorz�t�bla:");
        for (int i = 1; i <= szorzo1; i++)
        {
            for (int j = 1; j <= szorzo2; j++)
            {
                Debug.Log(j + " * " + i + " = " + i * j);
                if (i > 10)
                    return; // lehet return a met�dusban is, de nem lehet return �rt�ke
            }
        }

    }
    void VectorPractice()
    {
        Vector2 v2;
        Vector3 v3;
        v2 = new Vector2(3, 7);
        v3 = new Vector3(3, 7, 6);
        v3 = new Vector3(); //x,y,z = 0
        v3 = Vector3.zero; //x,y,z = 0
        v3 = new Vector3(1, 2); // z=0
        v3 = Vector3.one; //x,y,z = 1
        v3 =Vector3.right; // x 1 y 0 z 0
        v3 = Vector3.left; // x -1 y 0 z 0
        v3 = Vector3.up; // x 0 y 1 z 0
        v3 = Vector3.down; // x 0 y -1 z 0
        v3 = Vector3.forward; // x 0 y 0 z 1
        v3 = Vector3.back; // x 0 y 0 z -1

        //M�veletek
        Vector3 vSum = v3 + new Vector3(1, 2, 3);
        Vector3 vDif = vSum = v3 - Vector3.left;
        Vector3 vMult = v3 * 10;
        Vector3 vDiv = vSum / 10;
        float length = v3.magnitude; // hossza  vektornak
        Vector3 normalized = v3.normalized;//hossz = 1 , v3 �rt�ke nem v�ltozott
        v3.Normalize(); //v3 �rt�ke megv�ltozott
        float x = v3.x;
        float y = v3.y;
        float z = v3.z;
    } 

}
