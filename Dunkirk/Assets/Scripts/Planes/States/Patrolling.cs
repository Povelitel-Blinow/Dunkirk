using UnityEngine;

[CreateAssetMenu]
public class Patrolling : PlaneState
{
    private Vector3 _targetPos;
    public override void Init(Plane plane)
    {
        Debug.Log("Patrolling");
        
        base.Init(plane);
        _targetPos = new Vector3(Random.Range(-10,10), Random.Range(-10, 10), 0);
    }

    public override void Run()
    {
        if(IsFinished) return;

        MoveTo();
    }

    private void MoveTo()
    {
        float distance = (_targetPos - _plane.transform.position).magnitude;

        if(distance > 1f)
        {
            _plane.MoveTo(_targetPos);
        }
        else
        {
            IsFinished = true;
        }
    }
}
