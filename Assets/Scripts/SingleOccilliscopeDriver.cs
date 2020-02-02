using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleOccilliscopeDriver : MonoBehaviour
{
  private Animator animator;
  private int sinTrigger = Animator.StringToHash("SinWave");
  private int squareTrigger = Animator.StringToHash("SquareWave");
  private int sawTrigger = Animator.StringToHash("SawWave");
  private int triangleTrigger = Animator.StringToHash("TriangleWave");
  private int cogTrigger = Animator.StringToHash("CogWave");
  private int waveTrigger = Animator.StringToHash("WaveWave");
  private int omegaTrigger = Animator.StringToHash("OmegaWave");
  private int polarityInt = Animator.StringToHash("Polarity");

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
      case WaveformEnum.Cog:
        animator.SetTrigger(cogTrigger);
        break;
      case WaveformEnum.Wave:
        animator.SetTrigger(waveTrigger);
        break;
      case WaveformEnum.Omega:
        animator.SetTrigger(omegaTrigger);
        break;
      default:
        Debug.Log("Invalid current waveform on robot for single occilliscope");
        break;
    }
    animator.SetInteger(polarityInt, robot.currentPolarity);
  }
}
