using UnityEngine;
using System.Collections;

public class RandomForceAngle : MonoBehaviour
{
    AreaEffector2D effector;
	// Use this for initialization
	void Start () {
        effector = GetComponent<AreaEffector2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        effector.forceAngle = Random.Range(-90, 90);
    }
}
