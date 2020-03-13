using StateMachine;
using UnityEngine;
using Event = UnityEngine.Event;

namespace Enemy
{
    public class AttackState : State<EnemyEvents>
    {
        public AttackState(GameObject gameObject) : base(gameObject)
        {
        }

        public override EnemyEvents act()
        {
            throw new System.NotImplementedException();
        }
    }
}