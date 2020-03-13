using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;
using UnityEngine.AI;
using Debug = System.Diagnostics.Debug;
using Event = UnityEngine.Event;

namespace Enemy
{
    public class PatrolState : State<EnemyEvent>
    {
        private EnemyController controller;
        private GameObject player;
        private NavMeshAgent agent;
        private List<GameObject> route;
        private GameObject nextStop;
        private int nextStopIndex;
        private float wait;

        public override EnemyEvent act()
        {
            if (Vector3.Distance(controller.transform.position, player.transform.position) <
                controller.followRange)
                return EnemyEvent.FOLLOW;

            if (wait <= 0)
                if (Vector3.Distance(nextStop.transform.position, controller.transform.position) <
                    controller.patrolPointTolerance)
                {
                    wait = controller.patrolBreakTime;
                    nextStop = route[nextStopIndex];
                    nextStopIndex = (nextStopIndex + 1) % route.Count;
                }
                else
                    agent.SetDestination(nextStop.transform.position);
            else
                wait -= Time.deltaTime;

            return EnemyEvent.KEEP_STATE;
        }

        public PatrolState(GameObject gameObject, EnemyController controller
        ) : base(gameObject)
        {
            this.controller = controller;
            this.route = controller.patrolRoute;
            this.player = controller.player;
            this.agent = controller.agent;
            this.nextStopIndex = 0;
            this.nextStop = route[nextStopIndex];
        }
    }
}