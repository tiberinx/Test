using Gameplay.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBoundaries : MonoBehaviour
{
    private static Camera _camera;
    private static Vector3 camPos;
    private static float camHalfHeight, camHalfWidth, leftBound, rightBound, playerWidth;


    void Start()
    {
        // Определяем края экрана. Код взят из GameAreaHelper.IsInGameplayArea.
        _camera = Camera.main;
        camPos = _camera.transform.position;

        camHalfHeight = _camera.orthographicSize;
        camHalfWidth = camHalfHeight * _camera.aspect;

        leftBound = camPos.x - camHalfWidth;
        rightBound = camPos.x + camHalfWidth;

        // Ширина Игрока от центра до края
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;

        //Граница экрана с учетом ширины Игрока, чтобы не вылезал наполовину.
        leftBound += playerWidth;
        rightBound -= playerWidth;
    }


    void LateUpdate()
    {
        //Не даём вылезти игроку за границы экрана.
        var _transPos = transform.position;
        _transPos = new Vector3(Mathf.Clamp(_transPos.x, leftBound, rightBound), _transPos.y, _transPos.z);
        transform.position = _transPos;
    }
}
