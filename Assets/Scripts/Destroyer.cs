using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
    public GameManager gameManager;

    void OnCollisionEnter(Collision col) {
        Debug.Log(col.gameObject.layer);
        if(col.gameObject.GetComponent<Draggable>() != null) {
            Destroy(col.gameObject);
            gameManager.partsDropper.drop();
        }
    }
}
