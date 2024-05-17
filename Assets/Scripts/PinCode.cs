using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinCode : MonoBehaviour
{
    public string pinCode = "1234";
    [SerializeField] string playerInput;
    public TextMeshProUGUI pinCodetxt;

    Ray ray;
    Button button;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }
        pinCodetxt.text = playerInput;
    }

    
    private void ShootRay() 
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 10f))
        {
            if (hitInfo.collider.CompareTag("Button"))
            {
               button = hitInfo.collider.gameObject.GetComponent<Button>();
               playerInput = playerInput + button.GetNum();
                Debug.Log("player input: " + playerInput);
            }
            if(hitInfo.collider.CompareTag("Delete Button"))
            {
                playerInput = "";
            }
        }
    }
    public string GetPinCode()
    {
        return pinCode;
    }

    public string GetPlayerInput()
    {
        return playerInput;
    }

}
