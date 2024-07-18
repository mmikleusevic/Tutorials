using System;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class Subject : MonoBehaviour
    {
        // define an event with your own delegate
        //public delegate void ExampleDelegate();
        //public static event ExampleDelegate ExampleEvent;

        //... or just use the System.Action
        public event Action ThingHappened;

        // invoke the event to broadcast to any listeners/observers
        public void DoThing()
        {
            ThingHappened?.Invoke();
        }
    }
}

