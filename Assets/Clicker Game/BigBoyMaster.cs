using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BigBoyMaster : MonoBehaviour
{
    public float TimeSinceBeginOfTheGame;
    public float GameTime;

    public TMP_Text GameTimeUI;


    public GameObject[] Games;
    public int Score;
    public int ObjetivodeScore;


    public GameObject EndGameScream;
    AudioManager audioManager;

    public bool GameEnd;

    void OnEnable()
    {
        GameEnd = false;
        Score = 0;
        TimeSinceBeginOfTheGame = 0;
        ChangeToRandomGame();
    }

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (GameEnd == false)
        {
            TimeSinceBeginOfTheGame += Time.deltaTime;
            float RecursiveTime = GameTime - TimeSinceBeginOfTheGame;

            if (RecursiveTime < 0)
            {
                audioManager.Play("Negative");
                ToEnd(false);
            }

            GameTimeUI.text = Mathf.RoundToInt(RecursiveTime).ToString();
        }
    }
    //END
    public void ToEnd(bool Won)
    {
        GameEnd = true;
        foreach (GameObject gameObject in Games)
        {
            gameObject.SetActive(false);
        }
        GameTimeUI.gameObject.SetActive(false);
        EndGameScream.SetActive(true);
        EndGameScream.GetComponent<EndControler>().SetarEndControler(TimeSinceBeginOfTheGame, Won, Score);
    }

    //RESULTS
    public void LostRitm()
    {
        audioManager.Play("Negative");
        Games[3].SetActive(false);
        ChangeToRandomGame();
    }
    public void WinRitm()
    {
        IncreaseScore(10);
        audioManager.Play("Positive");
        Games[3].SetActive(false);
        ChangeToRandomGame();

    }
    public void LostSpace()
    {
        audioManager.Play("Negative");
        Games[2].SetActive(false);
        ChangeToRandomGame();
    }
    public void WinSpace()
    {
        IncreaseScore(10);
        audioManager.Play("Positive");
        Games[2].SetActive(false);
        ChangeToRandomGame();
        
    }
    public void LostPong()
    {
        audioManager.Play("Negative");
        Games[1].SetActive(false);
        ChangeToRandomGame();
    }
    public void WinPong()
    {
        IncreaseScore(10);
        audioManager.Play("Positive");
        Games[1].SetActive(false);
        ChangeToRandomGame();
        
    }
    public void LostCliquer()
    {
        audioManager.Play("Negative");
        Games[0].SetActive(false);
        ChangeToRandomGame();
    }
    public void WinCliquer()
    {
        IncreaseScore(10);
        audioManager.Play("Positive");
        Games[0].SetActive(false);
        ChangeToRandomGame();
        
    }

    //Utilitys
    public void IncreaseScore(int ScoreToIncrease)
    {
        Score += ScoreToIncrease;

        if(Score >= ObjetivodeScore)
        {
            audioManager.Play("Positive");
            ToEnd(true);  
        }
    }
    public void ChangeToRandomGame()
    {
        if(GameEnd == false)
        {
            int GametoGo = Random.Range(0, Games.Length);

            ///DELETAR ISSO
            ///GametoGo = 3;

            for (int i = 0; i < Games.Length; i++)
            {
                if (i == GametoGo)
                {
                    Games[i].SetActive(true);
                }
                else
                {
                    Games[i].SetActive(false);
                }
            }
        }
    }
}
