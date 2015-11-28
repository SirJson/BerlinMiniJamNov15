using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour
{
    public GameObject[] Garbage;

	// Use this for initialization
	void Start () {
	    
	}

    void FireGarbage()
    {
        var obj = Function.Spawn(Garbage[Random.Range(0, Garbage.Length)],transform.position,Quaternion.identity);
        var body = obj.GetComponent<Rigidbody2D>();
        var xForce = Random.Range(-1, 1);
        var yForce = Random.Range(-1, 1);
        body.AddForce(new Vector2(xForce, yForce));
    }
	
	// Update is called once per frame
	void Update()
    {
        var chance = Random.Range(0, 100);
        if(chance > 60) FireGarbage();
	}
}
