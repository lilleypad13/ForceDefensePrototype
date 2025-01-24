using UnityEngine;
using Helpers;
using System;

[System.Serializable]
public struct TravelerProperties
{
    [SerializeField] private float charge;
    public float Charge { get => charge; }
    [SerializeField] private float mass;
    public float Mass { get => mass; }
}

public class Traveler : MonoBehaviour
{
    [Header("System")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask pathLayer;
    private Path path;

    [Header("Parameters")]
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private TravelerProperties properties;
    [SerializeField] private float groundCheckDistance = 5.0f;

    [SerializeField] private bool isOnGround = false;
    public bool IsOnGround { get => isOnGround; }

    private Vector3[] waypoints;
    private int currentPathIndex = 0;
    private float waypointThreshold = 0.1f;

    // Events
    public static event Action<Traveler> OnTravelerDefeated;

    private void Start()
    {
        waypoints = path.GetWaypointPositions();
    }

    private void Update()
    {
        // Move towards next waypoint
        MoveTowardsCurrentWaypoint();

        // Once close enough, switch target to next waypoint
        CheckForNextWaypoint();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(gameObject.transform.position, Vector3.down * groundCheckDistance, Color.yellow);
        if (Physics.Raycast(gameObject.transform.position, Vector3.down, groundCheckDistance, pathLayer))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            //Debug.Log("Colliding with: " + contact.point + "with value: " + contact.normal);
        }
    }

    private void MoveTowardsCurrentWaypoint()
    {
        Vector3 target = new Vector3(
            waypoints[currentPathIndex].x, gameObject.transform.position.y, waypoints[currentPathIndex].z) 
            - gameObject.transform.position;
        gameObject.transform.position = gameObject.transform.position + target.normalized * speed * Time.deltaTime;
    }

    private void CheckForNextWaypoint()
    {
        Vector3 distanceCheckTarget = new Vector3(gameObject.transform.position.x, 0.0f, gameObject.transform.position.z);
        Vector3 target = new Vector3(waypoints[currentPathIndex].x, 0.0f, waypoints[currentPathIndex].z);
        if (Vector3.Distance(distanceCheckTarget, target) < waypointThreshold)
        {
            currentPathIndex++;
            ReachedEnd();
        }
    }

    public void SetPath(Path _path)
    {
        path = _path;
    }

    public void ReachedEnd()
    {
        if(currentPathIndex >= waypoints.Length)
        {
            // Do end thing
            Destroy(gameObject);
        }
    }

    public void ApplyForce(float incomingCharge, Vector3 incomingPosition)
    {
        rb.AddForce(
            PhysicsHelper.CoulombForce(
                properties.Charge, 
                incomingCharge, 
                gameObject.transform.position - incomingPosition));
    }

    public void Defeated()
    {
        OnTravelerDefeated?.Invoke(this);
        Destroy(gameObject);
    }
}
