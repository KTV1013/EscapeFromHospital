using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class CodeLockPuzzle : MonoBehaviour
{
    //RayCasting rayCasting;
    public Animator AnimatorForLock;
    public Animator AnimatorForLockerDoor; 
    public GameObject gear1, gear2, gear3, gear4;
    [SerializeField] Quaternion gear1Rot, gear2Rot, gear3Rot, gear4Rot;
    [SerializeField] bool puzzleSolved = false;
    private float difference = 0.1f;
    public GameObject lockObject;

    void Start()
    {
        //rayCasting = GameObject.FindGameObjectWithTag("Player").GetComponent<RayCasting>();
    }

    void Update()
    {
        CodeCheck();
        LockOpening();
        LockerDoorOpening();
    }

    void CodeCheck()
    {
        //if ((Quaternion.Angle(gear1.transform.rotation, gear1Rot) < difference)) { Debug.Log("Gear1 done"); }
        //if ((Quaternion.Angle(gear2.transform.rotation, gear2Rot) < difference)) { Debug.Log("Gear2 done"); }
        //if ((Quaternion.Angle(gear3.transform.rotation, gear3Rot) < difference)) { Debug.Log("Gear3 done"); }
        //if ((Quaternion.Angle(gear4.transform.rotation, gear4Rot) < difference)) { Debug.Log("Gear4 done"); }

        if (Quaternion.Angle(gear1.transform.rotation, gear1Rot) < difference &&
            Quaternion.Angle(gear2.transform.rotation, gear2Rot) < difference &&
            Quaternion.Angle(gear3.transform.rotation, gear3Rot) < difference &&
            Quaternion.Angle(gear4.transform.rotation, gear4Rot) < difference)
        {
            puzzleSolved = true;
            //Debug.Log("Puzzle Solved!");
        }

    }

    public bool GetCodeStatus ()
    {
        return puzzleSolved;
    }

    private void LockOpening()
    {
        if (puzzleSolved == true)
        {
            AnimatorForLock.SetBool("IsLocked", true);
            StartCoroutine(LockerDoorOpening());

        }
    }

    private IEnumerator LockerDoorOpening()
    {
        if (puzzleSolved == true)
        {
            Debug.Log("Waiting 2 seconds");
            yield return new WaitForSeconds(1);
            AnimatorForLockerDoor.SetBool("IsClosed", true);
            lockObject.transform.parent = AnimatorForLockerDoor.transform;
        }
    }
}
