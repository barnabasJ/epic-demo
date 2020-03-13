using System.Collections.Generic;
using StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class FollowState : State<EnemyEvent>
    {
        private EnemyController controller;
        private GameObject player;
        private float followTime;

        public FollowState(GameObject gameObject, EnemyController controller) : base(gameObject)
        {
            this.controller = controller;
            this.player = controller.player;
            this.followTime = controller.followTime;
        }

        public override void onStateEnter()
        {
            this.followTime = controller.followTime;
        }

        public override EnemyEvent act()
        {
            if (Vector3.Distance(controller.transform.position, player.transform.position) < controller.attackRange)
                return EnemyEvent.ATTACK;

            if (followTime < 0)
                return EnemyEvent.PATROL;


            controller.agent.SetDestination(player.transform.position);
            followTime -= Time.deltaTime;
            return EnemyEvent.KEEP_STATE;
        }
    }
}