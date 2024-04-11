using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Boat _boat;

    private void Awake()
    {
        _boat.Init();
        _player.Init(_boat);
    }
}
