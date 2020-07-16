using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasciEnermyMov : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        Lunch();
    }
    public void Lunch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(speed * x, speed * y);
    }
}
