using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private Boat _boat;

    public Boat Boat => _boat;

    public void Init(Boat boat)
    {
        _boat = boat;
    }
}
