using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Helpers
{
    public class PlayerScore : MonoBehaviour
    {
        public static float score;

        public static void AddRewardProperty()
        {
            score += Reward.RewardProperty;
            Reward.RewardProperty = 0;
        }

        void Update()
        {
            GetComponent<Text>().text = "Player score: " + score;
        }
    }
}

// Скрипт для отображения количества очков Игрока. Число берется из поля скрипта Reward.cs. Подсчёт осуществляется по событию после уничтожения в Spaceship.cs