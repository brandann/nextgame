using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.LookRotation(Vector3.zero);
	}
	
	void LateUpdate()
	{
		//find the vector pointing from our position to the target
		//var _direction = (new Vector3(0,0,0) - transform.position).normalized;
		//transform.forward = _direction;
		//var dir = (new Vector3(0,0,0) - (transform.position * Vector3.forward));
		
		// this turns the forward vector to 0,0,0
		//transform.LookAt(new Vector3(0,0,0));
		
		var direction = (new Vector3(0,0,0) - transform.position).normalized;
		transform.up = direction;
		transform.position = direction * -1 * 50;
	}
}
