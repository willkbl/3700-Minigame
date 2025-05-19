using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LessRandomWalker : MonoBehaviour
{
    private Path currentPath;
    private int currentWaypointIndex = -1;
    private List<Waypoint> traversalWaypoints = new List<Waypoint>();
    public float speed = 1f;
    public float waypointTolerance = 1f;
    public List<GameObject> pathPrefabs;
    public Transform target;
    public float targetRadius;
    private bool hasStopped = false; 
    GameObject levelManager;
    GameManagerScript gmScript;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("GameManager");
        gmScript = levelManager.GetComponent<GameManagerScript>();
        LoadNewPath();
    }

    void Update()
    {
        if(!hasStopped && target != null && Vector3.Distance(transform.position, target.position) <= targetRadius)
        {
            if (gmScript.isWriting)
            {
                hasStopped = true;
                // teacher stops.
                return; 
            }
        }
        if(hasStopped || traversalWaypoints.Count == 0) return;

        Waypoint targetWaypoint = traversalWaypoints[currentWaypointIndex];
        Vector3 targetPosition = targetWaypoint.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < waypointTolerance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= traversalWaypoints.Count)
            {
                LoadNewPath();
            }
        }
    }

    void LoadNewPath()
    {
        GameObject pathGO = Instantiate(pathPrefabs[Random.Range(0, pathPrefabs.Count)]);
        currentPath = pathGO.GetComponent<Path>();

        traversalWaypoints.Clear();
        currentWaypointIndex = 0;

        if (currentPath.waypoints.Count == 0) return;

        // Start traversal at the FIRST waypoint (index 0)
        TraversePath(currentPath.waypoints, 0, new HashSet<int>());

        // Move the walker to the starting point immediately
        if (traversalWaypoints.Count > 0)
        {
            transform.position = traversalWaypoints[0].position;
        }
    }

    void TraversePath(List<Waypoint> waypoints, int index, HashSet<int> visited)
    {
        if (index < 0 || index >= waypoints.Count || visited.Contains(index)) return;

        visited.Add(index);
        traversalWaypoints.Add(waypoints[index]);

        foreach (int connectedIndex in waypoints[index].connectedWaypointsIndices)
        {
            TraversePath(waypoints, connectedIndex, visited);
        }
    }
}
