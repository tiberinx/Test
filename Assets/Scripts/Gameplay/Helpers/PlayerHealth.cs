using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Helpers
{
    public class PlayerHealth : MonoBehaviour
    {
        public static float Health { get; set; }

        private void Update()
        {
            Health = GetComponent<Spaceship>().health;
        }
    }
}

// Скрипт для префаба игрока. Поле для привязки чего-либо на уровне здоровья.