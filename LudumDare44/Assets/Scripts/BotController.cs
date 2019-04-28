using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    public bool isCollected = false;
    private float minDistance = 1.6f;
    private float maxDistance = 5f;
    private float moveSpeed = 8f;



    // wofür war das
    private int myCount = 1;

    private bool isInGoal = false;

    public GameObject masterObject;



    void Start()
    {
        moveSpeed = target.GetComponent<PlayerController>().Speed;
    }



    private void OnCollisionEnter(Collision other)
    {
        int botCounter = masterObject.gameObject.GetComponent<GameMasterController>().BotCounter;

        // Bots sammeln
        if (other.gameObject.name.Contains("Player Capsule") && botCounter < 2 && isCollected == false)
        {
            this.isCollected = true;
            masterObject.gameObject.GetComponent<GameMasterController>().BotCounter += 1;
            myCount = masterObject.gameObject.GetComponent<GameMasterController>().BotCounter;

        }

        // Wenn Bots im Ziel sind
        else if (other.gameObject.name.Equals("Goal"))
        {

            this.isInGoal = true;

            // Bot richtig ins Ziel schieben
            transform.position += Vector3.left * 2;

            // Damit man die wieder anpacken kann wenn 2 im Ziel sind
            masterObject.gameObject.GetComponent<GameMasterController>().SetBotsInGoal(1);



            //masterObject.gameObject.GetComponent<GameMasterController>().SetBotsInGoal(1);
            Debug.Log(masterObject.gameObject.GetComponent<GameMasterController>().GetBotsInGoal());

           
            this.isCollected = false;


            if (masterObject.gameObject.GetComponent<GameMasterController>().GetBotsInGoal() == 4)
            {
               
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Bots einsammeln
        if (isCollected && isInGoal == false)
        {
            if (Vector3.Distance(transform.position, target.transform.position) >= minDistance + myCount * 0.8f && Vector3.Distance(transform.position, target.transform.position) <= maxDistance)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + new Vector3(0, 0.1f, 0), moveSpeed * Time.deltaTime);
            }
        }

        // Bots Parken
        if (Input.GetButtonDown("E"))
        {
            this.isCollected = false;
            this.masterObject.gameObject.GetComponent<GameMasterController>().BotCounter = 0;
        }

    }
}
