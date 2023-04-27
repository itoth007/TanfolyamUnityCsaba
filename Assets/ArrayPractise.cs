using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ArrayPractise : MonoBehaviour
{
    [SerializeField] float[] testArray;
    [SerializeField] float mean;
    [SerializeField] float max;

    // Start is called before the first frame update
    void Start()
    {
        mean = Mean(testArray);
        max = Max(testArray);
        float min = Min(testArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnValidate()
    {
        float mean2 = Mean(2, 6);
        float mean3 = Mean(2, 5, 6);
        float[] array1 = new float[5];
        float mean4 = Mean(1f,2f,3f,4f );
        array1[0] = 1f;
        array1[1] = 2f;
        array1[2] = 3f;
        array1[3] = 4f;
        array1[4] = 5f;
        
        for (int i = 0; i < array1.Length; i++)
        {
            array1[i] = array1.Length-i;
        }
        string[] array2 = new string[] { "alma", "körte", "banán" };
        int[] array3 = new int[] { 1, 5, 6, 7, 23 };
        List<int> list1 = new List<int>();
        list1.Add(201); //felvesszük az elemeket
        list1.Add(2011);
        list1.Add(20122);
        Debug.Log(list1[1]);
        list1.RemoveAt(1); //átindexelõdik
        bool succes = list1.Remove(20122); //megkeresi azt az értékût
        Debug.Log(succes);
        list1.Insert(0,1111); //elejére inzert 
        list1.Clear(); // egész törlése
        bool contains = list1.Contains(10);
        int index = list1.IndexOf(2011);
        list1.Sort();

    }

    float Mean(float a, float b)
    {
        return (a+b)/2;
    }
    float Mean(float n1, float n2, float n3) 
    { 
        return (n1+n2+n3)/3;
    }


    float Mean(params float[] array)
    { //!!!!!!!!!!!!!!!!!!!!!!
        if (array.Length == 0) // nulla tömb
            return 0;
        float sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum / array.Length;
    }
    float Max(params float[] array)
    { //!!!!!!!!!!!!!!!!!!!!!!
        if (array.Length == 0) // nulla tömb
            return 0;
        float maxi = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if(array[i]>maxi)
            {
                maxi = array[i];
            }
        }
        return maxi;
    }
    float Min(params float[] array)
    { //!!!!!!!!!!!!!!!!!!!!!!
        if (array.Length == 0) // nulla tömb
            return 0;
        float min = array[0];
        foreach (var item in array)
        {
            if (item < min)
                min = item;
        }
        return min;
    }

}
