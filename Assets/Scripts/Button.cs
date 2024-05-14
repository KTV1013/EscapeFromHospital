using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int num;
    public string GetNum()
    {
        Debug.Log(num.ToString());
        return num.ToString();
    }
}
