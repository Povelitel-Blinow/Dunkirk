using UnityEngine;

public class PersonAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Init()
    {
        SetAnimator(Person.PersonState.Float);
    }

    public void SetAnimator(Person.PersonState state)
    {
        _animator.SetInteger("State", (int)state);
    }
}
