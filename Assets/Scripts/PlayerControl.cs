using UnityEngine;
using System.Collections;
using PathologicalGames;

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


