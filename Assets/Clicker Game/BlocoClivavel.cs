using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoClivavel : MonoBehaviour
{
    public ClickerGameControler clickerGameControler;
    public int colorID; 

    void OnMouseDown()
    {
        clickerGameControler.Clicou(colorID);
        Destroy(this.gameObject);
    }
}
