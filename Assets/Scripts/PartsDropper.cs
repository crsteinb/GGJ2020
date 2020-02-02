using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PartsDropper : MonoBehaviour {

    public GameObject Parts;
    public GameObject PartPrefab;

    public void drop() {
        Instantiate(PartPrefab, new Vector3(0, 2, 0), Quaternion.identity);
    }

    void OnMouseDown() {
        drop();
    }
}
