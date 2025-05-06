using System;
using System.Xml;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class WeatherManager : MonoBehaviour, IGameManagerWeather
{
    public ManagerStatusWeather status { get; private set; }

    private NetworkService network;
    
    public float cloudValue { get; private set; }
    
    public void Startup(NetworkService service)
    {
        Debug.Log("Weather manager starting...");
        
        network = service;
        StartCoroutine(network.GetWeatherJSON(OnJsonDataLoaded));
        status = ManagerStatusWeather.Initializing;
    }

    public void OnXMLDataLoaded(string data)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);
        XmlNode root = doc.DocumentElement;
        
        XmlNode node = root.SelectSingleNode("clouds");
        string value = node.Attributes["value"].Value;
        cloudValue = Convert.ToInt32(value) / 100f;
        
        Debug.Log($"Value: {cloudValue}");
        
        MessengerWeather.Broadcast(GameEventWeather.WEATHER_UPDATED);
        
        status = ManagerStatusWeather.Started;
    }
    
    public void OnJsonDataLoaded(string data)
    {
        JObject root = JObject.Parse(data);
        
        JToken clouds = root["clouds"];
        cloudValue = (float) clouds["all"] / 100f;
        
        Debug.Log($"Value: {cloudValue}");
        
        MessengerWeather.Broadcast(GameEventWeather.WEATHER_UPDATED);
        
        status = ManagerStatusWeather.Started;
    }

    public void LogWeather(string name)
    {
        StartCoroutine(network.LogWeather(name, cloudValue, OnLogged));
    }

    private void OnLogged(string response)
    {
        Debug.Log(response);
    }
}
