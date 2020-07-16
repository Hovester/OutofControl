using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tr;

    float movementY;
    float movementX;

    public float velocity;
    public float rotatevelocity;

    public bool isInversedForward;

    public GameObject Bullet;
    public Transform FirePoint;
    public Transform FirePoint2;
    public Transform BombPoint;
    public float ShootCooldown;
    public float TimeSinceLastShoot;
    public float BulletSpeed;
    public float bulletlifetime;

    public GameObject UltimateBomb;
    public float bomblifetime;
    AudioManager audioManager;


    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceLastShoot += Time.deltaTime;

        movementY = Input.GetAxis("Vertical");
        movementX = -Input.GetAxis("Horizontal");

        if (isInversedForward)
        {
            movementY = -movementY;
        }

        rb.velocity = this.transform.up.normalized * movementY *velocity;
        rb.AddTorque(movementX*rotatevelocity);
        
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetButton("Jump") || Input.GetButton("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            ShootUltimateBomb();
        }
    }

    public void ShootUltimateBomb()
    {
        audioManager.Play("Explosion");
        GameObject Bomb = Instantiate(UltimateBomb, BombPoint.position, Quaternion.identity);
        Destroy(Bomb, bomblifetime);
    }
    public void Shoot()
    {
        if(TimeSinceLastShoot >= ShootCooldown)
        {
            audioManager.Play("Shoot");

            GameObject bulletfired = Instantiate(Bullet,FirePoint.position,Quaternion.identity,this.transform);
            bulletfired.GetComponent<Rigidbody2D>().AddForce(transform.up.normalized * BulletSpeed, ForceMode2D.Impulse);
            Destroy(bulletfired, bulletlifetime);

            GameObject bulletfired2 = Instantiate(Bullet, FirePoint2.position, Quaternion.identity, this.transform);
            bulletfired2.GetComponent<Rigidbody2D>().AddForce(transform.up.normalized * BulletSpeed, ForceMode2D.Impulse);
            Destroy(bulletfired2, bulletlifetime);

            TimeSinceLastShoot = 0;
        }
    }
}
