using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterController : MonoBehaviour
{
    // Attribute für Bots
    public int BotCounter;
    private int BotsInGoal;
    public GameObject particle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SetBotInGoal(int value)
    {
        BotsInGoal += value;
        this.particle.SetActive(true);
        this.particle.gameObject.GetComponent<ParticleSystem>().Play();
    }


    public int GetBotInGoal()
    {
        return this.BotsInGoal;
    }
}
