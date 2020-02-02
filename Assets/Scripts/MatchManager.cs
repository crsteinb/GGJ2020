using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour
{
    public GameObject shapePanel;
    public GameObject octavePanel;
    public GameObject polarityPanel;
    
    public bool isShapeMatching;
    public bool isOctaveMatching;
    public bool isPolarityMatching;

    OccilliscopeManager occilliscopeManager;

    Color matchColor = UnityEngine.Color.green;
    Color nonMatchColor = UnityEngine.Color.red;

    // Color matchTextColor = UnityEngine.Color.green;
    // Color nonTextMatchColor = UnityEngine.Color.red;

    // Start is called before the first frame update
    void Start() {
        occilliscopeManager = FindObjectOfType<OccilliscopeManager>();
        if (occilliscopeManager == null) {
            Debug.LogError("No Occilliscope Manager configured");
        }
    }

    // Update is called once per frame
    void Update() {
        checkMatch();
    }

    void checkMatch() {
        if (occilliscopeManager.CheckShapeMatch()) {
            // shapePanel.gameObject.GameObject.Find("MyPanel").GetComponent<Image>().color = matchColor;
            // shapePanel.GetComponent<Image>().color = matchColor;
            // Image img =  GameObject.Find("MyPanel").GetComponent<Image>();
            // img.color = UnityEngine.Color.red;
            
            // shapePanel.GetComponent<Image>().color = Color.yellow;

            // Debug.Log("hmmm : " + shapePanel.GetComponent<Image>());
            shapePanel.GetComponent<Image>().color = matchColor;
        } else {
            // shapePanel.gameObject.GameObject.Find("MyPanel").GetComponent<Image>().color = nonMatchColor;
            // shapePanel.GetComponent<Image>().color = nonMatchColor;
            // shapePanel.gameObject.GetComponent<Panel>().GetComponent<Image>().color = Color.blue;
            // Debug.Log("hmmm : " + shapePanel.GetComponent<Image>());
            shapePanel.GetComponent<Image>().color = nonMatchColor;
        }

        if (occilliscopeManager.CheckOctaveMatch()) {
            // octavePanel.gameObject.GameObject.Find("MyPanel").GetComponent<Image>().color = matchColor;
            octavePanel.GetComponent<Image>().color = matchColor;
        } else {
            // octavePanel.gameObject.GameObject.Find("MyPanel").GetComponent<Image>().color = nonMatchColor;
            octavePanel.GetComponent<Image>().color = nonMatchColor;
        }

        if (occilliscopeManager.CheckPolarityMatch()) {
            // polarityPanel.gameObject.GameObject.Find("MyPanel").GetComponent<Image>().color = matchColor;
            polarityPanel.GetComponent<Image>().color = matchColor;
        } else {
            // polarityPanel.gameObject.GameObject.Find("MyPanel").GetComponent<Image>().color = nonMatchColor;
            polarityPanel.GetComponent<Image>().color = nonMatchColor;
        }
    }
}
