using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed = 5f;
	public float rspeed = 200f;
	public float bulletSpeed = 10f;
	
	public bool shoot = false;
	public GameObject Bullet;
	public Transform bulletpos;


	void Update()
	{
		float xInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float yInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		
		transform.Translate(xInput, 0, yInput);

		if (Input.GetButtonDown("Fire1"))
		{
			shoot = true;
		}

	}

	void Shoot()
	{
		GameObject bulletSpawn = Instantiate(Bullet, bulletpos.position, Bullet.transform.rotation);

		bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletSpeed);
	}

	void FixedUpdate()
	{
		if (shoot)
		{
			Shoot();
			shoot = false;
		}
	}

}
