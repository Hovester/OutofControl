using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportaroutrolado : MonoBehaviour
{
    float ScreanTop;
    float ScreanBot;
    float ScreanLeft;
    float ScreanRight;
    private void Start()
    {
        ScreanTop = 5f;
        ScreanBot = -5f;
        ScreanLeft = -8.8f;
        ScreanRight = +8.8f;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == ("Damager"))
        {
            Destroy(collision.transform.gameObject);
        }
        else
        {
            if (collision.transform.position.y > ScreanTop)
            {
                collision.transform.position = new Vector3(collision.transform.position.x, ScreanBot, 0f);
            }
            if (collision.transform.position.y < ScreanBot)
            {
                collision.transform.position = new Vector3(collision.transform.position.x, ScreanTop, 0f);
            }

            if (collision.transform.position.x < ScreanLeft)
            {
                collision.transform.position = new Vector3(ScreanRight, collision.transform.position.y, 0f);
            }
            if (collision.transform.position.x > ScreanRight)
            {
                collision.transform.position = new Vector3(ScreanLeft, collision.transform.position.y, 0f);
            }
        }
    }
}
