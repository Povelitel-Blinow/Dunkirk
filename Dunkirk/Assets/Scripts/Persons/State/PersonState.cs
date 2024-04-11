using UnityEngine;

namespace PersonStateMachineCapluse
{
    public abstract class PersonState : ScriptableObject
    {
        public bool IsFinished { get; protected set; }

        protected Person _person;

        public virtual void Init(Person person)
        {
            _person = person;
        }

        public abstract void Run();
    }
}