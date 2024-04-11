using UnityEngine;

[CreateAssetMenu]
public class Attacking : PlaneState
{
    public override void Init(Plane plane)
    {
        Debug.Log("Attacking");
        base.Init(plane);
    }

    public override void Run()
    {
        if (IsFinished) return;

        if (_plane.EnemySpotted == null)
        {
            IsFinished = true;
            return;
        }

        Vector2 direction = _plane.EnemySpotted.transform.position - _plane.transform.position;

        if (direction.magnitude < _plane.OpenFireDist)
            _plane.Shoot();

        _plane.MoveTo(_plane.EnemySpotted.transform.position);
    }
}
