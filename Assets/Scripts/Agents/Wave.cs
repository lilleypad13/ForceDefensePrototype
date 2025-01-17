using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Scriptable Objects/Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] private Traveler[] travelers;
    public Traveler[] Travelers { get => travelers; }
}
