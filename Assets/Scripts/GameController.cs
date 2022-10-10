using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameClearText;//GameControllerにGameClearTextインスタンスを参照するため

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ブロックを全て習得させる
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 0)
        {
            gameClearText.SetActive(true);//最初に無効にしていたチェックボックスに再びチェックをつけることができる。
        }
    }
}
