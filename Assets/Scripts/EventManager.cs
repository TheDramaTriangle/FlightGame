
using System;
using System.Collections.Generic;
using UnityEngine;

/*

    The event manager handles in game events via the observer pattern. 
    
    Observers will subscribe to specific events ( defined in the GameEvent file )
    to listen on including a method to be called on that event. 

    Observers must unsubscribe to the event onDisable. 

    Subjects will notify the event manager that an event has an occured. 
    The subjects can pass in the event as a parameter (if it has data) or have no parameter if there is no data

    This allows for all observers listening to this event for its associated method to be called. 


    How to use with no data event: 

    Observer: 

    OnEnable
    {
        EventManager.Subscribe<GameEvent.EVENT-HERE>(METHOD-HERE)
    }
    OnDisable
    {
        EventManager.Unsubscribe<GameEvent.EVENT-HERE>(METHOD-HERE)
    }

    void METHOD-HERE()
    {
        // Do something 
    }

    Subject: 

    void SomeMethod()
    {
        EventManager.Notify<GameEvent.EVENT-HERE>(); 
    }


    How to use with data: 

    OnEnable
    {
        EventManager.Subscribe<GameEvent.EVENT-HERE>(METHOD-HERE)
    }
    OnDisable
    {
        EventManager.Unsubscribe<GameEvent.EVENT-HERE>(METHOD-HERE)
    }

    void METHOD(GameEvent.EVENT-HERE)
    {
        // Do something with this game event 
    }

    Subject: 

    void SomeMethod()
    {
        EventManager.Notify(new GameEvent.EVENT-HERE(SOME-PARAMETER)); 
    }


*/ 

public static class EventManager 
{
    private static readonly Dictionary<Type, Delegate> eventDictionary = new();

    public static void Subscribe<T>(Action<T> listener)
    {
        Type eventType = typeof(T);

        if (!eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] = null;
        }
        eventDictionary[eventType] = (Action<T>)eventDictionary[eventType] + listener;
    }

    public static void Unsubscribe<T>(Action<T> listener)
    {
        Type eventType = typeof(T);
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] = (Action<T>)eventDictionary[eventType] - listener;
        }
    }

    public static void Notify<T>(T eventData)
    {
        Type eventType = typeof(T);

        if (eventDictionary.ContainsKey(eventType))
        {
            var listener = (Action<T>)eventDictionary[eventType];
            listener?.Invoke(eventData);
        }
    }

    public static void Subscribe<T>(Action listener)
    {
        Type eventType = typeof(T);

        if (!eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] = null;
        }
        eventDictionary[eventType] = (Action)eventDictionary[eventType] + listener;
    }

    public static void Unsubscribe<T>(Action listener)
    {
        Type eventType = typeof(T);
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] = (Action)eventDictionary[eventType] - listener;
        }
    }

    public static void Notify<T>()
    {
        Type eventType = typeof(T);

        if (eventDictionary.ContainsKey(eventType))
        {
            var listener = (Action)eventDictionary[eventType];
            listener?.Invoke();
        }
    }
}

