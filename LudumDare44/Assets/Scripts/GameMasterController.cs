using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterController : MonoBehaviour
{
    // Attribute für Bots
    public int BotCounter;
    public int BotsInGoal;
    public GameObject particle;
    public GameObject explosion;
    public GameObject target;

    //public GameObject GoalText;


    // Start is called before the first frame update
    void Start()
    {
        //GoalText.SetActive(false);
        this.explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (BotsInGoal == 4)
        {
            //GoalText.SetActive(true);
        }

        if (target.GetComponent<PlayerController>().playerHealth <= 0)
        {
            this.explosion.SetActive(true);
            this.explosion.transform.position = new Vector3(target.transform.position.x -1,target.transform.position.y,target.transform.position.z);
        }

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
