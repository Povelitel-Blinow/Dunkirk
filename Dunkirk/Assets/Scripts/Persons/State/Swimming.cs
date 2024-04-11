using UnityEngine;

namespace PersonStateMachineCapluse
{
    [CreateAssetMenu(menuName = "Person/Swim")]
    public class Swimming : PersonState
    {
        [SerializeField] private float _floatTime;

        private Vector3 _targetPos;

        public override void Init(Person person)
        {
            base.Init(person);

            _targetPos = new Vector3(0, 0, Random.Range(-10, 10));
            Debug.Log($"Swimming to {_targetPos}");
        }

        public override void Run()
        {
            if (_floatTime < 0) _person.ChangeState(Person.PersonState.Float);

            if(IsFinished) return;

            Debug.Log("Swimming");
            
            MoveTo();

            _floatTime -= Time.deltaTime;
        }

        private void MoveTo()
        {
            float distance = (_targetPos - _person.transform.position).magnitude;

            if (distance > 1f)
            {
                _person.MoveTo(_targetPos);
            }
            else
            {
                IsFinished = true;
            }
        }
    }
}