using UnityEngine;

[RequireComponent(typeof(TowerTargetingController))]
public class BallTower : MonoBehaviour
{
    [Header("Core Components")]
    [SerializeField] private TowerTargetingController towerTargetingController;

    [Header("System")]
    [SerializeField] private Transform projectileLaunchPoint;

    [Header("Parameters")]
    [SerializeField] private BallTowerProjectile projectile;
    [SerializeField] private float projectileLaunchForce;
    [SerializeField] private float cooldownDuration;

    private Traveler targetTraveler;
    private float currentCooldown = 0.0f;

    private void Update()
    {
        // Acquire target
        targetTraveler = towerTargetingController.TargetTraveler;

        // CD handling
        CheckCooldownToFire();
    }

    private void CheckCooldownToFire()
    {
        if (currentCooldown <= 0.0f)
        {
            if (targetTraveler != null)
            {
                FireProjectile();
            }
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    private void FireProjectile()
    {
        if (targetTraveler != null)
        {
            // Handle Projectile
            BallTowerProjectile tempProjectile = Instantiate(
                projectile, 
                projectileLaunchPoint.position, 
                Quaternion.identity, 
                gameObject.transform);
            tempProjectile.ApplyImpulseForce(
                projectileLaunchForce 
                * towerTargetingController.GetDirectionToTarget(projectileLaunchPoint.transform.position));
            // Reset CD
            currentCooldown = cooldownDuration;
        }
    }
}
