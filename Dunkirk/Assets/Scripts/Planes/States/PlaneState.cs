using UnityEngine;

public abstract class PlaneState : ScriptableObject
{
    public bool IsFinished { get; protected set; }

    protected Plane _plane;

    public virtual void Init(Plane plane)
    {
        _plane = plane;
    }

    public abstract void Run();
    
}
