using UnityEngine;

[RequireComponent(typeof(TowerTargetingController))]
public class CoulombTower : MonoBehaviour
{
    [Header("Core Components")]
    [SerializeField] private TowerTargetingController towerTargetingController;

    [Header("Parameters")]
    [SerializeField] private float charge;

    private Traveler targetTraveler;

    private void Update()
    {
        targetTraveler = towerTargetingController.TargetTraveler;
    }

    private void FixedUpdate()
    {
        ApplyCoulombForce();
    }

    private void ApplyCoulombForce()
    {
        if(targetTraveler != null)
        {
            targetTraveler.ApplyForce(charge, gameObject.transform.position);
        }
    }
}
