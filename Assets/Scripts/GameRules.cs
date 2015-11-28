using UnityEngine;
using System.Collections;
using PathologicalGames;
using System;

public class GameRules : MonoBehaviour
{
    public float UpdateDifficultyTimer = 60.0f;
    public int TimerDecreaseModulo = 10;
    public Earth Earth;

    private float difficultyTimer;
    private long difficultyIncrease;

    // Use this for initialization
    void Start () {
        PoolManager.Pools.Create(PoolIdentifier.Bullets);
        PoolManager.Pools.Create(PoolIdentifier.Garbage);
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
        }
        difficultyTimer -= Time.deltaTime;
    }
}
