using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    Ray ray;
    Ray camRay;
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
        if (Input.GetMouseButton(0))
        {
            ShootRay();
        }
    }
 
    public void ShootRay()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f,0));

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance))
        {
            //if (hitInfo.collider.gameObject.CompareTag("Gear"))
            //{
            //    hitInfo.collider.gameObject.transform.Rotate(new Vector3(36f, 0f, 0f));
            //}
            //RotateGear(hitInfo.collider.gameObject, hitInfo.collider.CompareTag("Gear"));
            OpenRoomDoor(hitInfo.collider.CompareTag("Door"), equippedItem.GetItem());

            PlayAnimation(hitInfo.collider.gameObject.CompareTag("Trash Can"), "isOpen", opend, TrashCanAnimation);
            PlayAnimation(hitInfo.collider.gameObject.CompareTag("Locker"), "IsClosed", lockeropen, LockerAnimation);
        }


    }

    private void PlayAnimation(bool objBeingHit, string animationBool, bool objStatus, Animator animation)
    {
        if(objBeingHit)
        {
            if (!objStatus)
            {
                animation.SetBool(animationBool, true);
            }
        }
    }
    // Funktion för att rotarea Gear när man träffar den med en ray
    private void RotateGear(GameObject gear, bool hitingGear)
    {
        if (hitingGear)
        {
            gear.transform.Rotate(new Vector3(-36f, 0f, 0f));
            audioManager.PlaySFX(audioManager.GearSound);
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
