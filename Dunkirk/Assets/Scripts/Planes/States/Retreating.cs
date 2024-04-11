using UnityEngine;

[CreateAssetMenu]
public class Retreating : PlaneState
{
    private Vector3 _targetPos = Vector3.zero;

    public override void Init(Plane plane)
    {
        Debug.Log("Retreating");
        base.Init(plane);
    }

    public override void Run()
    {
        if (IsFinished) return;

        MoveTo();
    }

    private void MoveTo()
    {
        float distance = (_targetPos - _plane.transform.position).magnitude;

        if (distance > 2f)
        {
            _plane.MoveTo(_targetPos);
        }
        else
        {
            _plane.Refuel();
            IsFinished = true;
        }
    }
}
