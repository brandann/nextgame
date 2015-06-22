using UnityEngine;
using System.Collections;

public class InitalAlign : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var direction = (new Vector3(0,0,0) - transform.position).normalized;
		transform.up = direction;
		transform.position = direction * 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
