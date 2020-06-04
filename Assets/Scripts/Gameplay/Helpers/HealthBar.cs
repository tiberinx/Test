using UnityEngine;

namespace Gameplay.Helpers
{
    public class HealthBar : MonoBehaviour
    {
        private float _health;

        private void Update()
        {
            _health = PlayerHealth.Health;
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _health);
        }
    }
}

// Скрипт для полосы здоровья, завязанный на поле уровня здоровья из префаба игрока. Можно дублировать вместе со скриптом префаба игрока для создания босса.