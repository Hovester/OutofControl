using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinColider : MonoBehaviour
{
    public PongGameControler pongGameControler;
    public int Lado;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Ball"))
        {
            pongGameControler.ChecarVitoria(Lado);
        }
    }
}
