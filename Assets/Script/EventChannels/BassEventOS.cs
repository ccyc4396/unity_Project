using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BassEventOS<T>:ScriptableObject
{
    public UnityAction<T> OnEventRaise;

    public void EventRaise(T value)
    {
        OnEventRaise?.Invoke(value);
    }


}
