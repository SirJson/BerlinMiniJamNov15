using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hasShield : MonoBehaviour {

	public GameObject obj;
	public Image shield;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Game.shieldPoints >= 2){
			shield.enabled= true;
		}
		else{
			shield.enabled = false;
		}
	}


}
