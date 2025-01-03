using UnityEngine;

public class Travelers : MonoBehaviour
{
    [SerializeField]
    private Path path;

    [SerializeField]
    private float speed = 10.0f;

    private Vector3[] waypoints;
    private int currentPathIndex = 0;
    private float waypointThreshold = 0.1f;

    private void Start()
    {
        waypoints = path.GetWaypointPositions();
    }

    private void Update()
    {
        // Move towards next waypoint
        MoveTowardsCurrentWaypoint();

        // Once close enough, switch target to next waypoint
        if(Vector3.Distance(gameObject.transform.position, waypoints[currentPathIndex]) < waypointThreshold)
        {
            currentPathIndex++;
        }

    }

    private void MoveTowardsCurrentWaypoint()
    {
        Vector3 target = waypoints[currentPathIndex] - gameObject.transform.position;
        gameObject.transform.position = gameObject.transform.position + target.normalized * speed * Time.deltaTime;
    }
}
