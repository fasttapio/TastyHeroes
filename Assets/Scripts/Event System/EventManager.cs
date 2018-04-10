using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class EventManager : ScriptableObject
{
    Dictionary<string, Action<EventArgs>> _eventDictionary = new Dictionary<string, Action<EventArgs>>();

    public void StartListening(object eventName, Action<EventArgs> listener)
    {
        string key = eventName.ToString();
        Action<EventArgs> thisEvent;
        if (_eventDictionary.TryGetValue(key, out thisEvent))
        {
            //Add more event to the existing one
            thisEvent += listener;

            //Update the Dictionary
            _eventDictionary[key] = thisEvent;
        }
        else
        {
            //Add event to the Dictionary for the first time
            thisEvent += listener;
            _eventDictionary.Add(key, thisEvent);
        }
    }

    public void StopListening(object eventName, Action<EventArgs> listener)
    {
        string key = eventName.ToString();
        Action<EventArgs> thisEvent;
        if (_eventDictionary.TryGetValue(key, out thisEvent))
        {
            //Remove event from the existing one
            thisEvent -= listener;

            //Update the Dictionary
            _eventDictionary[key] = thisEvent;
        }
    }

    public void TriggerEvent(object eventName, EventArgs eventParam)
    {
        string key = eventName.ToString();
        Action<EventArgs> thisEvent = null;
        if (_eventDictionary.TryGetValue(key, out thisEvent))
        {
            thisEvent.Invoke(eventParam);
        }
    }
}
