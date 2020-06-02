using UnityEngine;

namespace Gameplay.Helpers
{
    public class Reward : MonoBehaviour
    {
        public static float RewardProperty { get; set; }
        private static float reward;

        [SerializeField]
        private float _reward;

        private void Start()
        {
            reward = _reward;
        }

        public static void Listen()
        {
            RewardProperty = reward;
        }

    }
}

// Скрипт для установки размера награды за уничтожение.