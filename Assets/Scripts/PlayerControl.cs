using UnityEngine;
using System.Collections;
using PathologicalGames;

public class PlayerControl : MonoBehaviour {
	public float speed;
	public Rigidbody2D player;
	public GameObject bullet;
	public bool canShoot = true;
	public float timer = 1.0f;

	private float cooldown;
	public float lockPos = 90;


	void Start () {
		cooldown = timer;
	}
	
	void Update () {
	
		if(cooldown > 0){
			cooldown-= Time.deltaTime;
		}
		else{
			canShoot = true;
		}

		PlayerControls();
	
		if(Input.GetKey(KeyCode.Space) && canShoot){
			shoot();
			canShoot = false;
			cooldown = timer;
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
		PoolManager.Pools[PoolIdentifier.Bullets].Spawn(bullet.transform,player.position, Quaternion.identity);
	}

	void canShootAgain(){
		canShoot = true;
	}

}// eoc PlayerControl


