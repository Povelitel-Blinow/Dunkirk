using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;

    private Transform _followTarget;
    private Boat _boat;

    public void Init(Boat boat)
    {
        _boat = boat;
        _followTarget = boat.Follow;
    }

    public void Update()
    {
        RotateBoat();
        _boat.Move();

        transform.position = _followTarget.position;
    }

    private void RotateBoat()
    {
        _boat.Rotate(_input.GetRotation());
    }
}
