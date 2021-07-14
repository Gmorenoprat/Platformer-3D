using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// @Author: Gonzalo Moreno Prat
/// cp de ModelosYAlgoritmosI
/// edit: if(overwrite) _events[eventType] = listener;
/// </summary>
public class EventManager : MonoBehaviour
{
    public delegate void EventReceiver(params object[] parameterContainer);

    private static Dictionary<EventsType, EventReceiver> _events;

    public static void SubscribeToEvent(EventsType eventType, EventReceiver listener, bool overwrite = false)
    {
        if (_events == null) 
        {
            _events = new Dictionary<EventsType, EventReceiver>();
        }

        if (!_events.ContainsKey(eventType))
        {
            _events.Add(eventType, null); 
        }

        if(overwrite) _events[eventType] = listener;
        else _events[eventType] += listener; 
    }

    public static void Unsubscribe(EventsType eventType, EventReceiver listener)
    {
        if (_events != null) 
        {
            if (_events.ContainsKey(eventType))  
            {
                _events[eventType] -= listener;
            }
        }
    }


    public static void TriggerEvent(EventsType eventType, params object[] parameters)
    {
        if (_events == null) 
        {
            Debug.Log("No events subscribed");
            return; 
        }

        if (_events.ContainsKey(eventType))  
        {
            if (_events[eventType] != null)  
            {
                _events[eventType](parameters);
            }
        }
    }

    ////Sobrecarga a Trigger Event
    public static void TriggerEvent(EventsType eventType)
    {
        TriggerEvent(eventType, null);
    }
}

/// <summary>
/// EventsType define los posibles tipos de eventos
/// SPEED_MODIFIER: Modificar speed player
/// </summary>
public enum EventsType
{
    SPEED_MODIFIER,
    JUMPFORCE_MODIFIER,
    ACTIVATOR_TRIGGER,
    DESACTIVATOR_TRIGGER,
    CHECKPOINT_TRIGGER,
    MOVINGPLATFORM_TRIGGER,
}
