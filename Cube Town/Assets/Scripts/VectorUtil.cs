using UnityEngine;
using System.Collections;

public class VectorUtil : MonoBehaviour {

    public static void round(Vector2 pre)
    {
        pre.x = Mathf.Round(pre.x);
        pre.y = Mathf.Round(pre.y);
    }

    public static void round(Vector3 pre)
    {
        pre.x = Mathf.Round(pre.x);
        pre.y = Mathf.Round(pre.y);
        pre.z = Mathf.Round(pre.z);
    }

    public static void roundHozizontal(Vector3 pre)
    {
        pre.x = Mathf.Round(pre.x);
        pre.z = Mathf.Round(pre.z);
    }

    public static Vector2 copy(Vector2 pre)
    {
        return new Vector2(pre.x, pre.y);
    }

    public static Vector3 copy(Vector3 pre)
    {
        return new Vector3(pre.x, pre.y, pre.z);
    }
}
