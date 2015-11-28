using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour
{
    public float GrowFactor = 0.1f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 10)
        {
            Destroy(other.gameObject);
            Grow();
        }
    }

    void Grow()
    {
        transform.localScale += new Vector3(GrowFactor, GrowFactor);
    }
}