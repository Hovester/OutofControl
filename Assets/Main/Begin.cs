using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : MonoBehaviour
{
    public GameObject Intro;
    public GameObject BigBoss;
    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void ClickBegin()
    {
        audioManager.Play("Menu");
        Intro.SetActive(false);
        BigBoss.SetActive(true);
    }
}
