using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayScan : MonoBehaviour
{
    public Animator move;
    private bool isThereItem = false;

    void Update()
    {
        if (gameObject.transform.childCount > 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            ResetPlace();
        }
    }
    public void MoveIn()
    {
        move.SetBool("MoveIn", true);
    }

    public void MoveOut()
    {
        move.SetBool("MoveOut", true);
    }

    public void ResetPlace()
    {
        move.Rebind();
    }
}
