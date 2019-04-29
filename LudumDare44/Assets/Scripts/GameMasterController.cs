using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMasterController : MonoBehaviour
{
    // Attribute für Bots
    public int BotsCount4Win;
    public int BotCounter;
    public int BotsInGoal;
    public GameObject particle;
    //public GameObject Menu;
    public bool startGame;
    public Text botsText;
    public int nextLevel;
    
    public GameObject panelWin;
    public GameObject panelGameOver;
    public GameObject panelPause;
    public Text timerText;

    private bool isPaused = false;

    private float GameTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if(BotsInGoal == BotsCount4Win)
        {
            panelWin.SetActive(true);

            GameTime += Time.deltaTime;

            if(GameTime > 5.0f)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }

        if (panelGameOver.activeSelf == true)
        {
            GameTime += Time.deltaTime;


            string sec = string.Format("{0}", 5 - (int)GameTime);
            timerText.text = sec;

            if (GameTime > 5.0f)
            {
                SceneManager.LoadScene(nextLevel-1);
            }
        }


        if(Input.GetButtonDown("Pause"))
        {
            if(isPaused == true)
            {
                isPaused = false;
                Time.timeScale = 1;
                panelPause.SetActive(false);
            }
            else
            {
                isPaused = true;
                Time.timeScale = 0;
                panelPause.SetActive(true);
            }
        }

        if(Input.GetButtonDown("Jump") && panelPause.activeSelf == true)
        {
            SceneManager.LoadScene(0);
        }

    }


    public void SetBotsInGoal(int value)
    {

        this.particle.SetActive(true);
        this.particle.gameObject.GetComponent<ParticleSystem>().Play();
        BotsInGoal += value;
        BotCounter -= value;

        botsText.text = "Bots saved: " + BotsInGoal;
    }


    public int GetBotsInGoal()
    {
        return this.BotsInGoal;
    }
}
