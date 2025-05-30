using UnityEngine;

namespace _12
{
    public class ColorChangeDevice : BaseDevice
    {
        public override void Operate()
        {
            Color random = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            GetComponent<Renderer>().material.color = random;
        }
    }
}