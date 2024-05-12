using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlighter : MonoBehaviour
{
    Ray ray;
    [SerializeField] float distance = 10f;
    public Renderer objectRenderer;
    public Material outlinerMaterial;
    private Material defaultMaterial;
    private Material secondMaterial;
    [SerializeField] bool isHighlighted = false;

    private void Start()
    {
        //objectRenderer = GetComponent<Renderer>();

        defaultMaterial = objectRenderer.material;
        secondMaterial = defaultMaterial;

        Material[] materials = new Material[2];
        materials[0] = defaultMaterial;
        materials[1] = secondMaterial;

        objectRenderer.materials = materials;

    }

    private void Update()
    {

        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {

            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("Object"+gameObject);
                Debug.Log("hit object:" + hit.collider.gameObject);
                // If not already highlighted, highlight the object
                if (!isHighlighted)
                {
                    HighlightObject();
                }
            }
            else
            {
                // If already highlighted, remove the highlight
                if (isHighlighted)
                {
                    RemoveHighlight();
                }
            }
        }
        else
        {
            RemoveHighlight();
        }
    }

    private void HighlightObject()
    {
        objectRenderer.material = outlinerMaterial;
        isHighlighted = true;
    }

    private void RemoveHighlight()
    {
        objectRenderer.material = defaultMaterial;
        isHighlighted = false;
    }
}

