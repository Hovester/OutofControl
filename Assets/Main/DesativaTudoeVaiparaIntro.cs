using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativaTudoeVaiparaIntro : MonoBehaviour
{
    public GameObject EndGame;
    public GameObject BigBoss;
    public GameObject Intro;

    AudioManager audioManager;


    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }


    public void ClckRecomeçar()
    {
        audioManager.Play("Menu");

        Intro.SetActive(true);
        EndGame.SetActive(false);
        BigBoss.SetActive(false);
    }
}
