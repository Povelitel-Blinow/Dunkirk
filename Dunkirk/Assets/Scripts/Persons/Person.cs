using UnityEngine;
using PersonStateMachineCapluse;

public class Person : MonoBehaviour
{
    [SerializeField] private PersonBody _body;
    [SerializeField] private PersonAnimator _animator;
    [SerializeField] private PersonStateMachine _stateMachine;

    private PersonState _state;

    private void Awake()
    {
        Debug.Log("Alive");
        _body.Init(this);
        _stateMachine.Init(this);

        ChangeState(PersonState.Swim);
    }

    public void Update()
    {
        _stateMachine.UpdateStateMachine();
    }

    public void ChangeState(PersonState personState)
    {
        Debug.Log(personState);

        _animator.SetAnimator(personState);

        if(personState == PersonState.Idle || personState == PersonState.Float)
        {
            _stateMachine.SetState(_stateMachine.Floating);
        }

        if(personState == PersonState.Walk)
        {
            _stateMachine.SetState(_stateMachine.Walking);
        }

        if(personState == PersonState.Swim)
        {
            _stateMachine.SetState(_stateMachine.Swimming);
        }
    }

    public void MoveTo(Vector3 pos) => _body.MoveTo(pos);

    public enum PersonState
    {
        Idle = 0,
        Walk = 1,
        Float = 2,
        Swim = 3
    }
}
