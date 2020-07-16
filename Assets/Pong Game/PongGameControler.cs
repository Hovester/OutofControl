using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PongGameControler : MonoBehaviour
{
    public BigBoyMaster bigBoyMaster;

    public TMP_Text ScoreUI;
    public TMP_Text TimerUI;
    public TMP_Text ObjUI;

    public float TimeSinceBeggining;
    public int MaxTime;

    public GameObject Bola;
    public GameObject P1;
    public GameObject P2;

    public int Objective;
    public int TwistObjetivoInversao;


    public void OnEnable()
    {
        Objective = Random.Range(0, 4);
        TwistObjetivoInversao = Random.Range(0, 4);
        TimeSinceBeggining = 0;
        SetarInversaodecontrole();
        UpdateScoreText();
        UpdateTimerText();
        UpdateObjectiveText();
        ResetarPosicoes();
    }

    private void Update()
    {
        UpdateTimerText();
        TimeSinceBeggining += Time.deltaTime;
        if(MaxTime< TimeSinceBeggining)
        {
            if(Objective != 3)
            {
                bigBoyMaster.LostPong();
            }
            else
            {
                bigBoyMaster.WinPong();
            }
            
        }
    }

    public void ChecarVitoria(int Lado)
    {
        if(Lado == 1)
        {
            if(Objective == 1 || Objective == 2)
            {
                bigBoyMaster.WinPong();
            }
            else
            {
                bigBoyMaster.LostPong();
            }
        }
        else
        {
            if (Objective == 0 || Objective == 2)
            {
                bigBoyMaster.WinPong();
            }
            else
            {
                bigBoyMaster.LostPong();
            }
        }
    }
    
    public void SetarInversaodecontrole()
    {
        if (TwistObjetivoInversao == 0)
        {
            P1.GetComponent<PlayerPadle>().isInvert = false;
            P2.GetComponent<PlayerPadle>().isInvert = false;
        }
        if (TwistObjetivoInversao == 1)
        {
            P1.GetComponent<PlayerPadle>().isInvert = true;
            P2.GetComponent<PlayerPadle>().isInvert = false;
        }
        if (TwistObjetivoInversao == 2)
        {
            P1.GetComponent<PlayerPadle>().isInvert = false;
            P2.GetComponent<PlayerPadle>().isInvert = true;
        }
        if (TwistObjetivoInversao == 3)
        {
            P1.GetComponent<PlayerPadle>().isInvert = true;
            P2.GetComponent<PlayerPadle>().isInvert = true;
        }
    }

    public void ResetarPosicoes()
    {
        P1.transform.position = new Vector3(-8.39F,0f,0f);
        P2.transform.position = new Vector3(8.47F, 0f, 0f);
        Bola.transform.position = new Vector3(0f, 0f, 0f);
        Bola.GetComponent<BallBoost>().Lunch();
    }

    ///UI
    public void UpdateObjectiveText()
    {
        if(Objective == 0)
        {
            ObjUI.text = ("<= Ball should exit left side");
        }
        if (Objective == 1)
        {
            ObjUI.text = ("Ball should exit right side =>");
        }
        if (Objective == 2)
        {
            ObjUI.text = ("<= Ball should exit any side =>");
        }
        if (Objective == 3)
        {
            ObjUI.text = ("X Don't Make a point X");
        }
    }
    public void UpdateScoreText()
    {
        ScoreUI.text = ("Score " + bigBoyMaster.Score);
    }
    public void UpdateTimerText()
    {
        TimerUI.text = ("Time " + RegressiveTimer());
    }

    ///UTILITYS
    public int RegressiveTimer()
    {
        return MaxTime - (int) TimeSinceBeggining;
    }
}
