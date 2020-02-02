using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartArea : MonoBehaviour {
    public GameObject heartBoard;

    public void highlight() {
        heartBoard.gameObject.GetComponent<Renderer>().materials[0].color = Color.red;
    }

    public void unHighlight() {
        heartBoard.gameObject.GetComponent<Renderer>().materials[0].color = Color.white;
    }
}
