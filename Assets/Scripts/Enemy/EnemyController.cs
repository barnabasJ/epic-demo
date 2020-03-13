using System;
using System.Collections;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public enum EnemyEvent
    {
        PATROL,
        FOLLOW,
        ATTACK,
        KEEP_STATE,
    }

    public class EnemyController : MonoBehaviour
    {
        public NavMeshAgent agent;
        public List<GameObject> patrolRoute;
        public GameObject player;


        private StateMachine<EnemyEvent> stateMachine;
        public float patrolPointTolerance;
        public float followRange;
        public float attackRange;
        public float patrolBreakTime;
        public float followTime;
        public float attackSpeed;
        public float attackDuration;

        // Start is called before the first frame update
        void Start()
        {
            var stateMap = new Dictionary<EnemyEvent, State<EnemyEvent>>
            {
                {EnemyEvent.PATROL, new PatrolState(gameObject, this)},
                {EnemyEvent.FOLLOW, new FollowState(gameObject, this)},
                {EnemyEvent.ATTACK, new AttackState(gameObject, this)}
            };
            stateMachine = new StateMachine<EnemyEvent>(stateMap, EnemyEvent.KEEP_STATE);
            stateMachine.transition(EnemyEvent.PATROL);
        }

        // Update is called once per frame
        void Update()
        {
            var e = stateMachine.act();
            stateMachine.transition(e);
        }
    }
}