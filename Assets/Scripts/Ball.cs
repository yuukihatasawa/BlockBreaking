using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //ボールが生きているかどうかを管理する変数。
    public bool isDead = false;

    // プログラムが起動した直後、一回処理
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(100, -100, 0));//AddForse　力を加える処理
    }

    // ゲーム中繰り返し処理
    void Update()
    {
        
    }

    //ボールがなにかにぶつかった時にだけ処理される
    private void OnCollisionEnter(Collision collision)
    {
        //ぶつかった相手のタグがブロックなら。CompareTagcがタグが正しいか判断してる
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);//物を壊す
        }
        //GameObject.nameでWall_bottomだったら、ボールが死ぬ（true）。
        if (collision.gameObject.name == "Wall_Bottom")
        {
            isDead = true;
        }

    }



}
