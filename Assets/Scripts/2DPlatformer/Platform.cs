using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Collider col;
    MeshRenderer meshRenderer;

    [SerializeField] DragDropButtons dragDrop;


    void Start()
    {
        col = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
        ActivatePlatform(false);
    }

    public void ActivatePlatform(bool isActive)
    {
        col.enabled = isActive;
        meshRenderer.enabled = isActive;
        dragDrop.ActivateUI(!isActive);
    }

    //public void ActivateUIImage(bool isActive)
    //{
    //    dragDrop.gameObject.SetActive(isActive); 
    //}

    private void OnMouseDown()
    {
        ActivatePlatform(false);
    }
}
