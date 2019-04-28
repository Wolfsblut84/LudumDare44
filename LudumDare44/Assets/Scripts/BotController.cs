using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public GameObject target;

    private GameObject enemy;
    public GameObject explosion;

    public bool isAngry;

    // Start is called before the first frame update
    public bool isCollected = false;
    private float minDistance = 1.6f;
    private float maxDistance = 5f;
    private float moveSpeed = 8f;

    private List<GameObject> colliders = new List<GameObject>();

    // wofür war das
    private int myCount = 1;

    private bool isInGoal = false;

    public GameObject masterObject;
    AudioSource[] audioSources;



    void Start()
    {
        moveSpeed = target.GetComponent<PlayerController>().Speed;
        audioSources = GetComponents<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Enemy Cylinder"))
        {
            colliders.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Enemy Cylinder"))
        {
            colliders.Remove(other.gameObject);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        int botCounter = masterObject.gameObject.GetComponent<GameMasterController>().BotCounter;

        if (other.gameObject.name.Contains("Enemy Cylinder") && isAngry)
        {
            Destroy(enemy);
            Destroy(this.gameObject);
        }
        // Bots sammeln
        else if (other.gameObject.name.Contains("Player Capsule") && botCounter < 3 && isCollected == false)
        {
            this.isCollected = true;
            masterObject.gameObject.GetComponent<GameMasterController>().BotCounter++;
            myCount = masterObject.gameObject.GetComponent<GameMasterController>().BotCounter;

            audioSources[0].Play();

        }
        // Wenn Bots im Ziel sind
        else if (other.gameObject.name.Equals("Goal"))
        {

            // Bot richtig ins Ziel schieben
            transform.position += Vector3.left * 2;

            // Damit man die wieder anpacken kann wenn 2 im Ziel sind
            this.isCollected = false;
            this.isInGoal = true;

            this.masterObject.gameObject.GetComponent<GameMasterController>().SetBotsInGoal(1);

            //this.masterObject.gameObject.GetComponent<GameMasterController>().BotCounter --;

            audioSources[1].Play();

            if (masterObject.gameObject.GetComponent<GameMasterController>().GetBotsInGoal() == 4)
            {

            }
        }

    }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private void SetAngry()
    {
        isAngry = true;

        foreach (var item in colliders)
        {
            if (item.gameObject.name == "Enemy Cylinder")
            {
                enemy = item.gameObject;
                break;
            }
        }

        if (enemy == null)
        {
            isAngry = false;
        }

    }


    // Update is called once per frame
    void Update()
    {

        if (isAngry && enemy != null)
        {
            transform.position = Vector3.Lerp(this.transform.position, enemy.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            //isAngry = false;
            // Bots einsammeln
            if (isCollected && isInGoal == false)
            {
                if (target != null)
                {
                    if (Vector3.Distance(transform.position, target.transform.position) >= minDistance + myCount * 0.8f && Vector3.Distance(transform.position, target.transform.position) <= maxDistance)
                    {
                        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + new Vector3(0, 0.1f, 0), moveSpeed * Time.deltaTime);
                    }

                    // Wenn Bot stehen bleibt abziehen
                    else if (Vector3.Distance(transform.position, target.transform.position) > maxDistance )
                    {

                        this.isCollected = false;
                        this.masterObject.gameObject.GetComponent<GameMasterController>().BotCounter -= 1;
                    }
                }
            }

            // Bots Parken
            if (Input.GetButtonDown("E Parking"))
            {
                this.isCollected = false;
                this.masterObject.gameObject.GetComponent<GameMasterController>().BotCounter = 0;
            }

            if (Input.GetButtonDown("Q Attack") && isCollected)
            {
                if (!isAngry)
                {
                    SetAngry();
                }
            }
        }



    }
}
