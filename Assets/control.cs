using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    [SerializeField] int a, b;

    // Start is called before the first frame update
    void Start()    // ctrl k d rendezi a sourse k�dot
    {
        a = 4; b = 2;
        if (a > b)
        {
            Debug.Log("nagyobb");
        }
        else if (a == b)
        {
            Debug.Log("egyenl�");
        }
        else
        {
            Debug.Log("kisebb");
        }
        if (a % 2 == 0)
        {
            Debug.Log("p�ros");
        }
        if (a % b == 0)
        {
            Debug.Log("oszthat�");
        }
        if (a > b)
            Debug.Log("nagyobb"); // ha csak egy dolog van, nem kell a kapcsos

        //---------------------
        int number = 21312;
        int lastDigit = number % 10;
        switch (lastDigit)
        {
            case 0:
                //  
                break;
            case 1:
                // 
                break;
            default:
                break;

        }

        //------------
        string parity;
        if (number % 2 == 0)
        {
            parity = "p�ros";
        }
        else
        {
            parity = "p�ratlan";
        }
        parity = number % 2 == 0 ? "p�ros" : "p�ratlan"; // ugyanaz mint el�z� - felt�teles oper�toir

        int i = 0;
        bool is3;
        bool is7;
        int count = 0;
        while (count < 100)
        {
            if (i % 3 == 0 || i % 7 == 0)
            {
                Debug.Log(i);
                count++;
            }
            i++;
        }

        // ctrl kt �s ctrl ku // jelek berak�sa �s kiv�tele

        do // h�tul tesztel�s, �s 1x biztos lefut
        {
            if (i % 3 == 0 || i % 7 == 0)
            {
                Debug.Log(i);
                count++;
            }
            i++;
        }
        while (count < 100);

        //----

        for (int k=0; k < 100; k++) // for ut�n tab tab �s kit�lti
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
