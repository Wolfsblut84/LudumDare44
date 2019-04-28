using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject gameMaster;

    public GameObject projectile;

    public int projectileCount = 0;

    public GameObject target;

    // Punkte die dem Spieler abgezogen werden
    public int playerDamage;

    private float timer = 1.0f;
    public float waitingTime;

    // Lebenspunkte vom Gegner
    public int enemyLife;


    private Rigidbody enemyRigidbody;
    private int movementValue;
    private float timeTilNextMovement;
    private bool isMoving;
    private float movementSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        timeTilNextMovement -= Time.deltaTime;
        if (timeTilNextMovement < 0)
        {
            MakeMovementDecision(false);
        }

        if (Vector3.Distance(transform.position, target.transform.position) <= 5)
        {

            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                //Action
                Shoot(target.transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2)));
                timer = 0;
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        float oldMovement = movementValue;

        while (movementValue == oldMovement)
        {
            MakeMovementDecision(true);
        }
    }


    private void MakeMovementDecision(bool hasCollide)
    {
        movementValue = Random.Range(0, 5);
        if (!hasCollide)
        {
            timeTilNextMovement = Random.Range(0.2f, 2.0f);
        }
    }

    void FixedUpdate()
    {

        switch (movementValue)
        {
            case 0:
                //IDLE
                isMoving = false;
                enemyRigidbody.velocity = Vector2.zero;
                break;
            case 1:
                //RIGHT
                isMoving = true;
                enemyRigidbody.AddForce(Vector3.right * (movementSpeed * Time.fixedDeltaTime), ForceMode.VelocityChange);
                break;
            case 2:
                //LEFT
                isMoving = true;
                enemyRigidbody.AddForce(Vector3.left * (movementSpeed * Time.fixedDeltaTime), ForceMode.VelocityChange);
                break;
            case 3:
                //RIGHT
                isMoving = true;
                enemyRigidbody.AddForce(Vector3.forward * (movementSpeed * Time.fixedDeltaTime), ForceMode.VelocityChange);
                break;
            case 4:
                //LEFT
                isMoving = true;
                enemyRigidbody.AddForce(Vector3.back * (movementSpeed * Time.fixedDeltaTime), ForceMode.VelocityChange);
                break;
        }

    }

    public void Shoot(Vector3 targetPosition)
    {
        if (projectileCount == 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }

    public void Explode()
    {

    }
}