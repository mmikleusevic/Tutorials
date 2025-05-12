using System;
using UnityEngine;

namespace _12
{
    public class ObjectiveTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Managers.Mission.ReachObjective();
        }
    }
}