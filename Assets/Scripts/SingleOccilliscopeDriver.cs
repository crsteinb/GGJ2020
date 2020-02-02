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

  public void Start()
  {
    animator = GetComponent<Animator>();
    if (animator == null)
    {
      Debug.LogError("No animator for single occilliscope");
    }
  }
  public void UpdateScope(Robot robot)
  {
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

    }
  }
}
