using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update


    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        //Camera.main.fieldOfView = 95;
        this.transform.position = new Vector3(target.transform.position.x , target.transform.position.y + 8, -20f);
        this.transform.LookAt(target.transform.position);
    }
}
