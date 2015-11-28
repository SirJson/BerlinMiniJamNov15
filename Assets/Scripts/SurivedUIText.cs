using UnityEngine;
using System.Collections;

public class SurivedUIText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var text = GetComponent<UnityEngine.UI.Text>();
        var elapsed = Game.Stopwatch.Elapsed;
        text.text = string.Format(text.text, elapsed.Minutes, elapsed.Seconds);
	}
}
