using System;
using UnityEngine;

public class Debug_FBDManager : MonoBehaviour
{
    // Reference
    [SerializeField] private GameObject[] testFBDSpawnTargets;

    // Properties
    private int spawnIndex = 0;

    // Event Signals
    public static event Action<GameObject> OnSelectedNewFBDTarget;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SelectNewFBDTarget();
        }
    }

    private void SelectNewFBDTarget()
    {
        OnSelectedNewFBDTarget?.Invoke(testFBDSpawnTargets[spawnIndex]);
        if(spawnIndex >= testFBDSpawnTargets.Length - 1)
        {
            spawnIndex = 0;
        }
        else
        {
            spawnIndex++;
        }
    }
}
