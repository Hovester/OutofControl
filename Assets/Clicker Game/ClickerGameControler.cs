using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickerGameControler : MonoBehaviour
{

    public BigBoyMaster bigBoyMaster;

    public int Objective;
    public int TwistObjetivo;

    float TimeSinceTheBeggining;
    public int MaxTime;

    public TMP_Text ScoreText;
    public TMP_Text TimerText;
    public TMP_Text ObjectiveText;

    public GameObject[] Blocos;

    public void OnEnable()
    {
        TimeSinceTheBeggining = 0;
        Objective = Random.Range(0, 8);
        TwistObjetivo = Random.Range(0, 5);
        UpdateObjectiveUI();
        UpdateScoreUI();
        ResetarBlocos();
        InvokarBlocos();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceTheBeggining += Time.deltaTime;
        if(TimeSinceTheBeggining > MaxTime)
        {
            Loss();
        }
        UpdateTimerUI();
    }


    ////UI
    public void UpdateScoreUI()
    {
        ScoreText.text = ("Score " + bigBoyMaster.Score);
    }
    public void UpdateTimerUI()
    {
        TimerText.text = ("Time " + RegressiveTimer().ToString());
    }
    public void UpdateObjectiveUI()
    {
        if( Objective == 0)
        {
            ObjectiveText.text = ("Click Red Box");
        }
        if (Objective == 1)
        {
            ObjectiveText.text = ("Click Blue Box");
        }
        if (Objective == 2)
        {
            ObjectiveText.text = ("Click Black Box");
        }
        if (Objective == 3)
        {
            ObjectiveText.text = ("Click White Box");
        }
        if (Objective == 4)
        {
            ObjectiveText.text = ("Click Red Circle");
        }
        if (Objective == 5)
        {
            ObjectiveText.text = ("Click Blue Circle");
        }
        if (Objective == 6)
        {
            ObjectiveText.text = ("Click Black Circle");
        }
        if (Objective == 7)
        {
            ObjectiveText.text = ("Click White Circle");
        }
    }

    //// Setar
    

    public void ResetarBlocos()
    {
        foreach (Transform child in transform)
        {
            if(child.CompareTag("Block"))
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    public void InvokarBlocos()
    {
        if(TwistObjetivo == 0)
        {
            Instantiate(Blocos[Objective], RandomNormalPos(), Quaternion.identity,transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
        }
        if (TwistObjetivo == 1)
        {     
            Instantiate(Blocos[AleatorioDiferentedeObjetivo(Objective)], RandomNormalPos(), Quaternion.identity,transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
            Instantiate(Blocos[AleatorioDiferentedeObjetivo(Objective)], RandomNormalPos(), Quaternion.identity, transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
            Instantiate(Blocos[AleatorioDiferentedeObjetivo(Objective)], RandomNormalPos(), Quaternion.identity, transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
            Instantiate(Blocos[AleatorioDiferentedeObjetivo(Objective)], RandomNormalPos(), Quaternion.identity, transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
            Instantiate(Blocos[Objective], RandomNormalPos(), Quaternion.identity, transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
        }
        if (TwistObjetivo == 2)
        {
            for(int i = 0; i < 20; i++)
            {
                Instantiate(Blocos[AleatorioDiferentedeObjetivo(Objective)], RandomNormalPos(), Quaternion.identity, transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
            }
            Instantiate(Blocos[Objective], RandomNormalPos(), Quaternion.identity, transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
        }
        if (TwistObjetivo == 3)
        {
            for (int i = 0; i < 50; i++)
            {
                Instantiate(Blocos[AleatorioDiferentedeObjetivo(Objective)], RandomNormalPos(), Quaternion.identity, transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
            }
            Instantiate(Blocos[Objective], RandomNormalPos(), Quaternion.identity, transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
        }
        if (TwistObjetivo == 4)
        {
            for (int i = 0; i < 70; i++)
            {
                Instantiate(Blocos[AleatorioDiferentedeObjetivo(Objective)], RandomNormalPos(), Quaternion.identity, transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
            }
            Instantiate(Blocos[Objective], RandomNormalPos(), Quaternion.identity, transform).GetComponent<BlocoClivavel>().clickerGameControler = this;
        }
    }

    //Utilitys

    public Vector2 RandomNormalPos()
    {
        Vector2 vector2 = new Vector2(Random.Range(-7, 7), Random.Range(-4, 2));
        return vector2;
    }

    public int RegressiveTimer()
    {
        return MaxTime - (int)TimeSinceTheBeggining;
    }

    public void Win()
    {
        bigBoyMaster.WinCliquer();
    }
    public void Loss()
    {
        bigBoyMaster.LostCliquer();
    }
    public int AleatorioDiferentedeObjetivo(int ObjID)
    {
        int potencial = Random.Range(0, Blocos.Length);
        while(potencial == ObjID)
        {
            potencial = Random.Range(0, Blocos.Length);
        }
        return potencial;

    }


    ///
    public void Clicou(int ColorID)
    {
        if(ColorID == Objective)
        {
            Win();
        }
        else
        {
            Loss();
        }
    }
}
