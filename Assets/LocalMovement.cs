using UnityEngine;
using System.Collections;

public class LocalMovement : MonoBehaviour {

	public float speed;
	public float rotateSpeed;
	public bool Gravity;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetAxis("Horizontal") != 0) // rotational
		{
			transform.Rotate((-1 * Vector3.up), -1f * Input.GetAxis("Horizontal") * (rotateSpeed * Time.deltaTime));
		}
		if(Input.GetAxis("Vertical") != 0) // movement
		{
			transform.position += speed * Time.deltaTime * (Input.GetAxis ("Vertical")) * (this.transform.forward);
		}
	}
	
	void LateUpdate()
	{
		if(Gravity)
		{
			var direction = (new Vector3(0,0,0) - transform.position).normalized;
			transform.up = direction;
			transform.position = direction * -1 * 50;
		}
	}
}
