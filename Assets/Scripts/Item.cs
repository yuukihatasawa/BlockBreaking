using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        ExtendBarLength,
        ShrinkBarLength,
    }
    public ItemType itemType;

    Rigidbody rb;
    Vector3 vector;
    float itemSpeed = -1.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vector = new Vector3(0, itemSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = vector;
    }
}
