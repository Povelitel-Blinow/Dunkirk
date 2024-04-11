using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private float _fuel;
    [SerializeField] private float _flySpeed;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private int _openFireDistance = 10;
    [SerializeField] private Gun[] _guns;
    [SerializeField] private ViewPoint _viewPoint;

    [SerializeField] private Transform TMP;

    [Header("States")]
    [SerializeField] private PlaneState _currentState;
    [SerializeField] private PlaneState _patrollingState;
    [SerializeField] private PlaneState _attackingState;
    [SerializeField] private PlaneState _retreatState;

    public Transform EnemySpotted {  get; private set; }
    public int OpenFireDist => _openFireDistance;   

    private void Awake()
    {
        SetState(_patrollingState);
    }

    private void Update()
    {
        _fuel -= Time.deltaTime;
        transform.position += transform.right * Time.deltaTime * _flySpeed;

        EnemySpotted = _viewPoint.Target;

        if (EnemySpotted != null)
        {
            SetState(_attackingState);
        }

        if (_currentState.IsFinished == false)
        {
            _currentState.Run();
            return;
        }

        if (_fuel < 10)
        {
            SetState(_retreatState);
        }
        else if (EnemySpotted != null)
            SetState(_attackingState);
        else
            SetState(_patrollingState);
    }

    private void SetState(PlaneState state)
    {
        _currentState = Instantiate(state);
        _currentState.Init(this);
    }

    public void MoveTo(Vector3 pos)
    {
        //TMP.transform.position = pos;

        Vector2 direction = pos - transform.position;

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), _rotSpeed * Time.deltaTime);
        }
    }

    public void Shoot()
    {
        foreach(Gun g in  _guns )
        {
            g.ShootGun();
        }
    }

    public void Refuel()
    {
        _fuel = 60;
    }
}
