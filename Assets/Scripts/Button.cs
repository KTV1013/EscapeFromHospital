using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int num;

    [ContextMenu("Press")]

    public string Press()
    {
        Debug.Log(num.ToString());
        return num.ToString();
    }


}
