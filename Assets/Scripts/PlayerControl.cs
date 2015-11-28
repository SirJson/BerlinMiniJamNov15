using UnityEngine;
using System.Collections;
using PathologicalGames;

public class PlayerControl : MonoBehaviour {
	public float speed;
	public Rigidbody2D player;
	public GameObject bullet;
	public bool canShoot = true;
	public float timer = 1.0f;
	public float shieldDuration = 5.0f;
    public AudioClip Death;
    public AudioClip Fire;
    public bool Dead = false;

	private float cooldown;
	public float lockPos = 90;

	public GameObject shield;


	void Start () {
		cooldown = timer;
	}

    public void OnDeath()
    {
        Function.Play2DSound(Death);
        Dead = true;
    }
	
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.S)){
			makeShield();
		}

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
		var a = PoolManager.Pools[PoolIdentifier.Bullets].Spawn(bullet.transform, player.position, Quaternion.identity);
        Function.Play2DSound(Fire);
	}

	void canShootAgain(){
		canShoot = true;
	}


	void makeShield(){
		if(Game.shieldPoints >= 1){
			var clone = PoolManager.Pools[PoolIdentifier.Shield].Spawn(shield.transform,player.position,Quaternion.identity);
			PoolManager.Pools[PoolIdentifier.Shield].Despawn(clone, shieldDuration);
			Game.shieldPoints = 0;
		}
	}

}// eoc PlayerControl


