using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class hw0511 : MonoBehaviour
{
    [SerializeField] float lengthFromTheOtherObject;
    [SerializeField] GameObject theOtherObject;
    [SerializeField] string myString1 = "abc";
    [SerializeField] string myString2 = "de";
    [SerializeField] int number = 0;
    List<char> myChars = new List<char>();
    void Start()
    {
        char[] myCharArray1 = myString1.ToCharArray();     // Start is called before the first frame update
        char[] myCharArray2 = myString2.ToCharArray();     // Start is called before the first frame update
        for (int i = 0; i < myCharArray1.Length; i++)
        {
            myChars.Add(myCharArray1[i]);
        }
        for (int i = 0; i < myCharArray2.Length; i++)
        {
            myChars.Add(myCharArray2[i]);
        }
        for (int i = 0; i < myChars.Count; i++)
        {
            Debug.Log(myChars[i]);
        }
    }
    private void OnDrawGizmos()
    {
        Vector3 a = transform.position;
        Vector3 b = theOtherObject.transform.position;
        if (Mathf.Abs((a-b).magnitude) < lengthFromTheOtherObject)
        {
            if (Mathf.Abs((a - b).magnitude)< lengthFromTheOtherObject*0.9)
            Gizmos.color = Color.green;
            else
                Gizmos.color = Color.red;
            Gizmos.DrawLine(a, b);
        }
    }
    private void OnValidate()
    {
                Debug.Log(Binary(number));
    }

    int Binary(int num)
    {
        int temp;
        int binaryValue =0;
        int binaryMultiply = 1;
        do         
        {
            temp = num%10;
            if (temp > 1)
                return 0;
            binaryValue += temp * binaryMultiply;
            num = num / 10;
            binaryMultiply *= 2;
            Debug.Log("érték" + binaryValue);
        }
        while(num>0);
        return binaryValue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
