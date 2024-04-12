using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int num;
    Ray ray;

    [ContextMenu("Press")]

    public string GetNum()
    {
        Debug.Log(num.ToString());
        return num.ToString();
    }
}
