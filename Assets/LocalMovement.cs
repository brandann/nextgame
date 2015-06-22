using UnityEngine;
using System.Collections;

public class LocalMovement : MonoBehaviour {

	public float speed;
	public float rotateSpeed;
	public bool Gravity;
	private Vector3 rotationAxis;
	private float rotationAngle;
	private Vector3 position;
	private Vector3 updirection;
	
	// Use this for initialization
	void Start () {
		rotationAxis = -1 * Vector3.up;
		rotationAngle = 0;
		position = Vector3.up * -1 * 50;
		updirection = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		//Vector3 gravityDirection = (transform.position - new Vector3(0,0,0)).normalized;
		//GetComponent<Rigidbody>().AddForce(Vector3.forward * -1, ForceMode.Acceleration);
		
		if(Input.GetAxis("Horizontal") != 0) // rotational
		{
			rotationAngle += -1f * Input.GetAxis("Horizontal") * (rotateSpeed * Time.deltaTime);
		}
		if(Input.GetAxis("Vertical") != 0) // movement
		{
			position += speed * Time.deltaTime * (Input.GetAxis ("Vertical")) * (this.transform.forward);
			updirection = (new Vector3(0,0,0) - position).normalized;
		}
	}
	
	void LateUpdate()
	{
		transform.position += position;
		transform.position = updirection * -1 * 50;
		transform.up = updirection;
		transform.Rotate( rotationAxis, rotationAngle);
		
		if(Gravity)
		{
			var direction = (new Vector3(0,0,0) - transform.position).normalized;
			transform.up = direction;
			transform.position = direction * -1 * 50;
		}
	}
}
