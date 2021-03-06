using PathologicalGames;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using Object = UnityEngine.Object;

public static class PoolIdentifier
{
    public const string Audio = "Audio";
    public const string Text = "Text";
    public const string Marker = "Marker";
    public const string Bullets = "Bullets";
    public const string Garbage = "Garbage";
	public const string Shield = "Shield";
}

public static class Function
{
    private static GameObject AudioStub = null;

    public static void InitAudio()
    {
        AudioStub = new GameObject("TempAudio");
        AudioStub.AddComponent<AudioSource>();
        AudioStub.AddComponent<SimpleSound>();
    }

	public static void Play2DSound(AudioClip clip, float volume = 1.0f)
	{
        if (AudioStub == null) InitAudio();
        var audio = PoolManager.Pools[PoolIdentifier.Audio].Spawn(AudioStub.transform).gameObject.GetComponent<SimpleSound>();
        audio.Play(clip, volume);
	}

	public static GameObject Spawn(GameObject prefab)
	{
		return Spawn(prefab,Vector3.zero,Quaternion.identity);
	}

	public static GameObject SpawnWithOriginalRotation(GameObject prefab, Vector3 pos)
	{
		return Spawn(prefab, pos, prefab.transform.rotation);
	}

	public static GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion quat)
	{
		var obj = Object.Instantiate(prefab,pos,quat) as GameObject;
		if(obj == null)
		{
			Debug.LogError("Object spawning failed");
			return null;
		}		
		return obj;
	}

	public static double GetTimestamp()
	{
		var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
		var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
		return timestamp;
	}

    public static string GetStopwatchString()
    {
        var time = Game.Stopwatch.Elapsed;
        var stringBuffer = new StringBuilder();
        stringBuffer.Length = 0;
        if (time.Minutes < 10)
            stringBuffer.Append(UIStopwatch.Zero);
        stringBuffer.Append(time.Minutes);
        stringBuffer.Append(UIStopwatch.Seperator);
        if (time.Seconds < 10)
            stringBuffer.Append(UIStopwatch.Zero);
        stringBuffer.Append(time.Seconds);
        stringBuffer.Append(UIStopwatch.Seperator);
        if (time.Milliseconds / 10 < 10)
            stringBuffer.Append(UIStopwatch.Zero);
        stringBuffer.Append(time.Milliseconds / 10);

        return stringBuffer.ToString();
    }

    public static List<RaycastHit> CircleCast(Vector3 origin, int resolution, int layer, float length = Mathf.Infinity)
	{
		int steps = 360/resolution;
		var hits = new List<RaycastHit>();

		for (var i = 0; i < steps; i ++)
		{
			var angle = i*resolution;
			var dir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
			RaycastHit hit;
			var result = Physics.Raycast(origin, dir, out hit, length);
			if (result) {
				hits.Add(hit);
			}
		}

		return hits;
	}

	public static float CalculateValueWithDifficulty(float val, float difficulty)
	{
		return (val / 1.0f) * difficulty;
	}

	public static bool DecideWithChance(float chance, System.Random random)
	{
		var n = random.NextDouble();
		n = n*100.0;
		return n < chance;
	}
	
	public static T CreateObject<T>() where T : Component
	{
		return CreateObject<T>(Vector3.zero,Quaternion.identity);
	}
	
	public static T CreateObject<T>(Vector3 pos, Quaternion quat) where T : Component
	{
		var obj = new GameObject {name = "ScriptedObject"};
		var output = obj.AddComponent<T>();
		obj.transform.position = pos;
		obj.transform.localPosition = pos;
		obj.transform.rotation = quat;
		return output;
	}

    public static float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f)
        {
            return 1f;
        }
        else if (dir < 0f)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
	{
		angle = angle % 360;
		if ((angle >= -360F) && (angle <= 360F))
		{
			if (angle < -360F)
			{
				angle += 360F;
			}
			if (angle > 360F)
			{
				angle -= 360F;
			}
		}
		return Mathf.Clamp(angle, min, max);
	}

	public static T GetClassFromScene<T>() where T : Component
	{
		var obj = Object.FindObjectOfType<T>();
		return obj == null ? null : obj.GetComponent<T>();
	}

	public static Color AddAlpha(this Color color, float val)
	{
		return new Color(color.r, color.g, color.b, color.a + val);
	}

	public static int GetGreatestCommonDivisor(Int32 a, Int32 b)
	{
		return b == 0 ? a : GetGreatestCommonDivisor(b, a % b);
	}

	public static T RandomEnumValue<T>(System.Random rand)
	{
		var values = Enum.GetValues(typeof(T));
		return (T)values.GetValue(rand.Next(0, values.Length));
	}

    public static T RandomEnumValue<T>()
    {
        var values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }
}
