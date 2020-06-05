using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EnemyShipController : ShipController
{

    [SerializeField]
    private Vector2 _fireDelay;

    // Выбираем, в каком направлении двигаться противнику.
    public bool MoveRight;
    public bool MoveLeft;


    private bool _fire = true;
    
    protected override void ProcessHandling(MovementSystem movementSystem)
    {

         movementSystem.LongitudinalMovement(Time.deltaTime);

        // Меняем направление движения противника.

        if (MoveRight)
        {
            movementSystem.LateralMovement(Time.deltaTime);
        }
        if (MoveLeft)
        {
            movementSystem.LateralMovement(Time.deltaTime * -1);
        }

    }

    protected override void ProcessFire(WeaponSystem fireSystem)
    {
        if (!_fire)
            return;

        fireSystem.TriggerFire();
        StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
    }


    private IEnumerator FireDelay(float delay)
    {
        _fire = false;
        yield return new WaitForSeconds(delay);
        _fire = true;
    }
}
