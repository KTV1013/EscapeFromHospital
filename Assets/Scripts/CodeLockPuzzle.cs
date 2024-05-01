using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class CodeLockPuzzle : MonoBehaviour
{
    Ray ray;
    public GameObject gear1, gear2, gear3, gear4;
    [SerializeField] Quaternion gear1Rot, gear2Rot, gear3Rot, gear4Rot;
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
            CodeCheck();

        }
    }

    void shootRay()
    {
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.CompareTag("Gear"))
            {                
                hitInfo.collider.gameObject.transform.Rotate(new Vector3(-36f,0f,0f));
            }
        }
    }

    void CodeCheck()
    {
        if (Mathf.Approximately(gear1.transform.rotation.eulerAngles.x, gear1Rot.eulerAngles.x)){ Debug.Log("Gear1 done"); }
        if (Mathf.Approximately(gear2.transform.rotation.eulerAngles.x, gear2Rot.eulerAngles.x)) { Debug.Log("Gear2 done"); }
        if (Mathf.Approximately(gear3.transform.rotation.eulerAngles.x, gear3Rot.eulerAngles.x)) { Debug.Log("Gear3 done"); }
        if (Mathf.Approximately(gear4.transform.rotation.eulerAngles.x, gear4Rot.eulerAngles.x)) { Debug.Log("Gear4 done"); }




        if (Mathf.Approximately(gear1.transform.rotation.eulerAngles.x, gear1Rot.eulerAngles.x) &&
            Mathf.Approximately(gear2.transform.rotation.eulerAngles.x, gear2Rot.eulerAngles.x) &&
            Mathf.Approximately(gear3.transform.rotation.eulerAngles.x, gear3Rot.eulerAngles.x) &&
            Mathf.Approximately(gear4.transform.rotation.eulerAngles.x, gear4Rot.eulerAngles.x))
        {
            puzzleSolved = true;
            Debug.Log("Puzzle Solved!");
        }

    }
}
