using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorController : MonoBehaviour
{
    public GameObject portal;
    public ButtonBehaviour button1;
    public ButtonBehaviour button2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(button1.isActivated && button2.isActivated)
        {
            Destroy(portal);
        }
    }

}
