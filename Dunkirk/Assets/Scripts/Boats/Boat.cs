using UnityEngine;

public abstract class Boat : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    [Header("Parts")]
    [SerializeField] private SafeZone _zone;
    [SerializeField] private Transform _followPos;
    [SerializeField] protected Transform _hookPoint;

    private int _personsAmount;

    public Transform Follow => _followPos;
    public Transform HookPoint => _hookPoint;

    public void Init()
    {
        _zone.Init(this);
    }

    public void Rotate(float direction)
    {
        transform.rotation *= Quaternion.AngleAxis(direction * _rotateSpeed * Time.deltaTime, Vector3.forward);
    }

    public void Move()
    {
        transform.position += transform.up * _moveSpeed * Time.deltaTime;
    }

    public void PickUpPerson()
    {
        _personsAmount += 1;
    }
}
