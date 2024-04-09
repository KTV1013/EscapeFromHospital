using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCode : MonoBehaviour
{
    public string pinCode = "1234";
    [SerializeField] string newPinCode;

    Ray ray;
    Button button;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }

    }

    
    private void ShootRay() // Skapat Raycast funktion för att testa om logiken funkar
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.CompareTag("Button"))
            {
               button = hitInfo.collider.gameObject.GetComponent<Button>();
               newPinCode = newPinCode + button.GetNum();

            }
        }
    }
    public string GetPinCode()
    {
        return pinCode;
    }

    public string GetNewPinCode()
    {
        return newPinCode;
    }


}
