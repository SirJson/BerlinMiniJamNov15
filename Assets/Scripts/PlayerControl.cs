using UnityEngine;
using System.Collections;
using PathologicalGames;

public class PlayerControl : MonoBehaviour {


	public float speed;
	public Rigidbody2D player;
	public GameObject bullet;

	public float lockPos = 90;


	void Start () {
	
	}
	
	void Update () {
	
		PlayerControls();
	
		if(Input.GetKeyDown(KeyCode.Space)){
			shoot();
		}


		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);

	}

	
	void PlayerControls(){

		if(Input.GetKey(KeyCode.RightArrow)){

			player.AddForce(Vector3.right * speed);
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			
			player.AddForce(Vector3.left * speed);
		}
		
		if(Input.GetKey(KeyCode.UpArrow)){
			
			player.AddForce(Vector3.up * speed);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			
			player.AddForce(Vector3.down * speed);
		}

	}

	void shoot(){

		var clone = PoolManager.Pools[PoolIdentifier.Bullets].Spawn(bullet.transform,player.position, Quaternion.identity);

		PoolManager.Pools[PoolIdentifier.Bullets].Despawn(clone, 3);
	}

	void OnCollisionEnter2D(Collision2D coll){
		
		if(coll.gameObject.layer == 9){
			gameOver();
		}
	}

	void gameOver(){
			Destroy(this);
		Application.LoadLevel("gameOver");
	}

}// eoc PlayerControl


