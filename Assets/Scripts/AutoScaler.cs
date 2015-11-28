using UnityEngine;
using System.Collections;

public class AutoScaler : MonoBehaviour
{
    public Transform VerticalDirector;
    private Camera cam;
    private int screenWidth;
    private float initalScale;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        initalScale = cam.orthographicSize;
        screenWidth = Screen.width;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(screenWidth != Screen.width)
        {
            cam.orthographicSize = initalScale;
        }

        var point = cam.WorldToViewportPoint(VerticalDirector.position);

        if (point.x < 1) {
            cam.orthographicSize -= 0.1f;
        }
    }
}
