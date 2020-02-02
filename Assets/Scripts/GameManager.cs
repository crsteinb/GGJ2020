using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public PartsDropper partsDropper;
  public RoundManager roundManager;

  // Start is called before the first frame update
  void Start()
  {
    // drop first part
    StartGame();
  }

  void StartGame()
  {
    roundManager.StartNextRound();
  }
}
