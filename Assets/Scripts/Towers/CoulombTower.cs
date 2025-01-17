using UnityEngine;

public class CoulombTower : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float charge;

    private Traveler targetTraveler;
    private TravelerSpawnManager spawnManager;

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

    private void FixedUpdate()
    {
        ApplyCoulombForce();
    }

    private void FindTarget()
    {
        if(targetTraveler == null)
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

    private void ApplyCoulombForce()
    {
        if(targetTraveler != null)
        {
            targetTraveler.ApplyForce(charge, gameObject.transform.position);
        }
    }

    // DEBUG
    private void DebugRaycastToTarget()
    {
        if(targetTraveler != null)
        {
            Debug.DrawRay(
                gameObject.transform.position, 
                targetTraveler.transform.position - gameObject.transform.position, 
                Color.red);
        }
    }
}
