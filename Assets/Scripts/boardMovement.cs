using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardMovement : MonoBehaviour {
	public static boardMovement Instance{ set; get;}

	private Rigidbody rb;
	public float factor;
	public float rotationFactor;
	public GameObject rotatingWall;

	private void Start(){
		rb = GetComponent<Rigidbody> ();
	}
	private void Update(){

		rotatingWall.transform.Rotate (0f, -rotationFactor * Time.deltaTime, 0f);

		if (Input.GetKey (KeyCode.LeftArrow) && (transform.rotation.eulerAngles.z <= 20f || transform.rotation.eulerAngles.z >= 330f)) {
			transform.Rotate (0f, 0f, factor*Time.deltaTime, Space.Self);
		}
		if (Input.GetKey (KeyCode.RightArrow) && (transform.rotation.eulerAngles.z >= 340f || transform.rotation.eulerAngles.z <= 30f)) {
			transform.Rotate (0f, 0f, -factor*Time.deltaTime, Space.Self);
		}
		if (Input.GetKey (KeyCode.UpArrow) && (transform.rotation.eulerAngles.x >= 330f || transform.rotation.eulerAngles.x <= 20f)) {
			transform.Rotate (factor*Time.deltaTime, 0f, 0f, Space.Self);
		}
		if (Input.GetKey (KeyCode.DownArrow) && (transform.rotation.eulerAngles.x >= 340f || transform.rotation.eulerAngles.x <= 30f)) {
			transform.Rotate (-factor*Time.deltaTime, 0f, 0f, Space.Self);
		}
	
	}
}
