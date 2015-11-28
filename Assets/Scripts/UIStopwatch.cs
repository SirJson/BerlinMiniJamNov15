using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Text;

public class UIStopwatch : MonoBehaviour
{
    private Stopwatch watch;
    private UnityEngine.UI.Text text;
    private StringBuilder stringBuffer;
    private string seperator, zero;

	// Use this for initialization
	void Start ()
    {
        seperator = ":";
        zero = "0";
        watch = new Stopwatch();
        watch.Start();
        text = GetComponent<UnityEngine.UI.Text>();
        stringBuffer = new StringBuilder(8);
    }

    public void Stop()
    {
        watch.Stop();
    }
    
    public string GetString()
    {
        var time = watch.Elapsed;
        stringBuffer.Length = 0;
        if (time.Minutes < 10)
            stringBuffer.Append(zero);
        stringBuffer.Append(time.Minutes);
        stringBuffer.Append(seperator);
        if (time.Seconds < 10)
            stringBuffer.Append(zero);
        stringBuffer.Append(time.Seconds);
        stringBuffer.Append(seperator);
        if (time.Milliseconds / 10 < 10)
            stringBuffer.Append(zero);
        stringBuffer.Append(time.Milliseconds / 10);

        return stringBuffer.ToString();
    }
	
	// Update is called once per frame
	void Update()
    {
        if (!watch.IsRunning) return;

        text.text = GetString();
    }
}
