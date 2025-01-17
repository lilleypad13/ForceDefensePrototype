using System;
using System.Collections;
using UnityEngine;

public class TravelerSpawner : MonoBehaviour
{
    [Header("System")]
    [SerializeField] private Path path;
    [SerializeField] private GameObject spawnGroup;

    [Header("Parameters")]
    [SerializeField] private Wave wave;
    [SerializeField] private float timeBetweenSpawns = 0.5f;

    // Events
    public static event Action<Traveler> OnTravelerSpawned;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }

    private void Start()
    {
        Debug.Log("Press SPACE to spawn wave.");
    }

    private void Spawn()
    {
        StartCoroutine(Spawn_CR());
    }

    private IEnumerator Spawn_CR()
    {
        for (int i = 0; i < wave.Travelers.Length; i++)
        {
            Traveler traveler = Instantiate(wave.Travelers[i], path.GetWaypointPositions()[0], Quaternion.identity, spawnGroup.transform);
            traveler.SetPath(path);
            OnTravelerSpawned?.Invoke(traveler);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
