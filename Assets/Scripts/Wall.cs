using UnityEngine;
using System.Collections;
using PathologicalGames;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 10)
        {
            Destroy(coll.gameObject);
        }
        if(coll.gameObject.layer == 12)
        {
            PoolManager.Pools[PoolIdentifier.Bullets].Despawn(coll.gameObject.transform);
        }
    }
}
