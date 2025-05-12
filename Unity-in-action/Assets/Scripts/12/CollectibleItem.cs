using _9;
using UnityEngine;

namespace _12
{
    public class CollectibleItem : MonoBehaviour
    {
        [SerializeField] private string itemName;

        void OnTriggerEnter(Collider other)
        {
            Managers.Inventory.AddItem(itemName);
            Destroy(gameObject);
        }
    }
}