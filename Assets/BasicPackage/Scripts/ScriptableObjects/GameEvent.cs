using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Event", menuName = "Basic/Game Event")]
public class GameEvent : ScriptableObject {
    
    [HideInInspector]
    public List<GameEventListener> listeners = new List<GameEventListener>(); //remove public 
    //public UnityEvent OnRaise;

    public void Raise()
    {
        //if (OnRaise != null)
            //OnRaise.Invoke();

        for (int i = listeners.Count-1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
        else
            Debug.Log("Listener is already registered");
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }

}
