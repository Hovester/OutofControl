using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RitmoGameControler : MonoBehaviour
{
    public BigBoyMaster bigBoyMaster;

    public TMP_Text ScoreUI;
    public TMP_Text TimerUI;
    public TMP_Text ObjtUI;

    public float TimeSinceBeggining;
    public int MaxTime;

    public float Notescooldown;
    public float SinceLastNote;

    public int InimigosMortos;
    public int InimigosMortosObjetivo;

    public int Objective;

    public GameObject[] NotePlaces;
    public GameObject[] Boxes;
    
    public GameObject PrebafNote;
    AudioManager audioManager;


    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void OnEnable()
    {
        Objective = Random.Range(0, 6);
        SinceLastNote = 10;
        InimigosMortosObjetivo = 0;
        InimigosMortos = 0;
        TimeSinceBeggining = 0;
        UpdateScoreText();
        UpdateTimerText();
        UpdateObjetiveText();
        ResetarMapa();

        SetarObjetivo();


    }

    // Update is called once per frame
    void Update()
    {
        SinceLastNote += Time.deltaTime;
        UpdateTimerText();
        TimeSinceBeggining += Time.deltaTime;
        if (MaxTime < TimeSinceBeggining)
        {
            bigBoyMaster.LostRitm();
        }
        ChecarInvocacao();
    }
    public void SetarObjetivo()
    {

        InimigosMortosObjetivo = 3;
        if (Objective == 0)
        {
            Boxes[0].GetComponent<RitmoClicker>().SetInput(0);
            Boxes[1].GetComponent<RitmoClicker>().SetInput(1);
            Boxes[2].GetComponent<RitmoClicker>().SetInput(2);
        }
        if (Objective == 1)
        {
            Boxes[0].GetComponent<RitmoClicker>().SetInput(2);
            Boxes[1].GetComponent<RitmoClicker>().SetInput(3);
            Boxes[2].GetComponent<RitmoClicker>().SetInput(4);
        }
        if (Objective == 2)
        {
            Boxes[0].GetComponent<RitmoClicker>().SetInput(4);
            Boxes[1].GetComponent<RitmoClicker>().SetInput(2);
            Boxes[2].GetComponent<RitmoClicker>().SetInput(1);
        }
        if (Objective == 3)
        {
            Boxes[0].GetComponent<RitmoClicker>().SetInput(0);
            Boxes[1].GetComponent<RitmoClicker>().SetInput(3);
            Boxes[2].GetComponent<RitmoClicker>().SetInput(1);
        }
        if (Objective == 4)
        {
            Boxes[0].GetComponent<RitmoClicker>().SetInput(5);
            Boxes[1].GetComponent<RitmoClicker>().SetInput(6);
            Boxes[2].GetComponent<RitmoClicker>().SetInput(7);
        }
        if (Objective == 5)
        {
            Boxes[0].GetComponent<RitmoClicker>().SetInput(1);
            Boxes[1].GetComponent<RitmoClicker>().SetInput(6);
            Boxes[2].GetComponent<RitmoClicker>().SetInput(2);
        }
    }

    public void ChecarInvocacao()
    {
        if(Notescooldown < SinceLastNote)
        {
            int posvar = Random.Range(0, 3);
            Instantiate(PrebafNote, NotePlaces[posvar].transform.position, Quaternion.identity, transform);
            SinceLastNote = 0;
        }
    }

    public void ResetarMapa()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Block"))
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
    ///UI
    public void UpdateScoreText()
    {
        ScoreUI.text = ("Score " + bigBoyMaster.Score);
    }
    public void UpdateTimerText()
    {
        TimerUI.text = ("Time " + RegressiveTimer());
    }
    public void UpdateObjetiveText()
    {
        ObjtUI.text = ("Match the Rhythm of the boxes");
    }
    //UTY
    public void InimigoMorto(string SOUND)
    {
        audioManager.Play(SOUND);
        InimigosMortos += 1;
        ChecarVitoria();
    }
    public void ChecarVitoria()
    {
        if (InimigosMortos >= InimigosMortosObjetivo)
        {
            bigBoyMaster.WinRitm();
        }
    }
    public int RegressiveTimer()
    {
        return MaxTime - (int)TimeSinceBeggining;
    }
}
