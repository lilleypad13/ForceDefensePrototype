using UnityEngine;

public class TowerTargetingController : MonoBehaviour
{
    [SerializeField] private TravelerSpawnManager spawnManager;
    [SerializeField] private Traveler targetTraveler;
    public Traveler TargetTraveler { get => targetTraveler; }

    private void Awake()
    {
        spawnManager = FindFirstObjectByType<TravelerSpawnManager>();
    }

    private void Update()
    {
        FindTarget();

        // DEBUG
        DebugRaycastToTarget();
    }

    private void FindTarget()
    {
        if (targetTraveler == null)
        {
            FindNewTarget();
        }
        else
        {
            if (!targetTraveler.IsOnGround)
            {
                FindNewTarget();
            }
        }
    }

    private void FindNewTarget()
    {
        if (spawnManager != null)
        {
            if (spawnManager.ActiveTravelers.Count > 0)
            {
                for (int i = 0; i < spawnManager.ActiveTravelers.Count; i++)
                {
                    if (spawnManager.ActiveTravelers[i].IsOnGround)
                    {
                        targetTraveler = spawnManager.ActiveTravelers[i];
                        return;
                    }
                }
            }
        }
    }

    public Vector3 GetDirectionToTarget(Vector3 startingPoint)
    {
        if (targetTraveler != null)
        {
            Debug.DrawRay(startingPoint, targetTraveler.gameObject.transform.position - startingPoint, Color.yellow);
            return targetTraveler.gameObject.transform.position - startingPoint;
        }
        else
        {
            return Vector3.zero;
        }
    }

    // DEBUG
    private void DebugRaycastToTarget()
    {
        if (targetTraveler != null)
        {
            Debug.DrawRay(
                gameObject.transform.position,
                targetTraveler.transform.position - gameObject.transform.position,
                Color.red);
        }
    }
}
