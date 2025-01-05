using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Traveler traveler = other.gameObject.GetComponent<Traveler>();
        if(traveler != null)
        {
            traveler.Defeated();
        }
    }
}
