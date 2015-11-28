using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {


	public float bulletSpeed;


	void Start () {
	
	}
	
	void Update () {

		GetComponent<Rigidbody2D>().velocity = Vector3.left * bulletSpeed;
	}
		
}
