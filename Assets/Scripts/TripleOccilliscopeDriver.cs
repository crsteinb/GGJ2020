using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleOccilliscopeDriver : MonoBehaviour
{
  private Animator animator;
  private int sinTrigger = Animator.StringToHash("SinWave");
  private int squareTrigger = Animator.StringToHash("SquareWave");
  private int sawTrigger = Animator.StringToHash("SawWave");
  private int triangleTrigger = Animator.StringToHash("TriangleWave");
  private int polarityInt = Animator.StringToHash("Polarity");
  private int octaveInt = Animator.StringToHash("Octave");

  public void Awake()
  {
    animator = GetComponent<Animator>();
    if (animator == null)
    {
      Debug.LogError("No animator for single occilliscope");
    }
  }


  public void UpdateScope(Robot robot)
  {
    if (animator == null)
    {
      Debug.LogError("Still no animator for single occilliscope");
      return;
    }
    switch (robot.currentWaveEnum)
    {
      case WaveformEnum.Sin:
        animator.SetTrigger(sinTrigger);
        break;
      case WaveformEnum.Square:
        animator.SetTrigger(squareTrigger);
        break;
      case WaveformEnum.Triangle:
        animator.SetTrigger(triangleTrigger);
        break;
      case WaveformEnum.Saw:
        animator.SetTrigger(sawTrigger);
        break;
      default:
        Debug.Log("Invalid current waveform on robot for single occilliscope");
        break;
    }
    animator.SetInteger(polarityInt, robot.currentPolarity);
    animator.SetInteger(octaveInt, robot.currentOctave);
  }
}
