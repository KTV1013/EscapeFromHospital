using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class LockPuzzle : MonoBehaviour
{
    Ray ray;
    public Transform gear1, gear2, gear3, gear4;
    [SerializeField] float gear1Rot , gear2Rot, gear3Rot, gear4Rot;
    [SerializeField] float diff = 0.1f;
    [SerializeField] bool puzzleSolved = false;
    private float difference = 0.1f;
    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            shootRay();          
        }
        //CodeCheck();
    }

    void shootRay()
    {
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.CompareTag("Gear"))
            {
                hitInfo.collider.gameObject.transform.Rotate(new Vector3(36f,0f,0f));

            }
        }
    }

    //void CodeCheck()
    //{

    //    if (gear1.transform.rotation.x == gear1Rot)
    //    {
    //        if (gear2.transform.rotation.x == gear2Rot)
    //        {
    //            if ((gear3.transform.rotation.x == gear3Rot))
    //            {
    //                if (gear4.transform.rotation.x == gear4Rot)
    //                {
    //                    puzzleSolved = true;
    //                }
    //            }
    //        }
    //    }
    //}

    private void RotationCheck(Transform ob)
    {
        Quaternion targetRotation = ob.rotation;
        if (Quaternion.Angle(transform.rotation, targetRotation) < diff)
        {
            // Om rotationen är tillräckligt nära, sätt boolen till true
            Debug.Log("Rotation är lika");
        }

    }

}
