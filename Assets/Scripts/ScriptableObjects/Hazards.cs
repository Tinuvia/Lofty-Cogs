using UnityEngine;


[CreateAssetMenu(fileName = "NewHazard", menuName = "Spawns/Hazards")]
public class Hazards : Spawns
{
    //Settings specific to hazard only
    [Header("SpawnType specific")]
    public int Damage;
}
