using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace _9
{
    [RequireComponent(typeof(WeatherManager))]
    [RequireComponent(typeof(ImagesManager))]
    public class ManagersWeather : MonoBehaviour
    {
        public static WeatherManager Weather { get; private set; }
        public static ImagesManager Images { get; private set; }
        
        private List<IGameManagerWeather> startSequence;

        private void Awake()
        {
            Weather = GetComponent<WeatherManager>();
            Images = GetComponent<ImagesManager>();

            startSequence = new List<IGameManagerWeather>();
            startSequence.Add(Weather);
            startSequence.Add(Images);

            StartCoroutine(StartupManagers());
        }

        private IEnumerator StartupManagers()
        {
            NetworkService network = new NetworkService();
            
            foreach (IGameManagerWeather manager in startSequence)
            {
                manager.Startup(network);
            }
            
            yield return null;
            
            int numModules = startSequence.Count;
            int numReady = 0;

            while (numReady < numModules)
            {
                int lastReady = numReady;
                numReady = 0;

                foreach (IGameManagerWeather manager in startSequence)
                {
                    if (manager.status == ManagerStatusWeather.Started)
                    {
                        numReady++;
                    }
                }

                if (numReady > lastReady)
                {
                    Debug.Log($"Progress: {numReady}/{numModules}");
                }

                yield return null;
            }
            
            Debug.Log("All managers started up");
        }
    }
}