using System;
using _9;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField] private string identifier;

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        
        ManagersWeather.Weather.LogWeather(identifier);
        triggered = true;
    }
}
