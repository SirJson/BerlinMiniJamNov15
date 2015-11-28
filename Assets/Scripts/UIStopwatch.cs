using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Text;

public class UIStopwatch : MonoBehaviour
{
    private UnityEngine.UI.Text text;
    private StringBuilder stringBuffer;

    public const string Seperator = ":";
    public const string Zero = "0";

	// Use this for initialization
	void Start ()
    {
        Game.Stopwatch.Reset();
        Game.Stopwatch.Start();
        text = GetComponent<UnityEngine.UI.Text>();
        stringBuffer = new StringBuilder(8);
    }

    public void Stop()
    {
        Game.Stopwatch.Stop();
    }
    
    public string GetString()
    {
        var time = Game.Stopwatch.Elapsed;
        stringBuffer.Length = 0;
        if (time.Minutes < 10)
            stringBuffer.Append(Zero);
        stringBuffer.Append(time.Minutes);
        stringBuffer.Append(Seperator);
        if (time.Seconds < 10)
            stringBuffer.Append(Zero);
        stringBuffer.Append(time.Seconds);
        stringBuffer.Append(Seperator);
        if (time.Milliseconds / 10 < 10)
            stringBuffer.Append(Zero);
        stringBuffer.Append(time.Milliseconds / 10);

        return stringBuffer.ToString();
    }
	
	// Update is called once per frame
	void Update()
    {
        if (!Game.Stopwatch.IsRunning) return;

        text.text = GetString();
    }
}
