using UnityEngine;
using System.Collections;

public class PlayerFPMovement : MonoBehaviour {

	public float speed;
	public float rotateSpeed;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate((-1 * Vector3.up), -1f * Input.GetAxis("Horizontal") * (rotateSpeed * Time.deltaTime));
		transform.position += speed * Time.deltaTime * (Input.GetAxis ("Vertical")) * (this.transform.right);
	}
}
