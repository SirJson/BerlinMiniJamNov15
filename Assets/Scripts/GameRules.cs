using UnityEngine;
using System.Collections;
using PathologicalGames;

public class GameRules : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PoolManager.Pools.Create(PoolIdentifier.Bullets);
        PoolManager.Pools.Create(PoolIdentifier.Garbage);
	}
}
