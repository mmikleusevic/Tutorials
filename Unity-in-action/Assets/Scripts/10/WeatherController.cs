using System;
using _9;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    [SerializeField] private Material sky;
    [SerializeField] private Light sun;
    
    private float fullIntensity;

    private void Start()
    {
        fullIntensity = sun.intensity;
    }

    private void OnEnable()
    {
        MessengerWeather.AddListener(GameEventWeather.WEATHER_UPDATED, OnWeatherUpdated);
    }

    private void OnDisable()
    {
        MessengerWeather.RemoveListener(GameEventWeather.WEATHER_UPDATED, OnWeatherUpdated);
    }

    private void OnWeatherUpdated()
    {
        SetOvercast(ManagersWeather.Weather.cloudValue);
    }

    private void SetOvercast(float value)
    {
        sky.SetFloat("_Blend", value);
        sun.intensity = fullIntensity - (fullIntensity * value);
    }
}
