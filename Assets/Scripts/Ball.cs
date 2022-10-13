using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Rigidbodyを何度か使用するために、変数にする
    Rigidbody rb;

    //ボールが生きているかどうかを管理する変数。
    public bool isDead = false;

    // プログラムが起動した直後、一回処理
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(150, -150, 0));//AddForse　力を加える処理
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
        //Barとぶつかったときの処理
        if(collision.gameObject.name == "Bar")
        {
            //跳ね返す処理 ボールの座標　–　バーの座標でボールとバーの中心の座標を引く
            Vector3 vec = transform.position - collision.transform.position;
            rb.velocity = Vector3.zero;//一旦、ボールの移動量を０にしなければいけない
            rb.AddForce(vec.normalized * 150);//normalizedは、大きさを１に統一
        }

    }



}
