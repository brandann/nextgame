using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float rotateSpeed;
	public NetworkView networkView;
	
	public GameObject cam;
	
	// Use this for initialization
	void Start () {
		if(networkView.isMine)
		{
			GameObject mainCamera = GameObject.Find("Main Camera");
			mainCamera.transform.parent = this.transform;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(networkView.isMine)
		{
			if(Input.GetAxis("Horizontal") != 0) // rotational
			{
				transform.Rotate((-1 * Vector3.up), -1f * Input.GetAxis("Horizontal") * (rotateSpeed * Time.deltaTime));
			}
			if(Input.GetAxis("Vertical") != 0) // movement
			{
				transform.position += speed * Time.deltaTime * (Input.GetAxis ("Vertical")) * (this.transform.right);
			}
		}
	}
	
	
}
