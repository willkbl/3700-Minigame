using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Waypoint
{
    public Vector3 position;
    public List<int> connectedWaypointsIndices = new List<int>();

    /*
    public int GetRandomConnectedWaypointIndex()
    {
        if (connectedWaypointsIndices.Count == 0)
            return -1;
        int randomIndex = Random.Range(0, connectedWaypointsIndices.Count);
        return connectedWaypointsIndices[randomIndex];
    }
    */
    public int GetLinearConnectedWaypointIndex(int currentIndex, List<Waypoint> waypoints )
    {
        if (currentIndex < waypoints.Count - 1)
        {
            return currentIndex + 1;
        }
        return -1; 
    }
}
