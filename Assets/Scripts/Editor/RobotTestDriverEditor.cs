using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RobotTestDriver))]
public class RobotTestDriverEditor : Editor
{

  int partToAttach = 0;
  int slotToAttach = 0;
  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();

    GUI.enabled = Application.isPlaying;

    RobotTestDriver testDriver = target as RobotTestDriver;
    partToAttach = EditorGUILayout.IntField("Part Index:", partToAttach);
    slotToAttach = EditorGUILayout.IntField("Slot Index:", slotToAttach);
    if (testDriver.parts.Count > partToAttach)
    {
      if (testDriver.leftRobot != null && testDriver.leftRobot.Slots.Count > slotToAttach)
      {
        if (GUILayout.Button("Attach part " + partToAttach + " to Left robot slot " + slotToAttach))
        {
          testDriver.leftRobot.Slots[slotToAttach].AttachPart(testDriver.parts[partToAttach]);
        }
      }
      if (testDriver.rightRobot != null && testDriver.rightRobot.Slots.Count > slotToAttach)
      {
        if (GUILayout.Button("Attach part " + partToAttach + " to Right robot slot " + slotToAttach))
        {
          testDriver.rightRobot.Slots[slotToAttach].AttachPart(testDriver.parts[partToAttach]);
        }
      }
    }
  }
}
