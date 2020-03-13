using System;
using StateMachine;
using UnityEngine;
using Event = UnityEngine.Event;

namespace Enemy
{
    public class PatrolState : State<EnemyEvents>
    {
        public override EnemyEvents act()
        {
            throw new NotImplementedException();
        }

        public PatrolState(GameObject gameObject) : base(gameObject)
        {
        }
    }
}