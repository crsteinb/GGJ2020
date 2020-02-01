using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Draggable : MonoBehaviour {
    
    #region Private Properties
    float zPosition;
    Vector3 offset;
    bool isDragging;
    #endregion

    #region Unity Functions
    void Start () {
        // zPosition = mainCamera.WorldToScreenPoint(transform.position).z;
    }

    void Update () {
        if (isDragging) {
            Vector3 position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
            transform.position = Camera.main.ScreenToWorldPoint (position + new Vector3 (offset.x, offset.y));
        }
    }

    void OnMouseDown() {
        isDragging = true;
        // if (!isDragging) {
        //     OnBeginDrag.Invoke();
        // }
    }

    void OnMouseUp () {
        // OnEndDrag.Invoke();
        isDragging = false;
    }
    #endregion
}
