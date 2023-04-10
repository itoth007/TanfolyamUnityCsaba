using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class circle : MonoBehaviour
{
    [SerializeField] float radius = 1;
    [SerializeField] float circumferance ; // ker�let
    [SerializeField] float area;       // ter�let

    // Start is called before the first frame update
    private void OnValidate() //Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
                              //Use this to perform an action after a value changes in the Inspector; for example, making sure that data stays within a certain range.
    {
        circumferance = 2*radius*Mathf.PI; // ker�let
        area = radius*radius* Mathf.PI;       // ter�let
//        Debug.Log(area);
    }
}
