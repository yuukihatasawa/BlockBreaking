using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    private float playerLength;
    
    float posY;

    void Start()
    {
        posY = transform.position.y;
        playerLength = transform.localScale.x;

    }

    
    void Update()
    {
        Vector3 pos = Input.mousePosition;//マウスの座標
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10));//Camera.main.ScreenToWorldPointで座標をゲーム内へ変換
        targetPos.x = Mathf.Clamp(targetPos.x, -1.6f, 1.6f);//Mathf.Clampで数値の範囲を制限（最小と最大）
        targetPos.y = posY;
        transform.position = targetPos;

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Item")
        {
            Destroy(collider.gameObject);
            if(collider.GetComponent<Item>().itemType == Item.ItemType.ExtendBarLength)
            {
            }
        }
    }

    void ExtendBarLength()
    {
        playerLength += 0.5f;
        if (playerLength > 2.5f)
        {
            playerLength = 2.5f;
        }
        var temp = transform.localScale;
        temp.x = playerLength;
        gameObject.transform.localScale = temp;
    }

    void ShrinkBarLength()
    {
        playerLength -= 0.5f;
        if (playerLength < 1.0f)
        {
            playerLength = 1.0f;
        }
        var temp = transform.localScale;
        temp.x = playerLength;
        gameObject.transform.localScale = temp;

    }
}
