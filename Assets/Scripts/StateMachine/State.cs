using System;
using UnityEngine;

namespace StateMachine
{
    public interface State<T> where T :struct, IConvertible
    {
        T act(GameObject o);
    }
}