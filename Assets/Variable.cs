using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Variable : MonoBehaviour

{
    [SerializeField, Min(10)] int intField = 5; // megjelenik mint public 10-n�l kisebb nincs, de erre nem lehet hivatkozni �gy m�sik scriptben csak public eset�ben
    [SerializeField, Range(0,10)] float fField = 5; // Min �s range is egy lehet�s�g, de nincs Max
    [SerializeField] string sField = "hjgjhg";
    [SerializeField] bool bField = true;
    public int hali = 2; // public t�bb, mint a serealizeField, ink�bb a serializefieldet haszn�ljuk

    // Start is called before the first frame update
    void Start()
    {
        int i= 4;
        float fff = 1.0f; // �t lehet nevezni egy v�ltoz� nevet mindenhol a k�dban , jobb gomb �s rename ctrl r ctrl r
        string s = "huhu";
        bool b1 = true; bool b2 = false;
        var V1 = "string"; // var ral felismweri a t�pust

        // sz�mok
        float f1 = fff + 4;
        float f2 = f1 - fff;
        float i5 = 3 / 2; // eredm�nye 1, mert a bemeneti info intes 3 �s 2. Legal�bb az egyik bemenet float legyen
        int i1 = 3, i2 = 2;
        float f3 = i1 / i2; // eredm�lnye 1
        float f4 = i1 / (float) i2; // eredm�lnye 1.3333 ez a castol�s
        double d = 23.4321423; // nem ilyet haszn�lunk
        long l = 4232214; // nem 32 bites int, hanem 64 bites, ezt se haszn�ljuk
        float fa = 5; // (float)5; ez nem kell.

        //stringek
        string s2 = s + "hali";
        string s3 = s2 + 15; // string lesz
        Debug.Log(s3);
        string s4 = " a korom" + fa + "magassa�g" + i1;
        string s5 = $" a korom {fa} magassa�g {i1}";
        string s6 = f4.ToString();
        string s7 = "76";
        int i4 = int.Parse(s7); // nem garant�lt, ha bet�m is van benne
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
