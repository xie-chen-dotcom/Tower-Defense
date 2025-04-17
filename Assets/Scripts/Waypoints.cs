using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Waypoints Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        Init();
    }
    private List<Transform> waypointList;
    // Start is called before the first frame update
    private void Init()
    {
        Transform[] transforms = GetComponentsInChildren<Transform>();
        waypointList = new List<Transform>(transforms);
        waypointList.RemoveAt(0);
    }

    // Update is called once per frame
    public int GetLength()
    {
        return waypointList.Count;
    }
    public Vector3 GetWaypoint(int index)
    {
        return waypointList[index].position;
    }
}
