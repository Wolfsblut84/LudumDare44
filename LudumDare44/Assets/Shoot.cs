using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }
    private float timer = 1.0f;
    private float waitingTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            //Action
            ShootAt(target.transform.position);// + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2)));
            timer = 0;
        }

    }



    public void ShootAt(Vector3 targetPosition)
    {
            Instantiate(projectile, transform.position, Quaternion.identity);
    }

}
