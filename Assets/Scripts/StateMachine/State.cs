using System;
using Enemy;
using UnityEngine;

namespace StateMachine
{
    public abstract class State<T> where T : struct, IConvertible
    {
        private GameObject gameObject;

        public State(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public virtual void onStateEnter()
        {
        }

        public abstract T act();

        public void onStateExit()
        {
        }
    }
}