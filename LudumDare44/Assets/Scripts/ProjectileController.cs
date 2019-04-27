using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileController : MonoBehaviour
{

    public GameObject Target;
    public Vector3 targetPosition;

    void Awake()
    {
        Target = GameObject.Find("Player Capsule");
        targetPosition = Target.transform.position;
        this.GetComponent<Rigidbody>().AddForce((targetPosition - transform.position).normalized * 10.0f, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "Enemy Cylinder")
        {
            Destroy(this.gameObject, 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
