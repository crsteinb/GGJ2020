using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PartsDropper : MonoBehaviour {

    public GameObject Parts;
    public GameObject PartPrefab;
    public GameObject[] prefabs;

    public void drop() {
        Instantiate(prefabs[Random.Range(0, prefabs.Length-1)], new Vector3(0, 2, gameObject.transform.position.z), Quaternion.identity);
    }

    void OnMouseDown() {
        drop();
    }
}
