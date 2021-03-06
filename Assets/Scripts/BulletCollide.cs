﻿using UnityEngine;
using System.Collections;

public class BulletCollide : MonoBehaviour 
{

	public float Velocity = .5f; 
	public float SecToDest = 15f;
	private float startTime; 
	public float damage;

	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "environment") 
		{
			//needs to leave scorch marks	
		}

		if (other.gameObject.tag == "Enemy") 
		{
			other.gameObject.GetComponent<AlienSoldierBehaviour>().TakeDamage(damage);
		}

		//no matter what the bullet hits it should be destroyed
		Destroy (this.gameObject);
	
	}// end OnTrigger Function
	

	// Update is called once per frame
	void Update () 
	{
		//move forward
		this.gameObject.transform.position += Velocity * this.gameObject.transform.forward;

		//if the bullet exists too long it must be destroyed 
		if (Time.time - startTime >= SecToDest) 
		{
			Destroy (this.gameObject); 
		}
	
	}// end void update

	void OnCollisionEnter(Collision other)
	{
		Destroy (this.gameObject);
	}

}// end public Class BulletCollide
