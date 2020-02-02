using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
  public Action GameOver;
  OccilliscopeManager occilliscopeManager;

  public List<RoundDescriptor> Rounds;
  private int currentRound = -1;

  public Animator cartsAnimator;
  private int endRoundTrigger = Animator.StringToHash("EndRound");

  public GameObject leftRobotHolder;
  public GameObject rightRobotHolder;

  public PartsDropper partsDropper;

  public float remainingTime;

  // Start is called before the first frame update
  void Start()
  {
    occilliscopeManager = FindObjectOfType<OccilliscopeManager>();
    if (occilliscopeManager == null)
    {
      Debug.LogError("No Occilliscope Manager configured");
    }

    if (cartsAnimator == null)
    {
      Debug.LogError("No animator for round manager");
    }
  }

  // Update is called once per frame
  void Update()
  {
    // update clock
    remainingTime -= Time.deltaTime;

    // check lose condition
    if (remainingTime < 0.0f)
    {
      GameOver();
    }

    // TODO check win condition

  }

  public void StartNextRound()
  {
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
