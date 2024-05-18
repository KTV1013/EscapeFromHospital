using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuseDestroy : MonoBehaviour
{
    public GameObject fuse1;
    public GameObject fuse2;

    void Update()
    {
        if(fuse1.activeInHierarchy && fuse2.activeInHierarchy)
        {
            Debug.Log("asd");
        }
    }
}
