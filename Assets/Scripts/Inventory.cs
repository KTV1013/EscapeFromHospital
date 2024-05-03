using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();
    public EquipmentSlot equipmentSlot;
    public TMP_Text itemName;

    public float raycastDistance = 5f;
    public LayerMask itemLayer;

    public Image Image;

    public void Start()
    {
        toggleInventory(false);
    }

    public void Update()
    {
        itemRaycast(Input.GetKeyDown(KeyCode.E));

        if (Input.GetKeyDown(KeyCode.Tab))
            toggleInventory(!inventory.activeInHierarchy);


    }

    private void itemRaycast(bool hasClicked = false)
    {
        itemName.text = "";
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance, itemLayer))
        {
            if (hit.collider != null)
            {
                if (hasClicked)
                {
                    
                    Item newItem = hit.collider.GetComponent<Item>();
                    if(!equipmentSlot.CheckItem())
                    {
                        addItemToEquipment(newItem);
                    }
                    else
                    {
                        addItemToInventory(newItem);
                    } 
                }
                else
                {
                    Item newItem = hit.collider.GetComponent<Item>();
                    itemName.text = newItem?.name;
                }
            }
        }
    }

    private void addItemToInventory(Item itemToAdd)
    {
        InventorySlot openSlot = null;
        
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            bool heldItem = inventorySlots[i].CheckItem();

            if (!heldItem)
            {
                if (!openSlot)
                {
                    openSlot = inventorySlots[i];
                }
            }
        }

        if (openSlot)
        {
            itemToAdd.gameObject.SetActive(false);
            openSlot.setItem(itemToAdd);
        }
    }

    void addItemToEquipment(Item itemToAdd)
    {
        itemToAdd.gameObject.SetActive(false);
        equipmentSlot.setItem(itemToAdd);
    }

    private void toggleInventory(bool enable)
    {
        inventory.SetActive(enable);

        Cursor.lockState = enable ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = enable;

        // Disable the rotation of the camera.
        //CameraController mainCamera = GameObject.Find("Main Camera").GetComponent<CameraController>();
        //mainCamera.CameraRotator = enable ? false : true;
    }   

    public List<InventorySlot> GetInventory()
    {        
        return inventorySlots; 
    }
}