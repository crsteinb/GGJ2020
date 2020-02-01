using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Robot : MonoBehaviour
{
  public Action<Robot> WaveformChanged;

  public List<Slot> Slots;

  public void ComputeWaveform()
  {
    // perform the computations for current values

    // trigger waveform change event
    WaveformChanged(this);
  }
}
