using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OccilliscopeManager : MonoBehaviour
{

  public SingleOccilliscopeDriver LeftSingleOccilliscope;
  public SingleOccilliscopeDriver RightSingleOccilliscope;

  public TripleOccilliscopeDriver LeftTripleOccilliscope;
  public TripleOccilliscopeDriver RightTripleOccilliscope;

  private Robot leftRobot_;
  private Robot rightRobot_;

  private Action<Robot> UpdateLeftScopes;
  private Action<Robot> UpdateRightScopes;

  public void Start()
  {
    if (LeftSingleOccilliscope != null)
    {
      UpdateLeftScopes += LeftSingleOccilliscope.UpdateScope;
    }
    if (RightSingleOccilliscope != null)
    {
      UpdateRightScopes += RightSingleOccilliscope.UpdateScope;
    }
    if (LeftTripleOccilliscope != null)
    {
      UpdateLeftScopes += LeftTripleOccilliscope.UpdateScope;
    }
    if (RightTripleOccilliscope != null)
    {
      UpdateRightScopes += RightTripleOccilliscope.UpdateScope;
    }
  }

  public void ConnectRobots(Robot leftRobot, Robot rightRobot)
  {
    // register event handlers
    if (leftRobot_ != null)
    {
      leftRobot_.WaveformChanged -= UpdateScopes;
    }
    if (rightRobot_ != null)
    {
      rightRobot_.WaveformChanged -= UpdateScopes;
    }
    leftRobot_ = leftRobot;
    rightRobot_ = rightRobot;

    leftRobot_.WaveformChanged += UpdateScopes;
    rightRobot_.WaveformChanged += UpdateScopes;

    // initialize the scopes for the new robots
    UpdateScopes(leftRobot);
    UpdateScopes(rightRobot);
  }

  public void UpdateScopes(Robot robot)
  {
    if (robot == leftRobot_)
    {
      // update the single left and triple left occilliscopes
      LeftSingleOccilliscope.UpdateScope(robot);
      LeftTripleOccilliscope.UpdateScope(robot);
    }

    if (robot == rightRobot_)
    {
      // update the single right and triple right occilliscopes
      RightSingleOccilliscope.UpdateScope(robot);
      RightTripleOccilliscope.UpdateScope(robot);
    }
  }



}
