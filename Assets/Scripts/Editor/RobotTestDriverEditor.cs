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
        if (GUILayout.Button("Attach part to Left robot slot"))
        {
          testDriver.leftRobot.Slots[0].AttachPart(testDriver.parts[0]);
        }
      }
      if (testDriver.rightRobot != null && testDriver.rightRobot.Slots.Count > slotToAttach)
      {
        if (GUILayout.Button("Attach Test Part 1 To Right Slot 1"))
        {
          testDriver.rightRobot.Slots[0].AttachPart(testDriver.parts[0]);
        }
      }
    }
  }
}
