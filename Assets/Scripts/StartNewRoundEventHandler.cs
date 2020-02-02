using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNewRoundEventHandler : MonoBehaviour
{
  public RoundManager roundManager;
  public void StartNewRound()
  {
    roundManager.StartNextRound();
  }
}
