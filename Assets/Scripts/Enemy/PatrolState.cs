using System;
using StateMachine;
using UnityEngine;
using Event = UnityEngine.Event;

namespace Enemy
{
    public class PatrolState : State<EnemyEvents>
    {
        public EnemyEvents act(GameObject o)
        {
            throw new NotImplementedException();
        }
    }
}