using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 2f)]
    float Speed = 1.8f;

    [SerializeField]
    Transform PlayerCameraTransform;
    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            Vector3 pos = transform.localPosition;
            pos = Vector3.Lerp(pos, Vector3.zero, Speed * Time.deltaTime);
            transform.localPosition = pos;
        }
        if (transform.localRotation != Quaternion.identity)
        {
            Quaternion rot = transform.localRotation;
            rot =Quaternion.Slerp(rot, Quaternion.identity, Speed * Time.deltaTime);
            transform.localRotation = rot;
        }
    }

    public void ResetParent()
    {
        SetParent(PlayerCameraTransform);
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent, true);
    }
}
