using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToIntroFromMain : MonoBehaviour
{
    public GameObject Intro;
    public GameObject Main;

    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void ButtonPushed()
    {
        audioManager.Play("Menu");
        Intro.SetActive(true);
        Main.SetActive(false);
    }

}
