using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    private GameObject inventory;
    private List<InventorySlot> inventorySlots = new List<InventorySlot>();
    public EquipmentSlot equipmentSlot;
    private TMP_Text itemName;
    public InventorySlot inventorySlot;
    public int inventorySlotIndex = 15;

    public float raycastDistance = 5f;
    public LayerMask itemLayer;

    public Image Image;
    AudioManager audioManager;

    public void Start()
    {
        addInventory();
        toggleInventory(false);
        audioManager= GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
        Vector3 screenPosition = new(0.5f, 0.5f, 0);
        if (Cursor.visible)
            screenPosition = Input.mousePosition;
        Ray ray = Camera.main.ViewportPointToRay(screenPosition);
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
                        
                        if (hit.collider.gameObject.CompareTag("Key2"))
                        {
                            audioManager.PlaySFX(audioManager.KeysSound);
                        }
                    }
                    else
                    {
                        addItemToInventory(newItem);
                        if (hit.collider.gameObject.CompareTag("Key2"))
                        {
                            audioManager.PlaySFX(audioManager.KeysSound);
                        }

                    } 
                }
                else
                {
                    Item newItem = hit.collider.GetComponent<Item>();
                    itemName.text = newItem.name;
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

        // Disable player movement.
        gameObject.GetComponent<PlayerMovement>().enabled = enable ? false : true;
        gameObject.GetComponentInChildren<MouseController>().enabled = enable ? false : true;
    }

    private void addInventory()
    {
        if (GameObject.Find("Inventory Canvas"))
        {
            inventory = GameObject.Find(gameObject.name + "/Inventory Canvas/Inventory");
            itemName = GameObject.Find(gameObject.name + "/Inventory Canvas/ItemName").GetComponent<TextMeshProUGUI>();

            GameObject slotPlace = GameObject.Find(gameObject.name + "/Inventory Canvas/Inventory/InventorySlots/Viewport/Content");
            if (slotPlace)
            {
                for (int i = 0; i < inventorySlotIndex; i++)
                {
                    InventorySlot addInventorySlot = Instantiate(inventorySlot, slotPlace.transform);
                    addInventorySlot.gameObject.SetActive(true);
                    inventorySlots.Add(addInventorySlot);
                }
            }
        }
    }

    public List<InventorySlot> GetInventory()
    {        
        return inventorySlots; 
    }
}