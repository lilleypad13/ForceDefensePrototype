using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    private PathTile[] pathTiles;

    public Vector3[] GetWaypointPositions()
    {
        List<Vector3> tempWaypoints = new List<Vector3>();
        foreach (PathTile tile in pathTiles)
        {
            tempWaypoints.Add(tile.gameObject.transform.position);
        }

        return tempWaypoints.ToArray();
    }
}
