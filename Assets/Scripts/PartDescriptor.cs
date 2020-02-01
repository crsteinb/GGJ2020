using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PartDescriptor")]
public class PartDescriptor : ScriptableObject
{
  public WaveformEnum Waveform = WaveformEnum.Sin;
  public int LeftPolarity = 1;

  public int RightPolarity = -1;

  public int LeftOctave = -1;

  public int RightOctave = 1;

}
