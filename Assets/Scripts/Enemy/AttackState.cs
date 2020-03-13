using StateMachine;
using UnityEngine;
using Event = UnityEngine.Event;

namespace Enemy
{
    public class AttackState : State<EnemyEvents>
    {
        public EnemyEvents act(GameObject o)
        {
            throw new System.NotImplementedException();
        }
    }
}