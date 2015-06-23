using UnityEngine;
using System.Collections;

public class LocalMovement : MonoBehaviour {

	public float speed;
	public float rotateSpeed;
	private Vector3 rotationAxis;
	public float rotationAngle;
	private Vector3 position;
	private Vector3 updirection;
	private float altitude;
	private Vector3 origin;
	
	
	// Use this for initialization
	void Start () {
		rotationAxis = -1 * Vector3.up;
		altitude = 55;
		rotationAngle = 0;
		position = Vector3.up * -1 * 50;
		updirection = (origin - position).normalized * altitude;
		origin = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//check for altitude changes
		if(Input.GetKey(KeyCode.Z))
		{
			altitude += .1f;
			updirection = (origin - position).normalized * altitude;
		}
		else if(Input.GetKey(KeyCode.X))
		{
			altitude -= .1f;
			updirection = (origin - position).normalized * altitude;
		}
		
		// check for rotational changes
		if(Input.GetAxis("Horizontal") != 0) // rotational
		{
			rotationAngle += Input.GetAxis("Horizontal") * (rotateSpeed * Time.deltaTime);
		}
		
		// check for forward movement
		if(Input.GetAxis("Vertical") != 0) // movement
		{
			position += speed * Time.deltaTime * Input.GetAxis("Vertical") * (this.transform.forward);
			updirection = (origin - position).normalized * altitude;
		}
		/*
		if(Input.GetKey(KeyCode.Space)) // movement
		{
			position += speed * Time.deltaTime * 1 * (this.transform.forward);
			updirection = (origin - position).normalized * altitude;
		}
		*/
	}
	
	void LateUpdate()
	{
		transform.position = updirection;
		transform.up = updirection;
		transform.Rotate( rotationAxis, rotationAngle);
	}
}
