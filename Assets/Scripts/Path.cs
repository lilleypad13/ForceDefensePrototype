using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [Header("System")]
    [SerializeField] private PathWaypoint[] pathWaypoints;

    [Header("Generation")]
    [SerializeField] private GameObject pathSegmentPrefab;
    [SerializeField] private GameObject pathParent;

    private void Start()
    {
        GeneratePath();
    }

    public Vector3[] GetWaypointPositions()
    {
        List<Vector3> tempWaypoints = new List<Vector3>();
        foreach (PathWaypoint tile in pathWaypoints)
        {
            tempWaypoints.Add(tile.gameObject.transform.position);
        }

        return tempWaypoints.ToArray();
    }

    /// <summary>
    /// Procedurally generate a path based on the path waypoints provided, 
    /// as well as some general sizing parameters.
    /// </summary>
    private void GeneratePath()
    {
        // Necessary values
        int pathSegmentCount = pathWaypoints.Length - 1;

        // Dimensional parameters
        float pathWidth = 6.0f;
        float pathVerticalPosition = -1.0f;

        // GENERATE PATH
        // Get positions and size
        Vector3[] pathSegmentCenters = new Vector3[pathSegmentCount];
        float[] pathSegmentLengths = new float[pathSegmentCount];
        for (int i = 0; i < pathSegmentCount; i++)
        {
            // Get center point between two waypoints.
            // TODO: Eventually may need to factor path width in. (Could be difficult if we can't assume perfect 90 degree turns every time.)
            Vector3 averagePosition = (pathWaypoints[i].transform.position + pathWaypoints[i + 1].transform.position) 
                / 2.0f;
            pathSegmentCenters[i] = new Vector3(averagePosition.x, pathVerticalPosition, averagePosition.z);
            pathSegmentLengths[i] = Vector3.Distance(pathWaypoints[i].transform.position, pathWaypoints[i + 1].transform.position);
        }

        // Generate angles.
        // Base them off of direction of vector (1.0f, 0.0f, 0.0f)
        float[] pathSegmentRotations = new float[pathSegmentCount];
        for (int i = 0; i < pathSegmentCount; i++)
        {
            Vector3 displacementVector = pathWaypoints[i+1].transform.position - pathWaypoints[i].transform.position;
            if(pathWaypoints[i + 1].transform.position.z > pathWaypoints[i].transform.position.z)
            {
                pathSegmentRotations[i] = 360.0f - Vector3.Angle(Vector3.right, displacementVector);
            }
            else
            {
                pathSegmentRotations[i] = Vector3.Angle(Vector3.right, displacementVector);
            }
        }

        // Generat segments
        for (int i = 0; i < pathSegmentCount; i++)
        {
            // Generate
            GameObject generatedPathSegment = Instantiate(pathSegmentPrefab, pathSegmentCenters[i], Quaternion.identity, pathParent.transform);
            // Scale
            generatedPathSegment.transform.localScale = new Vector3(pathSegmentLengths[i], pathSegmentPrefab.transform.localScale.y, pathWidth);
            // Rotate
            generatedPathSegment.transform.rotation = Quaternion.Euler(0.0f, pathSegmentRotations[i], 0.0f);
        }
    }
}
