using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PartsDropper : MonoBehaviour
{
  public GameObject[] prefabs;
  public bool dropRandomOnClick = false;

  public void drop()
  {
    Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)], new Vector3(0, 2, gameObject.transform.position.z), Quaternion.identity);
  }

  public void drop(List<GameObject> partsToDrop)
  {
    foreach (var part in partsToDrop)
    {
      Instantiate(part, new Vector3(Random.Range(-1.0f, 1.0f), 2, gameObject.transform.position.z + Random.Range(-1.0f, 1.0f)), Quaternion.identity);
    }
  }

  void OnMouseDown()
  {
    if (dropRandomOnClick)
    {
      drop();
    }
  }
}
