using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンの読み込み機能(Unityが持っているシーンを管理する機能を使うよ)


public class GameController : MonoBehaviour
{
    public GameObject gameClearText;//GameControllerにGameClearTextインスタンスを参照するため
    public GameObject gameOverText;//gameOverTextを受け取る変数
    public GameObject ballObject;//ボールの情報
    public GameObject retryButton;
    private Rigidbody ballRigidbody;
    private Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = ballObject.GetComponent<Rigidbody>();
        ball = ballObject.GetComponent<Ball>();
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
            ballRigidbody.isKinematic = true;
            retryButton.SetActive(true);
        }

        //ボールのBallScriptの中のisDeadフラグがTrueだったとき、GameOverTextがアクティブに
        if (ball.isDead == true)
        {
            GameOver();
        }
    }

    public void Retry()
    {
        //シーンを読み込むための関数。どのシーンを呼び込むかは（）の中に
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameOver()
    {
        gameOverText.SetActive(true);
        //ゲームオーバーになったとき、ボールの動きを止める処理　isKinematic→物理演算の影響
        ballRigidbody.isKinematic = true;
        retryButton.SetActive(true);
    }


}
