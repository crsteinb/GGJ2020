using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slot : MonoBehaviour
{
  private Part currentPart_ = null;

  public Action PartChanged;
  public HeartArea heartArea;

  public Part GetCurrentPart()
  {
    return currentPart_;
  }

  public void AttachPart(Part partToAttach)
  {
    currentPart_ = partToAttach;
    if (partToAttach != null)
    {
      partToAttach.transform.position = transform.position;
      partToAttach.transform.rotation = transform.rotation;
    }

    if (PartChanged != null)
    {
      // trigger the part change event
      PartChanged();
    }
    else
    {
      Debug.LogError("No PartChanged callbacks registered for part");
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (currentPart_ == null)
    {
      var part = other.gameObject.GetComponent<Part>();
      if (part != null)
      {
        FindObjectOfType<AudioManager>().Play("ClickFuzz");
        part.gameObject.GetComponent<Draggable>().collidingSlot = this;
        highlight();
        heartArea.highlight();
      }
    }
  }

  private void OnTriggerExit(Collider other)
  {
    var part = other.gameObject.GetComponent<Part>();
    if (part != null && (currentPart_ != null && currentPart_ == part))
    {
      FindObjectOfType<AudioManager>().Play("ClickFuzz Low");
      unHighlight();
      heartArea.unHighlight();
      part.gameObject.GetComponent<Draggable>().collidingSlot = null;

      AttachPart(null);
    }
  }

  public void highlight()
  {
    gameObject.GetComponent<Renderer>().materials[0].color = Color.red;
  }

  public void unHighlight()
  {
    gameObject.GetComponent<Renderer>().materials[0].color = Color.white;
  }

}
