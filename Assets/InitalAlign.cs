using UnityEngine;
using System.Collections;

public class InitalAlign : MonoBehaviour {

    public GameObject sphere;

	// Use this for initialization
	void Start () {
		var direction = (new Vector3(0,0,0) - transform.position).normalized;
		transform.up =  -1 * direction;
        transform.position = direction * -1 * (sphere.transform.localScale.x / 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
