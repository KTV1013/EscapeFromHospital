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
    public Animator AnimatorForCodeLock;
    public Animator AnimatorLockerDoor; 
    public GameObject gear1, gear2, gear3, gear4;
    public Quaternion gear1Rot, gear2Rot, gear3Rot, gear4Rot;
    [SerializeField] bool puzzleSolved = false;
    private float difference = 0.1f;
    public GameObject lockObject;
    bool puzzelSolvedsound = false;
    AudioManager audioManager;



    void Start()
    {
        //rayCasting = GameObject.FindGameObjectWithTag("Player").GetComponent<RayCasting>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
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
        if (puzzleSolved == true && !puzzelSolvedsound)
        {
            audioManager.PlaySFX(audioManager.UnlockSound);
            AnimatorForCodeLock.SetBool("IsLocked", true);
            StartCoroutine(LockerDoorOpening());
            puzzelSolvedsound=true;

        }
    }

    private IEnumerator LockerDoorOpening()
    {
        if (puzzleSolved == true)
        {
            Debug.Log("Waiting 2 seconds");
            yield return new WaitForSeconds(1);
            AnimatorLockerDoor.SetBool("IsClosed", true);
            lockObject.transform.parent = AnimatorLockerDoor.transform;
        }
    }
}
