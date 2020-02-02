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

  public int currentOctave = 0;

  public int currentPolarity = 1;

  public List<Slot> Slots;

  public void Start()
  {
    foreach (var slot in Slots)
    {
      slot.PartChanged += ComputeWaveform;
    }

    // compute initial waveform stats
    ComputeWaveform();
  }

  public void ComputeWaveform()
  {
    currentOctave = StartingOctave;
    currentPolarity = StartingPolarity;

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
          currentOctave += currentPart.PartDescriptor.LeftOctave;
          currentPolarity += currentPart.PartDescriptor.LeftPolarity;
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
          currentOctave += currentPart.PartDescriptor.RightOctave;
          currentPolarity += currentPart.PartDescriptor.RightPolarity;
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
      // check for combination waves with Square and Triangle
      if (squareCount > 0)
      {
        if (triangleCount > 0)
        {
          currentWaveEnum = WaveformEnum.Omega;
        }
        else
        {
          currentWaveEnum = WaveformEnum.Cog;
        }
      }
      else if (triangleCount > 0)
      {
        currentWaveEnum = WaveformEnum.Wave;
      }
      else
      {
        currentWaveEnum = WaveformEnum.Sin;
      }
    }
    else if (squareCount > 0)
    {
      // check for combination waves with Triangle
      if (triangleCount > 0)
      {
        currentWaveEnum = WaveformEnum.Saw;
      }
      else
      {
        currentWaveEnum = WaveformEnum.Square;
      }
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
