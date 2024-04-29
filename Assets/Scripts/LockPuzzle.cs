using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class LockPuzzle : MonoBehaviour
{
    Ray ray;
    [SerializeField] string code = "ALVF";
    string newCode;
    float gear1Rot, gear2Rot, gear3Rot, gear4Rot;
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
    }

    void shootRay()
    {
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.CompareTag("Gear"))
            {
                hitInfo.collider.gameObject.transform.Rotate(new Vector3(36f, 0f, 0f));
                if (hitInfo.collider.gameObject.name == "gear1"  )
                {
                    gear1Rot = hitInfo.collider.gameObject.transform.rotation.x;
                   Debug.Log(gear1Rot);
                }
                
            }
            Debug.Log("Ray hit: " + hitInfo.collider.gameObject.tag);
        }
    }
    
}
