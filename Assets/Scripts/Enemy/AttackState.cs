using StateMachine;
using UnityEngine;
using Event = UnityEngine.Event;

namespace Enemy
{
    public class AttackState : State<EnemyEvent>
    {
        private EnemyController controller;

        public AttackState(GameObject gameObject
            , EnemyController enemyController) : base(gameObject)
        {
            this.controller = enemyController;
        }

        public override EnemyEvent? act()
        {
            throw new System.NotImplementedException();
        }
    }
}