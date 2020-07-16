using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RitmoClicker : MonoBehaviour
{
    public RitmoGameControler ritmoGameControler;

    public int InputSelector;
    string InputName;

    public TMP_Text InputText;

    public bool MomentofClick;
    Transform Target;

    public bool gracetime;
    public float gracetimecooldown;
    public float Sincebegingracetime;

    public string Songname;

    void Update()
    {
        Sincebegingracetime += Time.deltaTime; 
        Gracetimechecker();
        if (MomentofClick)
        {
            ///print("Moment");
            if (Input.GetKeyDown(InputName))
            {
                ritmoGameControler.InimigoMorto(Songname);
                Destroy(Target.gameObject);
                gracetime = true;
                Sincebegingracetime = 0;
            }
        }
        if (Input.GetKeyDown(InputName) && MomentofClick == false && gracetime == false)
        {
            ritmoGameControler.bigBoyMaster.LostRitm();
        }

    }
    public void Gracetimechecker()
    {
        if(Sincebegingracetime > gracetimecooldown)
        {
            gracetime = false;
        }
    }

    public void SetInput(int input)
    {
        InputSelector = input;
        if (InputSelector == 0)
        {
            InputName = ("h");
            InputText.text = ("h");
        }
        if (InputSelector == 1)
        {
            InputName = ("w");
            InputText.text = ("w");
        }
        if (InputSelector == 2)
        {
            InputName = ("a");
            InputText.text = ("a");
        }
        if (InputSelector == 3)
        {
            InputName = ("d");
            InputText.text = ("d");
        }
        if (InputSelector == 4)
        {
            InputName = ("s");
            InputText.text = ("s");
        }
        if (InputSelector == 5)
        {
            InputName = ("t");
            InputText.text = ("t");
        }
        if (InputSelector == 6)
        {
            InputName = ("m");
            InputText.text = ("m");
        }
        if (InputSelector == 7)
        {
            InputName = ("z");
            InputText.text = ("z");
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        MomentofClick = true;
        Target = collision.transform;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        MomentofClick = false;
    }  
}

