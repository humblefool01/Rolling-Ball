using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ballMovement : MonoBehaviour {
	public static ballMovement Instance{ set; get;}

	public GameObject ball;
	public float factor;
	public GameObject[] whiteHole;
	public GameObject[] blackHole;
	public GameObject foreGround;
	private Rigidbody rb;
	public static  bool gameOver, finish;
	public Text text;

	private void Start(){
		gameOver = false;
		finish = false;
		rb = GetComponent<Rigidbody> ();
	}
	private void Update(){

		if (gameObject.transform.position.y <= -20f) {
			foreGround.SetActive (true);
			text.text = "Game Over!\nPress 'Space' to restart";
		}
		if (!gameOver) {
			foreGround.SetActive (false);
			rb.AddForce (-Vector3.up * factor);
		}
		if (Input.GetKey (KeyCode.Space)) {
			SceneManager.LoadScene ("Scene1");
		}
	}
	private void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "blackHole") {
			int i = Random.Range (0, whiteHole.Length);
			gameObject.transform.position = whiteHole[i].transform.position;
			//rb.detectCollisions = false;
		}
		if (col.gameObject.tag == "finish") {
			rb.transform.position = new Vector3(col.transform.position.x, rb.transform.position.y, col.transform.position.z);
			gameOver = true;
			rb.velocity = Vector3.zero;
			rb.useGravity = false;
			foreGround.SetActive (true);
			text.text = "You win!\nPress 'Space' to restart";
		}
	}
}
