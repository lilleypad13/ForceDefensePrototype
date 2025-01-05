using System.Collections;
using UnityEngine;

public class TravelerSpawner : MonoBehaviour
{
    [Header("System")]
    [SerializeField] private Traveler travelerPrefab;
    [SerializeField] private Path path;
    [SerializeField] private GameObject spawnGroup;

    [Header("Parameters")]
    [SerializeField] private int spawnCount;
    [SerializeField] private float timeBetweenSpawns = 0.5f;

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
        for (int i = 0; i < spawnCount; i++)
        {
            Traveler traveler = Instantiate(travelerPrefab, path.GetWaypointPositions()[0], Quaternion.identity, spawnGroup.transform);
            traveler.SetPath(path);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
