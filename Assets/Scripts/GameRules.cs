using UnityEngine;
using System.Collections;
using PathologicalGames;
using System;

public class GameRules : MonoBehaviour
{
    public float UpdateDifficultyTimer = 60.0f;
    public int TimerDecreaseModulo = 10;
    public Earth Earth;
    public AudioClip LevelUp;

    private float difficultyTimer;
    private long difficultyIncrease;

    // Use this for initialization
    void Start () {
        PoolManager.Pools.Create(PoolIdentifier.Bullets);
        PoolManager.Pools.Create(PoolIdentifier.Garbage);
		PoolManager.Pools.Create(PoolIdentifier.Shield);
        PoolManager.Pools.Create(PoolIdentifier.Audio);
        difficultyTimer = UpdateDifficultyTimer;
    }

    void Update()
    {
        if(difficultyTimer <= 0)
        {
            if (difficultyIncrease % TimerDecreaseModulo == 0) Earth.UpdateSpawnDifficulty();
            else Earth.UpdateForceDifficulty();

            difficultyTimer = UpdateDifficultyTimer;
            difficultyIncrease++;
            Function.Play2DSound(LevelUp);
        }
        difficultyTimer -= Time.deltaTime;
    }

    public void GameOver()
    {
        Application.LoadLevel("gameOver");
    }
}
