using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterController : MonoBehaviour
{
    // Attribute für Bots
    public int BotCounter;
    public int BotsInGoal;
    public GameObject particle;
    public GameObject Menu;
    public bool startGame;

    //public GameObject GoalText;


    // Start is called before the first frame update
    void Start()
    {
        //this.Menu.SetActive(true);
        //this.startGame = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (BotsInGoal == 4)
        {
            //GoalText.SetActive(true);
        }

        //if (Input.GetButtonDown("Start Game") )
        //{
        //    startGame = true;
        //}
    }


    public void SetBotsInGoal(int value)
    {

        this.particle.SetActive(true);
        this.particle.gameObject.GetComponent<ParticleSystem>().Play();
        BotsInGoal += value;
        BotCounter -= value;
    }


    public int GetBotsInGoal()
    {
        return this.BotsInGoal;
    }
}
