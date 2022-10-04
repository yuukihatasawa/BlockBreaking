using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // プログラムが起動した直後、一回処理
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(100, -100, 0));//AddForse　力を加える処理
    }

    // ゲーム中繰り返し処理
    void Update()
    {
        
    }
}
