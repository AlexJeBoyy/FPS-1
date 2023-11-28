using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawning")]
    public GameObject enemyPrefab;
    public int enemyMax;


   

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyMax; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
        }
    }
}
