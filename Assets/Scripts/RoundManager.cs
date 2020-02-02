using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
  public Action GameOver;

  public Action WinRound;

  OccilliscopeManager occilliscopeManager;

  public List<RoundDescriptor> Rounds;
  private int currentRound = -1;

  public Animator cartsAnimator;
  private int endRoundTrigger = Animator.StringToHash("EndRound");
  private int resetGameTrigger = Animator.StringToHash("ResetGame");

  public GameObject leftRobotHolder;
  public GameObject rightRobotHolder;

  public PartsDropper partsDropper;

  public Text timerText;
  public Text scoreText;

  public Text winScoreText;

  public int currentScore = 0;

  public float remainingTime;
  public bool gameRunning = false;

  private bool roundWon = false;
  private bool roundWonCalled = false;

  // Start is called before the first frame update
  void Start()
  {
    occilliscopeManager = FindObjectOfType<OccilliscopeManager>();
    if (occilliscopeManager == null)
    {
      Debug.LogError("No Occilliscope Manager configured");
    }
    else
    {
      occilliscopeManager.MatchFound += RoundWon;
    }

    if (cartsAnimator == null)
    {
      Debug.LogError("No animator for round manager");
    }
  }

  // Update is called once per frame
  void Update()
  {
    // TODO check win condition
    if (roundWon)
    {
      if (!roundWonCalled)
      {
        int newPoints = (int)((remainingTime / Rounds[currentRound].roundDuration) * Rounds[currentRound].maxPoints);
        winScoreText.text = "" + newPoints;
        currentScore += newPoints;
        WinRound();
        roundWonCalled = true;
      }
      return;
    }

    if (!gameRunning)
    {
      return;
    }
    // update clock
    remainingTime -= Time.deltaTime;
    timerText.text = "" + (int)remainingTime;

    // check lose condition
    if (remainingTime < 0.0f)
    {
      gameRunning = false;
      GameOver();
    }
  }

  public void RoundWon()
  {
    roundWon = true;
  }

  public void ResetGame()
  {
    currentScore = 0;
    currentRound = -1;
    cartsAnimator.SetTrigger(resetGameTrigger);
    gameRunning = true;
    roundWon = false;
    roundWonCalled = false;
  }

  public void StartNextRound()
  {
    roundWon = false;
    roundWonCalled = false;

    var parts = FindObjectsOfType<Part>();
    foreach (var part in parts)
    {
      Destroy(part.gameObject);
    }

    if (Rounds.Count == 0)
    {
      Debug.LogError("No rounds configured");
      return;
    }

    currentRound++;
    if (currentRound == Rounds.Count)
    {
      currentRound = 0;
    }

    remainingTime = Rounds[currentRound].roundDuration;

    partsDropper.drop(Rounds[currentRound].partsList);
    StartRound(Instantiate(Rounds[currentRound].leftRobotPrefab, leftRobotHolder.transform), Instantiate(Rounds[currentRound].rightRobotPrefab, rightRobotHolder.transform));
  }

  public void StartRound(Robot leftRobot, Robot rightRobot)
  {
    if (cartsAnimator != null)
    {
      cartsAnimator.SetTrigger(endRoundTrigger);
    }
    if (occilliscopeManager != null)
    {
      occilliscopeManager.ConnectRobots(leftRobot, rightRobot);
    }
  }
}
