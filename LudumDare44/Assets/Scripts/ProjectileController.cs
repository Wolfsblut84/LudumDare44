using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileController : MonoBehaviour
{

    public GameObject Target;
    public Vector3 targetPosition;
    AudioSource[] audioSources;


    void Awake()
    {
        Target = GameObject.Find("Player Capsule");
        targetPosition = Target.transform.position;
        this.GetComponent<Rigidbody>().AddForce((targetPosition - transform.position).normalized * 10.0f, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.name.Contains("Enemy Cylinder"))
        {
            if (other.gameObject.name == "Player Capsule")
            {
                Target.GetComponent<PlayerController>().playerHealth--;
                audioSources[1].Play();
            }
            else
            {
                audioSources[0].Play();
            }
            Destroy(this.gameObject, 0.2f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
