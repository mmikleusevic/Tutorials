using System;

namespace DesignPatterns.Strategy
{

    public static class GameEvents
    {
        public static event Action OnCollectibleCollected = delegate { };

        public static void CollectibleCollected()
        {
            OnCollectibleCollected();
        }
    }
}
