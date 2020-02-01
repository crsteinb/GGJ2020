using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slot : MonoBehaviour
{
  private Part currentPart_ = null;

  public Action PartChanged;

  public void AttachPart(Part partToAttach)
  {
    currentPart_ = partToAttach;
    partToAttach.transform.position = transform.position;
    partToAttach.transform.rotation = transform.rotation;

    // trigger the part change event
    PartChanged();
  }

}
