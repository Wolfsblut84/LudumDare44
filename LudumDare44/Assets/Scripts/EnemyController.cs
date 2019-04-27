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

    // Start is called before the first frame update
    void Start()
    {
        //gameMaster
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= 5)
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                //Action
                Shoot(target.transform.position + new Vector3(Random.Range(-2 , 2) , Random.Range(-2, 2) , Random.Range(-2, 2)));
                timer = 0;

            }
        }

    }

    void FixedUpdate()
    {

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