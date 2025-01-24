using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TravelerSpawnManager : MonoBehaviour
{
    [SerializeField] private List<Traveler> activeTravelers = new List<Traveler>();
    public List<Traveler> ActiveTravelers { get => activeTravelers; }

    private void OnEnable()
    {
        TravelerSpawner.OnTravelerSpawned += AddTravelerToActive;
        Traveler.OnTravelerDefeated += RemoveTravelerFromActive;
    }

    private void OnDisable()
    {
        TravelerSpawner.OnTravelerSpawned -= AddTravelerToActive;
        Traveler.OnTravelerDefeated -= RemoveTravelerFromActive;
    }

    private void AddTravelerToActive(Traveler traveler)
    {
        activeTravelers.Add(traveler);
    }

    private void RemoveTravelerFromActive(Traveler traveler)
    {
        if (activeTravelers.Contains(traveler))
        {
            activeTravelers.Remove(traveler);
        }
    }
}
