using UnityEngine;

public class BallTowerProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [Header("Parameters")]
    [SerializeField] private float lifetimeDuration = 3.0f;

    private float lifetime = 0.0f;

    private void Update()
    {
        if(lifetime >= lifetimeDuration)
        {
            Destroy(gameObject);
        }
        else
        {
            lifetime += Time.deltaTime;
        }
    }

    public void ApplyImpulseForce(Vector3 forceVector)
    {
        rb.AddForce(forceVector, ForceMode.Impulse);
    }
}
