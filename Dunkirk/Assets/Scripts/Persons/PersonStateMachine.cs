using UnityEngine;

namespace PersonStateMachineCapluse
{
    public class PersonStateMachine : MonoBehaviour
    {
        [SerializeField] private PersonState _float;
        [SerializeField] private PersonState _swim;
        [SerializeField] private PersonState _walk;

        public PersonState Floating => _float;
        public PersonState Swimming => _swim;
        public PersonState Walking => _walk;

        private PersonState _currentState;

        private Person _person;

        public void Init(Person person)
        {
            _person = person;
        }

        public void SetState(PersonState state)
        {
            _currentState = Instantiate(state);
            _currentState.Init(_person);
        }

        public void UpdateStateMachine()
        {
            if (_currentState.IsFinished == false)
            {
                _currentState.Run();
                return;
            }
        }
    }
}