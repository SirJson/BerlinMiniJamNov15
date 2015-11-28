using UnityEngine;
using System.Collections;

public class ShieldControl : MonoBehaviour
{
    public AudioClip Clip;
   	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.layer == 10){
			Destroy(coll.gameObject);
            Function.Play2DSound(Clip);
        }
	}


}
