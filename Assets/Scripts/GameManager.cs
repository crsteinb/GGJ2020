using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public PartsDropper partsDropper;

    // Start is called before the first frame update
    void Start() {
        // drop first part
        partsDropper.drop();
    }
}
