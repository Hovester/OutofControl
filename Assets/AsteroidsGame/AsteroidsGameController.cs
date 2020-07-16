using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidsGameController : MonoBehaviour
{
    public BigBoyMaster bigBoyMaster;

    public TMP_Text ScoreUI;
    public TMP_Text TimerUI;
    public TMP_Text ObjtUI;

    public float TimeSinceBeggining;
    public int MaxTime;

    public GameObject Player;
    public GameObject EnermyPrefab;

    public int InimigosMortos;
    public int InimigosMortosObjetivo;

    public int Objective;
    public int TwistObjetivoMovement;
    AudioManager audioManager;


    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void OnEnable()
    {
        Objective = Random.Range(0, 4);
        TwistObjetivoMovement = Random.Range(0, 4);
        InimigosMortosObjetivo = 0;
        InimigosMortos = 0;
        TimeSinceBeggining = 0;
        UpdateScoreText();
        UpdateTimerText();
        UpdateObjetiveText();
        ResetarMapa();

        SetarObjetivo();
        SetarTwistedMov();

    }

    // Update is called once per frame
    private void Update()
    {
        UpdateTimerText();
        TimeSinceBeggining += Time.deltaTime;
        if (MaxTime < TimeSinceBeggining)
        {
            bigBoyMaster.LostSpace();
        }
    }

    public void ChecarVitoria()
    {
        if(InimigosMortos >= InimigosMortosObjetivo)
        {
            bigBoyMaster.WinSpace();
        }
    }
    public void SetarTwistedMov()
    {
        if (TwistObjetivoMovement == 0)
        {
            Player.GetComponent<PlayerMovement>().velocity = 5f;
            Player.GetComponent<PlayerMovement>().rotatevelocity = 0.4f;
            Player.GetComponent<PlayerMovement>().isInversedForward = false;
        }
        if (TwistObjetivoMovement == 1)
        {
            Player.GetComponent<PlayerMovement>().velocity = 10f;
            Player.GetComponent<PlayerMovement>().rotatevelocity = 0.1f;
            Player.GetComponent<PlayerMovement>().isInversedForward = false;
        }
        if (TwistObjetivoMovement == 2)
        {
            Player.GetComponent<PlayerMovement>().velocity = 2f;
            Player.GetComponent<PlayerMovement>().rotatevelocity = 0.6f;
            Player.GetComponent<PlayerMovement>().isInversedForward = false;
        }
        if (TwistObjetivoMovement == 3)
        {
            Player.GetComponent<PlayerMovement>().velocity = 5f;
            Player.GetComponent<PlayerMovement>().rotatevelocity = 0.4f;
            Player.GetComponent<PlayerMovement>().isInversedForward = true;
        }
    }
    public void SetarObjetivo()
    {
        if(Objective == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(EnermyPrefab, RandomNormalPos(), Quaternion.identity,transform).GetComponent<Destruivel>().asteroidsGameController = this;
                InimigosMortosObjetivo = 2;
            }
        }
        if (Objective == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(EnermyPrefab, RandomNormalPos(), Quaternion.identity, transform).GetComponent<Destruivel>().asteroidsGameController = this;
                InimigosMortosObjetivo = 4;
            }
        }
        if (Objective == 2)
        {
            for (int i = 0; i < 6; i++)
            {
                Instantiate(EnermyPrefab, RandomNormalPos(), Quaternion.identity, transform).GetComponent<Destruivel>().asteroidsGameController = this;
                InimigosMortosObjetivo = 6;
            }
        }
        if (Objective == 3)
        {
            for (int i = 0; i < 1; i++)
            {
                Instantiate(EnermyPrefab, RandomNormalPos(), Quaternion.identity, transform).GetComponent<Destruivel>().asteroidsGameController = this;
                InimigosMortosObjetivo = 1;
            }
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
        Player.transform.position = Vector3.zero;
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
        ObjtUI.text = ("Destroy all");
    }

    ///UTILITYS
    public int RegressiveTimer()
    {
        return MaxTime - (int)TimeSinceBeggining;
    }
    public void InimigoMorto()
    {
        audioManager.Play("Explosion");
        InimigosMortos += 1;
        ChecarVitoria();
    }
    public Vector2 RandomNormalPos()
    {
        Vector2 vector2 = new Vector2(Random.Range(-7, 7), Random.Range(-4.5f, 2.5f));
        return vector2;
    }
}
