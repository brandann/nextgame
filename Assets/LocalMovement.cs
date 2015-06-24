using UnityEngine;
using System.Collections;

public class LocalMovement : MonoBehaviour {

	public float speed;
	public float rotateSpeed;
	public GameObject sphere;
	
	private Vector3 rotationAxis;
	private float rotationAngle;
	private Vector3 position;
	private Vector3 updirection;
	private float altitude;
	private Vector3 origin;
    private bool rotating;
    private float gravityFactor = .05f;
    private float altitudeFactor = .2f;
    private float altitudeMax = 30;
    private float altitudeMin = 0;

	
	// Use this for initialization
	void Start () {
		rotationAxis = -1 * Vector3.up;
		altitude = sphere.transform.localScale.x / 2;
		rotationAngle = 0;
		origin = new Vector3(0,0,0);
        position = Vector3.up * -1 * (sphere.transform.localScale.x / 2) + Vector3.forward * 60;
		updirection = (origin - position).normalized * altitude;
        rotating = false;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//check for altitude changes
		if(Input.GetKey(KeyCode.Z))	{ altitude += altitudeFactor; }
		if(Input.GetKey(KeyCode.X)) { altitude -= altitudeFactor; }
		altitude -= gravityFactor;
		altitude = Mathf.Clamp(altitude, (sphere.transform.localScale.x / 2) + altitudeMin, (sphere.transform.localScale.x / 2) + altitudeMax);
		
		// check for forward movement and for rotational changes
		rotationAngle -= Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
		position += speed * Time.deltaTime * -1 * Input.GetAxis("Vertical") * this.transform.forward;
		updirection = (origin - position).normalized * altitude;
		
		// make transform changes
		transform.up = updirection;
		transform.position = updirection;
		transform.Rotate(rotationAxis, rotationAngle);
	}
}
