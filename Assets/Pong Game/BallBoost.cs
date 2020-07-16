using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBoost : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    AudioManager audioManager;


    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void Lunch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(speed * x, speed * y);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Teste");
        audioManager.Play("Colision");
    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Teste");
        audioManager.Play("Colision");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Teste");
        audioManager.Play("Colision");
    }

}
