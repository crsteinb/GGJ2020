using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

  OccilliscopeManager occilliscopeManager;

  public List<RoundDescriptor> Rounds;
  private int currentRound = -1;

  // Start is called before the first frame update
  void Start()
  {
    occilliscopeManager = FindObjectOfType<OccilliscopeManager>();
    if (occilliscopeManager == null)
    {
      Debug.LogError("No Occilliscope Manager configured");
    }
  }

  // Update is called once per frame
  void Update()
  {
    // TODO write game loop logic (update clock, check for win/loss conditions, start next round, etc...)
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
    // TODO update the spawn location
    StartRound(Instantiate(Rounds[currentRound].leftRobotPrefab), Instantiate(Rounds[currentRound].rightRobotPrefab));
  }

  public void StartRound(Robot leftRobot, Robot rightRobot)
  {
    if (occilliscopeManager)
    {
      occilliscopeManager.ConnectRobots(leftRobot, rightRobot);
    }
  }
}
