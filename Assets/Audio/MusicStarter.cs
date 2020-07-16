using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    public AudioManager audioManager;

    void Start()
    {
        audioManager.Play("Maximum_Overdrive");
    }
}
