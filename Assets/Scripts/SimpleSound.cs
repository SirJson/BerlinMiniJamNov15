using UnityEngine;
using System.Collections;
using PathologicalGames;

public class SimpleSound : MonoBehaviour
{
    private AudioSource source;
    private bool running = false;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        source.spatialBlend = 0;
        source.playOnAwake = false;
    }

    public void Play(AudioClip clip, float volume = 1.0f)
    {
        if(source == null) source = GetComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.Play();
        running = true;
    }
	
	// Update is called once per frame
	void Update () {
	    if(running)
        {
            if(!source.isPlaying) {
                running = false;
                PoolManager.Pools[PoolIdentifier.Audio].Despawn(transform);
            }
        }
	}
}
