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
        // Определяем края экрана. Код взят из GameAreaHelper.IsInGameplayArea
        _camera = Camera.main;
        camPos = _camera.transform.position;
        camHalfHeight = _camera.orthographicSize;
        camHalfWidth = camHalfHeight * _camera.aspect;
        leftBound = camPos.x - camHalfWidth;
        rightBound = camPos.x + camHalfWidth;

        // Граница объекта Игрок
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }


    void LateUpdate()
    {
        //Не даём вылезти игроку за границы экрана. Если не учитывать ширину объекта Игрок, он будет вылезать за экран наполовину. Поэтому leftBound + playerWidth, rightBound - playerWidth
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBound + playerWidth, rightBound - playerWidth ), transform.position.y, transform.position.z);

    }
}
