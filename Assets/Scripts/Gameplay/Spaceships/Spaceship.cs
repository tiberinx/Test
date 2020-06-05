using Gameplay.Helpers;
using Gameplay.ShipControllers;
using Gameplay.ShipControllers.CustomControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {

        // Создаём события для подсчёта очков за уничтоженные корабли.
        UnityEvent RewardEvent = new UnityEvent();
        UnityEvent PlayerScoreEvent = new UnityEvent();

        // Создаём событие конца игры при поражении.
        UnityEvent GameOverEvent = new UnityEvent();        

        [SerializeField]
        private ShipController _shipController;

        [SerializeField]
        private MovementSystem _movementSystem;

        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        // Количество здоровья корабля.
        [SerializeField]
        public float health;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;



        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);

            // Назначаем слушателей в Reward.cs, PlayScore.cs и GameOverScreen.cs.
            RewardEvent.AddListener(Reward.Listen);
            PlayerScoreEvent.AddListener(PlayerScore.AddRewardProperty);
            GameOverEvent.AddListener(GameOverScreen.GameOver);           

        }

        private int _hitpoint = 2;
        public void ApplyDamage(IDamageDealer damageDealer)
        {
            if (health > 0)
            {
                // Уменьшаем уровень здоровья после урона.
                health -= damageDealer.Damage;
            }
            if (health <= 0)
            {
                if (gameObject.tag == "Player")
                {
                    
                    Destroy(gameObject);
                    // Остановка игры после смерти Игрока.
                    Time.timeScale = 0;
                    //Вызываем событие конца игры при поражении.
                    GameOverEvent.Invoke();                   
                    
                }
                else
                {
                    Destroy(gameObject);
                    _hitpoint--;            // Убираем баг с задвоением очков при одновременном попадании более одного снаряда
                    if (_hitpoint > 0)
                    {
                        //Вызываем события для подсчёта очков Игрока.
                        RewardEvent.Invoke();
                        PlayerScoreEvent.Invoke();
                    }

                }
                


            }

        }

    }
}
