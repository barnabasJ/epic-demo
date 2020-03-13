using StateMachine;
using UnityEngine;
using Event = UnityEngine.Event;

namespace Enemy
{
    public class AttackState : State<EnemyEvent>
    {
        private EnemyController controller;
        private GameObject player;

        public AttackState(GameObject gameObject
            , EnemyController enemyController) : base(gameObject)
        {
            this.controller = enemyController;
            this.player = controller.player;
        }

        public override EnemyEvent act()
        {
            Debug.Log("Stop");
            controller.agent.Stop();
            return EnemyEvent.KEEP_STATE;
        }
    }
}