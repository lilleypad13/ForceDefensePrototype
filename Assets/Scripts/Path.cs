using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    private PathWaypoint[] pathWaypoints;

    public Vector3[] GetWaypointPositions()
    {
        List<Vector3> tempWaypoints = new List<Vector3>();
        foreach (PathWaypoint tile in pathWaypoints)
        {
            tempWaypoints.Add(tile.gameObject.transform.position);
        }

        return tempWaypoints.ToArray();
    }
}
