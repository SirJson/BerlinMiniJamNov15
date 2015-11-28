using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


	public float speed;
	public Rigidbody2D player;
	public GameObject bullet;



	void Start () {
	
	}
	
	void Update () {
	
		PlayerControls();
	
		if(Input.GetKeyDown(KeyCode.Space)){
			shoot();
		}

	}

	
	void PlayerControls(){

		if(Input.GetKeyDown(KeyCode.RightArrow)){

			player.velocity = Vector3.right * speed;
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			
			player.velocity = Vector3.left * speed;
		}
		
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			
			player.velocity = Vector3.up * speed;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			
			player.velocity = Vector3.down * speed;
		}

	}

	void shoot(){

		Instantiate(bullet, player.position , Quaternion.identity);
	}




}// eoc PlayerControl


