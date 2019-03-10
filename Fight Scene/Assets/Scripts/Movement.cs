using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed = 5f;
	public float rspeed = 90f;
	Rigidbody rb;
	public GameObject bullet;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		float xInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		float yInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		float zInput = Input.GetAxis("Jump") * rspeed * Time.deltaTime;

		transform.Rotate(0, zInput, 0);

		transform.Translate(xInput, 0, yInput);

		if (Input.GetMouseButtonDown(0))
		{
			Instantiate(bullet, transform.position, Quaternion.identity);

		}
	}

}
