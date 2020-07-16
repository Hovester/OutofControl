using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndControler : MonoBehaviour
{
    public float TimeToEnd;
    public bool isWon;
    public int Score;

    public TMP_Text MainText;

    public void SetarEndControler(float TimeToEndGame,bool Won,int ScoreReached)
    {
        TimeToEnd = TimeToEndGame;
        isWon = Won;
        Score = ScoreReached;
        UpdateUI();


    }

    public void UpdateUI()
    {
        if (isWon)
        {
            if (Mathf.RoundToInt(TimeToEnd) <= 40)
            {
                MainText.text = ("You reached the goal in " + Mathf.RoundToInt(TimeToEnd) + " seconds.. Leaving this message here just as a token.. of course noone will ever read it.. Less than 40 seconds its unreachable");
            }
            if (Mathf.RoundToInt(TimeToEnd) > 40 && Mathf.RoundToInt(TimeToEnd) <= 60)
            {
                MainText.text = ("You reached the goal in " + Mathf.RoundToInt(TimeToEnd) + " seconds.. Impossible... You MUST be Cheating !!");
            }
            if (Mathf.RoundToInt(TimeToEnd) > 60 && Mathf.RoundToInt(TimeToEnd) <= 80)
            {
                MainText.text = ("You reached the goal in " + Mathf.RoundToInt(TimeToEnd) + " seconds.. You probably got lucky... You bastard");
            }
            if (Mathf.RoundToInt(TimeToEnd) > 80 && Mathf.RoundToInt(TimeToEnd) <= 110)
            {
                MainText.text = ("Congratz i hope you enjoyed You reached the goal in " + Mathf.RoundToInt(TimeToEnd) + " seconds Why not try to reach a better time ?");
            }

            if (Mathf.RoundToInt(TimeToEnd) > 110)
            {
                MainText.text = ("And in the lasts sconds you got it congratz i hope you enjoyed You reached the goal in " + Mathf.RoundToInt(TimeToEnd) + " seconds if you want... you can try do reach a better time. But i don't think you are up to the task");
            }
        }
        else
        {
            if(Score > 200)
            {
                MainText.text = ("You got " + Score + " Score points You din't reached the goal of 250 Score Points, You were soooo close.. Try again...and get better to the CHAOS of being out of control");
            }
            else
            {
                MainText.text = ("You got " + Score + " Score points You din't reached the goal of 250 Score Points, Don't give up. This game was made so you could try again and get better to the CHAOS of being out of control");
            }
        }
    }
}
