using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Draggable : MonoBehaviour {
    
    #region Private Properties
    float zPosition;
    Vector3 offset;
    bool isDragging;
    Rigidbody myRigidbody;
    DragSurface[] dragSurfaces;
    #endregion

    public Slot collidingSlot;

    #region Unity Functions
    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        // zPosition = mainCamera.WorldToScreenPoint(transform.position).z;
        dragSurfaces = FindObjectsOfType<DragSurface>();
        foreach(var dragSurface in dragSurfaces){
            dragSurface.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    void FixedUpdate () {
        if (isDragging) {
            UpdateTransformToDragSurface();
        }
    }

    void UpdateTransformToDragSurface(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        if (Physics.Raycast(ray, out hit, 100, layerMask)) {
            // Debug.DrawLine(ray.origin, hit.point);
            transform.position = hit.point;
        }
    }

    void OnMouseDown() {
        isDragging = true;
        myRigidbody.isKinematic = true; 
        foreach(var dragSurface in dragSurfaces){
            dragSurface.gameObject.GetComponent<Collider>().enabled = true;
        } 
        UpdateTransformToDragSurface();
    }

    void OnMouseUp () {
        Debug.Log("OnMouseUp");
        isDragging = false;
        myRigidbody.isKinematic = false;
        foreach(var dragSurface in dragSurfaces){
            dragSurface.gameObject.GetComponent<Collider>().enabled = false;
            Debug.Log("collidingSlot : " + collidingSlot);
            if (collidingSlot != null) {
                Debug.Log("do AttachPart");
                collidingSlot.AttachPart(gameObject.GetComponent<Part>());
            }
        }
    }
    #endregion
}
