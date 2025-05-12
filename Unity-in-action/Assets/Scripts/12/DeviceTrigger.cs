using UnityEngine;

namespace _12
{
    using System;
    using _9;
    using UnityEngine;

    public class DeviceTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject[] targets;
        [SerializeField] private bool requireKey;

        private void OnTriggerEnter(Collider other)
        {
            if (requireKey && Managers.Inventory.equippedItem != "key") return;
        
            foreach (var target in targets)
            {
                target.SendMessage("Activate");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            foreach (var target in targets)
            {
                target.SendMessage("Deactivate");
            }
        }
    }

}