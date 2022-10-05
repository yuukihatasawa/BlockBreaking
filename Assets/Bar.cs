﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    float posY;

    void Start()
    {
        posY = transform.position.y;
    }

    
    void Update()
    {
        Vector3 pos = Input.mousePosition;//マウスの座標
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10));//Camera.main.ScreenToWorldPointでゲ座標をゲーム内へ変換
        targetPos.x = Mathf.Clamp(targetPos.x, -1.6f, 1.6f);//Mathf.Clampで数値の範囲を制限
        targetPos.y = posY;
        transform.position = targetPos;

    }
}
