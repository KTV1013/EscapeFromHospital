using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    Ray ray;
    float maxDistance = 5f;
    EquippedItem equippedItem;
    public Animator TrashCanAnimation;
    public bool opend = false;
    public bool lockeropen = false;
    public Animator LockerAnimation;
    AudioManager audioManager;
    private void Start()
    {
        equippedItem = GameObject.FindGameObjectWithTag("Player").GetComponent<EquippedItem>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootRay();
        }
    }
 
    public void ShootRay()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance))
        {
            RotateGear(hitInfo.collider.gameObject, hitInfo.collider.CompareTag("Gear"));
            OpenRoomDoor(hitInfo.collider.CompareTag("Door"), equippedItem.GetItem());
            if (hitInfo.collider.gameObject.CompareTag("Trash Can"))
            {
                Debug.Log("Trash can");
                if (!opend)
                {
                    TrashCanAnimation.SetBool("isOpen", true);
                    opend = true;
                }
            }
        }

        if (hitInfo.collider.gameObject.CompareTag("Locker"))
        {
            Debug.Log("Locker");
            if (!lockeropen)
            {
                LockerAnimation.SetBool("IsClosed", true );
                lockeropen = true;
            }
        }

    }

    // Funktion för att rotarea Gear när man träffar den med en ray
    private void RotateGear(GameObject gear, bool hitingGear)
    {
        
        if (hitingGear)
        {
            audioManager.PlaySFX(audioManager.GearSound);
            gear.transform.Rotate(new Vector3(-36f, 0f, 0f));
            Debug.Log("Roterad");

        }
    }

    // Fuktion som öppnar dörren när en ray träffar dörren och när spelaren håller i nycklen
    private void OpenRoomDoor(bool hitingDoor, string item)
    {
        if (hitingDoor && item == "Room Key")
        {
            Debug.Log("Door is open");
        }
    }
}
