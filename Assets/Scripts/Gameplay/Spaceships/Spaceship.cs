using System;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {

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
        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {
            if (health > 0)
            {
                // Уменьшаем уровень здоровья после урона.
                health -= damageDealer.Damage;
            }
            else
            {
                Destroy(gameObject);
            }

        }

    }
}
