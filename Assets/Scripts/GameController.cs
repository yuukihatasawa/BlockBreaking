using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameClearText;//GameControllerにGameClearTextインスタンスを参照するため
    public GameObject gameOverText;//gameOverTextを受け取る変数
    public GameObject ball;//ボールの情報

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
            //最初に無効にしていたチェックボックスに再びチェックをつけることができる。true（SetActive）
            gameClearText.SetActive(true);
            ball.GetComponent<Rigidbody>().isKinematic = true;
        }
        //ボールのBallScriptの中のisDeadフラグがTrueだったとき、GameOverTextがアクティブに
        if (ball.GetComponent<Ball>().isDead == true)
        {
            gameOverText.SetActive(true);
            //ゲームオーバーになったとき、ボールの動きを止める処理
            ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
