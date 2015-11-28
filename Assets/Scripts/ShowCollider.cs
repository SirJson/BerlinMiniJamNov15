using UnityEngine;
using System.Collections;

public class ShowCollider : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        
    }
	
    void OnDrawGizmos()
    {
        var collider2d = GetComponent<BoxCollider2D>();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(collider2d.transform.position, collider2d.size);
    }
}
