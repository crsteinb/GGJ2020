using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearRobotEventHandler : MonoBehaviour
{

  public void ClearRobots()
  {
    var robots = GetComponentsInChildren<Robot>();
    foreach (var robot in robots)
    {
      Destroy(robot.gameObject);
    }
  }
}
