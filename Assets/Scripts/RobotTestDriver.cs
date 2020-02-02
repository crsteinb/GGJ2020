using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTestDriver : MonoBehaviour
{
  public Robot leftRobot;

  public Robot rightRobot;

  public List<Part> parts;

  public RoundManager roundManager;

  public void Start()
  {
    roundManager.StartRound(leftRobot, rightRobot);
  }

}
