using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour
{
    public GameObject[] Garbage;
    public int MinYForce, MaxYForce;
    public int MinXForce, MaxXForce;

    private float timer = 0;

	// Use this for initialization
	void Start ()
    {
        timer = 1.0f;    
	}

    void FireGarbage()
    {
        var obj = Function.Spawn(Garbage[Random.Range(0, Garbage.Length)],transform.position + new Vector3(0,Random.Range(-7,7)),Quaternion.identity);
        var body = obj.GetComponent<Rigidbody2D>();
        var xForce = Random.Range(MinXForce, MaxXForce);
        var yForce = Random.Range(MinYForce, MaxYForce);
        body.AddForce(new Vector2(xForce, yForce));
    }
	
	// Update is called once per frame
	void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = Random.Range(0.1f,1f);
            FireGarbage();
        }
	}
}
