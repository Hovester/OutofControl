using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPadle : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    private float movement;

    public bool isInvert;

    void Update()
    {
        movement = Input.GetAxis("Vertical");

        if (isInvert)
        {
            movement = -movement;
        }

        rb.velocity = new Vector2(0, movement * speed);
    }

}
