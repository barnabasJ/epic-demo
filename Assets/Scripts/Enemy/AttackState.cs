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
        private GameObject player;

        public AttackState(GameObject gameObject
            , EnemyController enemyController) : base(gameObject)
        {
            controller = enemyController;
            player = controller.player;
            audioSources = this.gameObject.GetComponents<AudioSource>();
            attackSpeed = controller.attackTime;
            attackDuration = controller.attackDuration;
        }

        public override void onStateEnter()
        {
            controller.agent.Stop();
            attackDuration = controller.attackDuration;
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
                coolDown = +Time.deltaTime;
            }

            attackDuration -= Time.deltaTime;
            return EnemyEvent.KEEP_STATE;
        }

        private AudioSource getRandomAudio()
        {
            return audioSources[Random.Range(0, audioSources.Length)];
        }
    }
}