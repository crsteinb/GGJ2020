using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Robot : MonoBehaviour
{

  public RobotSideEnum sideEnum = RobotSideEnum.Left;

  public Action<Robot> WaveformChanged;

  public WaveformEnum currentWaveEnum = WaveformEnum.Sin;

  public int StartingOctave = 0;

  public int StartingPolarity = 1;

  private int currentOctave_ = 0;

  private int currentPolarity_ = 1;

  public List<Slot> Slots;

  public void ComputeWaveform()
  {
    currentOctave_ = StartingOctave;
    currentPolarity_ = StartingPolarity;

    int sinCount = 0;
    int squareCount = 0;
    int triangleCount = 0;

    // perform the computations for current values
    foreach (var slot in Slots)
    {
      var currentPart = slot.GetCurrentPart();
      if (currentPart != null)
      {
        if (sideEnum == RobotSideEnum.Left)
        {
          currentOctave_ += currentPart.PartDescriptor.LeftOctave;
          currentPolarity_ += currentPart.PartDescriptor.LeftPolarity;
          switch (currentPart.PartDescriptor.Waveform)
          {
            case WaveformEnum.Sin:
              sinCount++;
              break;
            case WaveformEnum.Square:
              squareCount++;
              break;
            case WaveformEnum.Triangle:
              triangleCount++;
              break;
            default:
              Debug.LogError("Invalid waveform assigned to part, should only be sin, square or triangle waveforms for parts");
              break;
          }
        }

        if (sideEnum == RobotSideEnum.Right)
        {
          currentOctave_ += currentPart.PartDescriptor.RightOctave;
          currentPolarity_ += currentPart.PartDescriptor.RightPolarity;
          switch (currentPart.PartDescriptor.Waveform)
          {
            case WaveformEnum.Sin:
              sinCount++;
              break;
            case WaveformEnum.Square:
              squareCount++;
              break;
            case WaveformEnum.Triangle:
              triangleCount++;
              break;
            default:
              Debug.LogError("Invalid waveform assigned to part, should only be sin, square or triangle waveforms for parts");
              break;
          }
        }
      }
    }

    if (sinCount > 0)
    {
      // TODO check for combination waves with Square and Triangle

      currentWaveEnum = WaveformEnum.Sin;
    }
    else if (squareCount > 0)
    {
      // TODO check for combination waves with Triangle

      currentWaveEnum = WaveformEnum.Square;
    }
    else if (triangleCount > 0)
    {
      // no other possible combinations
      currentWaveEnum = WaveformEnum.Triangle;
    }

    // trigger waveform change event
    WaveformChanged(this);
  }
}
