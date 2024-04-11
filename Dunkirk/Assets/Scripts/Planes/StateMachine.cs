using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField] private PlaneState _currentState;

    public void SetState(PlaneState state)
    {
        _currentState = state;
    }

    public abstract void MoveTo(Vector2 pos);
}
