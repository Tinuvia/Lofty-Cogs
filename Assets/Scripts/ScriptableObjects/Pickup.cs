using UnityEngine;

[CreateAssetMenu(fileName = "NewPickup", menuName = "Spawns/Pickup")]
public class Pickup : Spawns
{
    //Settings specific to pickup only
    [Header("SpawnType specific")]
    public int Value;
}
