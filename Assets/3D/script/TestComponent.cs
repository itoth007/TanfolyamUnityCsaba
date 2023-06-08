using UnityEngine;

enum Direction { North, South, East, West }

[System.Serializable]
struct MyVector2
{
    public float x, y;
    public string sss;
    public bool bbb;
    public MyVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
        sss = "fgbnfghjk";
        bbb = true;
    }
}

[System.Serializable]
class MyVector3
{
    public float x, y, z;
}



public class TestComponent : MonoBehaviour
{
    [SerializeField] Direction directionAsASetting;
    [SerializeField] MyVector2 vectorAsASetting;
    [SerializeField] MyVector3 vector3AsASetting;


    void Start()
    {
        int i = 2;
        Direction myDirection = Direction.East;
        MyVector2 v2 = new MyVector2(1, 2);
        MyVector3 v3 = new MyVector3() { x = 1, y = 2, z = 5 };
        v3.x = 2;
        Debug.Log(vectorAsASetting.bbb);



        int a = 4;
        int b = a;
        b++;
        Debug.Log(a); // 4
        MyMethod(a);
        Debug.Log(a); // 4

        //----------------

        int[] ta = { 1, 2, 3 };
        int[] tb = ta;
        tb[0] = 33;
        Debug.Log(ta[0]); // 33
        MyMethod2(ta);
        Debug.Log(ta[0]); // 34
    }

    void MyMethod(int i)
    {
        i++;
    }
    void MyMethod2(int[] i)
    {
        i[0]++;
    }
}
