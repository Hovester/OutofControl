using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StonksGameControler : MonoBehaviour
{
    /*
    public BigBoyMaster bigBoyMaster;

    public TMP_Text TimerTextUI;
    public TMP_Text ScoreTextUI;
    public GameObject[] PriceUnits;

    public float TimeSinceBeggining;
    public int MaxTime;

    /// <summary>
    /// CLICK34 = 0
    /// PONG07 = 1
    /// BOMN11 = 2
    /// RNG666 = 3
    /// GMTK20 = 4
    /// </summary>

    public int[] Quantitys;
    public float[] CurrentPrices;
    public float[] VariationofPrices;
    AudioManager audioManager;


    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void OnEnable()
    {
        TimeSinceBeggining = 0;
        UpdateScore();
        RecalculatePrices();
        UpdatePriceUnits();
    }

    void Update()
    {
        UpdateTimerText();
        TimeSinceBeggining += Time.deltaTime;
        if (MaxTime < TimeSinceBeggining)
        {
            bigBoyMaster.EndStocks();
        }
    }


    //CALCULATIONS
    public void RecalculatePrices()
    {
        for(int i = 0; i < PriceUnits.Length; i++)
        {
            float variation = Random.Range(0.5f, 1.5f);

            if (i < 3)
            {
                VariationofPrices[i] = variation;
            }
            else
            {
                if (i == 3)
                {
                    variation = Random.Range(0.01f, 2f);
                }
                if (i == 4)
                {
                    variation = Random.Range(0.8f, 2f);
                }
                VariationofPrices[i] = variation;
            }

            CurrentPrices[i] = CurrentPrices[i] * VariationofPrices[i];
            CurrentPrices[i] = Mathf.Round(CurrentPrices[i]);
        }
    }
    ///COMPRAS E VENDAS
    public void BuyingStocks(int ID)
    {
        //Checar Se tem Money
        if(bigBoyMaster.Score > CurrentPrices[ID])
        {
            audioManager.Play("Menu");
            Quantitys[ID] += 1;
            bigBoyMaster.IncreaseScore((int) -CurrentPrices[ID]);
            UpdatePriceUnits();
            UpdateScore();
        }
    }
    public void BuyingStocks10(int ID)
    {
        //Checar Se tem Money
        if (bigBoyMaster.Score > 10*CurrentPrices[ID])
        {
            audioManager.Play("Menu");
            Quantitys[ID] += 10;
            bigBoyMaster.IncreaseScore((int)-CurrentPrices[ID]*10);
            UpdatePriceUnits();
            UpdateScore();
        }
    }
    public void SellStocks(int ID)
    {
        //Checar se tem pra vender
        if (Quantitys[ID] > 0)
        {
            audioManager.Play("Menu");
            bigBoyMaster.IncreaseScore((int)CurrentPrices[ID]);
            Quantitys[ID] -= 1;
            UpdatePriceUnits();
            UpdateScore();
        }
    }
    public void SellStocks10(int ID)
    {
        //Checar se tem pra vender
        if (Quantitys[ID] > 9)
        {
            audioManager.Play("Menu");
            bigBoyMaster.IncreaseScore((int)CurrentPrices[ID] * 10);
            Quantitys[ID] -= 10;
            UpdatePriceUnits();
            UpdateScore();
        }
    }

    ///UI
    public void UpdateTimerText()
    {
        TimerTextUI.text = ("Time " + RegressiveTimer());
    }
    public void UpdateScore()
    {
        ScoreTextUI.text = ("Score " + bigBoyMaster.Score.ToString());
    }
    public void UpdatePriceUnits()
    {
        for (int i = 0; i < PriceUnits.Length; i++)
        {
            PriceUnits[i].transform.Find("PriceByUnit").GetComponent<TMP_Text>().text = (CurrentPrices[i] + " Scores");
            PriceUnits[i].transform.Find("IncreaseSinceLast").GetComponent<TMP_Text>().text = (Mathf.Round(VariationofPrices[i]*100) + " %");
            
            //CORES E SIMBOLOS
            if(Mathf.Round(VariationofPrices[i] * 100)>= 100)
            {
                PriceUnits[i].transform.Find("PriceByUnit").GetComponent<TMP_Text>().faceColor = Color.green;
                PriceUnits[i].transform.Find("IncreaseSinceLast").GetComponent<TMP_Text>().faceColor = Color.green;
                PriceUnits[i].transform.Find("IncreaseSinceLast").transform.Find("RepresentationUP").gameObject.SetActive(true);
                PriceUnits[i].transform.Find("IncreaseSinceLast").transform.Find("RepresentationDown").gameObject.SetActive(false);
            }
            else
            {
                PriceUnits[i].transform.Find("PriceByUnit").GetComponent<TMP_Text>().faceColor = Color.red;
                PriceUnits[i].transform.Find("IncreaseSinceLast").GetComponent<TMP_Text>().faceColor = Color.red;
                PriceUnits[i].transform.Find("IncreaseSinceLast").transform.Find("RepresentationUP").gameObject.SetActive(false);
                PriceUnits[i].transform.Find("IncreaseSinceLast").transform.Find("RepresentationDown").gameObject.SetActive(true);
            }

            PriceUnits[i].transform.Find("Have").GetComponent<TMP_Text>().text = ("You have " + Quantitys[i]);
        }
    }


    //UTILITYS
    public int RegressiveTimer()
    {
        return MaxTime - (int)TimeSinceBeggining;
    }
    public void ResetarValores()
    {
        for(int i = 0; i < Quantitys.Length;i++)
        {
            Quantitys[i] = 0;  
        }

        CurrentPrices[0] = 5;
        CurrentPrices[1] = 10;
        CurrentPrices[2] = 20;
        CurrentPrices[3] = 15;
        CurrentPrices[4] = 60;
    }
    */
}
