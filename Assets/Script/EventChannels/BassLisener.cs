using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BassLisener<T> : MonoBehaviour
{
    public BassEventOS<T> EventOS;
    public UnityEvent<T> eventChannel;

    private void OnEnable()
    {
        EventOS.OnEventRaise += ChannelRaise;
    }


    private void OnDisable()
    {
        EventOS.OnEventRaise -= ChannelRaise;
    }

    public void ChannelRaise(T value)
    {
        eventChannel?.Invoke(value);
    }




}
