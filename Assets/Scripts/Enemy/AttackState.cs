using StateMachine;
using UnityEngine;

namespace Enemy
{
    public class AttackState : State<EnemyEvent>
    {
        private float attackDuration;
        private readonly float attackSpeed;
        private readonly AudioSource[] audioSources;
        private readonly EnemyController controller;
        private float coolDown;

        public AttackState(GameObject gameObject
            , EnemyController enemyController) : base(gameObject)
        {
            controller = enemyController;
            audioSources = gameObject.GetComponents<AudioSource>();
            attackSpeed = controller.attackSpeed;
            attackDuration = controller.attackDuration;
        }

        public override void onStateEnter()
        {
            controller.agent.Stop();
            attackDuration = controller.attackDuration;
            coolDown = 0;
        }

        public override EnemyEvent act()
        {
            if (attackDuration <= 0)
                return EnemyEvent.PATROL;

            if (coolDown <= 0)
            {
                getRandomAudio().Play();
                coolDown = attackSpeed;
            }
            else
            {
                coolDown -= Time.deltaTime;
            }

            attackDuration -= Time.deltaTime;
            return EnemyEvent.KEEP_STATE;
        }

        public override void onStateExit()
        {
            controller.agent.isStopped = false;
        }

        private AudioSource getRandomAudio()
        {
            return audioSources[Random.Range(0, audioSources.Length)];
        }
    }
}