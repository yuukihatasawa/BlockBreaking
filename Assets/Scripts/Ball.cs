using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Rigidbodyを何度か使用するために、変数にする
    Rigidbody rb;
    public bool isDead = false;     //ボールが生きているかどうかを管理する変数。
    [SerializeField]
    private float speed = 3.0f;      //速度
    [SerializeField]
    private float accelSpeed = 0.5f; //加速度
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private GameObject extendBarItem;
    [SerializeField]
    private GameObject shrinkBarItem;
    [SerializeField]
    private GameObject createBallItem;

    bool isStart = false;           //動き始めたかの管理

    // プログラムが起動した直後、一回処理
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // ゲーム中繰り返し処理
    void Update()
    {
        if (isStart == false && Input.GetMouseButtonDown(0))
        {
            isStart = true;  //falseが力が入っていない状態。Trueが力が入っている状態。
            rb.AddForce(new Vector3(1, -1, 0) * speed, ForceMode.VelocityChange);//AddForse　力を加える処理

        }

    }

    //ボールがなにかにぶつかった時にだけ処理される
    private void OnCollisionEnter(Collision collision)
    {
        //ぶつかった相手のタグがブロックなら。CompareTagcがタグが正しいか判断してる
        if (collision.gameObject.CompareTag("Block"))
        {
            scoreManager.AddScore();
            Destroy(collision.gameObject);//物を壊す
            GameObject explosion = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
            explosion.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

            //1/5の確率でアイテム出現
            if (Random.Range(0,5) == 0)
            {
                CreateItem();
            }
        }
        //GameObject.nameでWall_bottomだったら、ボールが死ぬ（true）。
        if (collision.gameObject.name == "Wall_Bottom")
        {
            isDead = true;
        }
        //Barとぶつかったときの処理
        if(collision.gameObject.name == "Bar")
        {
            speed += accelSpeed;//加速度を足した値がspeedに保存される
            Reflect(collision);
        }

    }

    private void Reflect(Collision collision)
    {
        scoreManager.ResetCombo();
        Vector3 vec = transform.position - collision.transform.position;//跳ね返す処理 ボールの座標　–　バーの座標でボールとバーの中心の座標を引く
        rb.velocity = Vector3.zero;//一旦、ボールの移動量を０にしなければいけない
        rb.AddForce(vec.normalized * speed, ForceMode.VelocityChange);//normalizedは、大きさを１に統一

    }

    private void CreateItem()
    {

        //1/2の確率でアイテムの種類を決める
        switch (Random.Range(0, 3))
        {
            case 0:
                Instantiate(extendBarItem, gameObject.transform.position, Quaternion.identity);

                break;

            case 1:
                Instantiate(shrinkBarItem, gameObject.transform.position, Quaternion.identity);
                break;

            case 2:
                Instantiate(createBallItem,gameObject.transform.position,Quaternion.identity);
                break;

            default:
                break;
        }
     }

}
