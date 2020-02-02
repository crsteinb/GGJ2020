using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonWithSounds : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public string pressSoundName = "TouchOut";
	public string unpressSoundName = "TouchIn";

	public void OnPointerDown(PointerEventData d) {
		FindObjectOfType<AudioManager>().Play(pressSoundName);
	}

	public void OnPointerUp(PointerEventData d) {
		FindObjectOfType<AudioManager>().Play(unpressSoundName);
	}
}