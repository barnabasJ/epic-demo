using System.Collections;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace Enemy
{
    public enum EnemyEvents
    {
        PATROL,
        ATTACK,
    }

    public class EnemyController : MonoBehaviour
    {
        public EnemyController()
        {
            var stateMap = new Dictionary<EnemyEvents, State<EnemyEvents>>
            {
                {EnemyEvents.PATROL, new PatrolState(gameObject)},
                {EnemyEvents.ATTACK, new AttackState(gameObject)}
            };
            this.stateMachine = new StateMachine<EnemyEvents>(stateMap);
        }

        private StateMachine<EnemyEvents> stateMachine;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}