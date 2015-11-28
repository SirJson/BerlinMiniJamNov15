using UnityEngine;
using System.Collections;
using PathologicalGames;

public class BulletControl : MonoBehaviour {

    public AudioClip Kill;
	public float bulletSpeed;


	void Start () {
	
	}
	
	void Update () {

		GetComponent<Rigidbody2D>().velocity = Vector3.left * bulletSpeed;

	}



	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.layer == 10){
			Destroy(coll.gameObject);
            Function.Play2DSound(Kill);
            		PoolManager.Pools[PoolIdentifier.Bullets].Despawn(transform);
			Game.shieldPoints++;
        	}
	}

}
