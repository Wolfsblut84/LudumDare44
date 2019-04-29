using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {

	private Animator animator;

    public Material redMaterial;
    public Material greenMaterial;

    public bool isActivated;

	void Awake()
	{
		animator = GetComponentInParent<Animator> ();
		animator.SetBool ("isPressed", false);
	}


	void Start()
	{
		Physics.IgnoreCollision (transform.parent.GetComponent<Collider>(), GetComponent<Collider>());
	}


	// Use this for initialization
	void OnCollisionEnter (Collision col) {
	
		if (col.gameObject.name == "Player Capsule" || col.gameObject.name.Contains("Bot")) 
		{
			animator.SetTrigger("isPressed");
            this.gameObject.GetComponent<MeshRenderer>().material = greenMaterial;
		}
	}

	void OnCollisionStay (Collision col) 
	{
		foreach (ContactPoint contact in col.contacts) {
						Debug.DrawRay (contact.point, contact.normal * 10, Color.white);
				}
        isActivated = true;
	}

	void OnCollisionExit (Collision col) {
		
		if (col.gameObject.name == "Player Capsule" || col.gameObject.name.Contains("Bot"))
        {
			//animator.SetTrigger("isPressed");
			animator.SetBool ("isPressed", false);
            this.gameObject.GetComponent<MeshRenderer>().material = redMaterial;
        }
        isActivated = false;
	}

}
