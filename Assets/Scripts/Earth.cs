using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour
{
    public GameObject[] Garbage;
    public float MinYForce, MaxYForce;
    public float MinXForce, MaxXForce;
    public float MaxSpawnTimer, MinSpawnTimer;

    public float HardestMaxSpawnTimer, HardestMinSpawnTimer;
    public float TimerDecreaseStep = 1.0f;
    public float ForceIncreaseStep = 1.0f;

    private float timer = 0;
    private int spawnWave = 1;

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
            timer = Random.Range(MinSpawnTimer,MaxSpawnTimer);
            for(var i = 0; i < spawnWave; i++) FireGarbage();
        }
	}

    public void UpdateSpawnDifficulty()
    {
        Debug.Log("Update Spawn");

        spawnWave++;
    }

    public void UpdateForceDifficulty()
    {
        Debug.Log("Update Force");
        MinXForce += ForceIncreaseStep;
        MaxXForce += ForceIncreaseStep;
    }
}
