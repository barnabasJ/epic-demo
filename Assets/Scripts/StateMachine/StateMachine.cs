using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StateMachine<T> where T : struct, IConvertible
    {
        private State<T> currentState;
        private Dictionary<T, State<T>> stateMap;

        public StateMachine(Dictionary<T, State<T>> stateMap)
        {
            this.stateMap = stateMap;
        }

        public T act(GameObject o)
        {
            return currentState.act(o);
        }

        public void transition(T e)
        {
            if (stateMap.ContainsKey(e))
                currentState = stateMap[e];
            else
                throw new ArgumentException("There is no tranisiton for this event");
        }
    }
}