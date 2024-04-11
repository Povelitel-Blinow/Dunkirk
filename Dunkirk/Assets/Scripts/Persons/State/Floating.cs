using UnityEngine;

namespace PersonStateMachineCapluse
{
    [CreateAssetMenu(menuName = "Person/Float")]
    public class Floating : PersonState
    {
        public override void Init(Person person)
        {
            base.Init(person);
        }

        public override void Run()
        {

        }
    }
}