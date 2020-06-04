using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gameplay.Helpers
{
    public class GameOverScreen : MonoBehaviour
    {
        public Text _totalScore;
        private Text totalScoreValue;
        private static GameObject _gameobject;

        // Метод для onClick события кнопки перезапуска игры.
        public void RestartGame()
        {
            
            DontDestroyOnLoad(GameAreaHelper._camera);
            Destroy(GameAreaHelper._camera.GetComponent<AudioListener>());

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            PlayerScore.score = 0;
            Time.timeScale = 1;
            
        }

        
        public void Start()
        {
            // Выключение экрана конца игры при поражении на старте/перезапуске игры.
            _gameobject = gameObject;
            _gameobject.SetActive(false);

            // Отображение набранных очков в окне конца игры при поражнеии.
            totalScoreValue = _totalScore.GetComponent<Text>();
            totalScoreValue.text = "Total score: " + PlayerScore.score;
        }

        public void Update()
        {
            totalScoreValue.text = "Total score: " + PlayerScore.score;
        }

        // Включение экрана конца игры при поражении
        public static void GameOver()
        {
            _gameobject.SetActive(true);
        }
    }
}

// Скрипт для UI элемента - GameOverScreen. Отвечает за отображение набранных очков и перезапуск игры по кнопке