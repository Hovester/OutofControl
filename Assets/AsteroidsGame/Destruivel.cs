using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruivel : MonoBehaviour
{

    public AsteroidsGameController asteroidsGameController;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == ("Damager"))
        {
            asteroidsGameController.InimigoMorto();
            if(collision.transform.name != ("UltimateBomb"))
            {
                Destroy(collision.transform.gameObject);
            }
            Destroy(this.gameObject);
        }

    }
}
