using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {

	private Animator animator;

	void Awake()
	{
		animator = GetComponentInParent<Animator> ();
		animator.SetBool ("isPressed", false);
	}


	void Start()
	{
		//Physics.IgnoreCollision (transform.parent.GetComponent<Collider>(), GetComponent<Collider>());
	}


	// Use this for initialization
	void OnCollisionEnter (Collision col) {
	
		if (col.gameObject.name == "Player Capsule") 
		{
			animator.SetTrigger("isPressed");
		}
	}

	void OnCollisionStay (Collision col) 
	{
		foreach (ContactPoint contact in col.contacts) {
						Debug.DrawRay (contact.point, contact.normal * 10, Color.white);
				}
	}

	void OnCollisionExit (Collision col) {
		
		if (col.gameObject.name == "Player Capsule") 
		{
			//animator.SetTrigger("isPressed");
			animator.SetBool ("isPressed", false);
		}
	}

}
