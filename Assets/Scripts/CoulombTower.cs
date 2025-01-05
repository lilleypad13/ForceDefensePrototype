using UnityEngine;

public class CoulombTower : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float charge;

    private Traveler targetTraveler;

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
            targetTraveler = FindAnyObjectByType<Traveler>();
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
