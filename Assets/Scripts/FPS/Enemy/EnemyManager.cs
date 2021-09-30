using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : TemporalSingleton<EnemyManager>
{
    public GameObject           m_enemy;
    public Transform[]          m_spawnPoints;
    private List<GameObject>    enemyVector = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEnemies(int numberOfEnemies, int maxNumberOfEnemies)
    {
        for (int i = 0; i < maxNumberOfEnemies; i++)
        {
            GameObject enemyAux = Instantiate(m_enemy, Vector3.zero, Quaternion.identity);
            enemyAux.SetActive(false);
            enemyAux.transform.SetParent(this.transform);
            enemyVector.Add(enemyAux);
        }

        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemyVector.Count; i++)
        {
            if (!enemyVector[i].activeSelf)
            {
                int spawnIndex = Random.Range(0, m_spawnPoints.Length);
                enemyVector[i].transform.position = m_spawnPoints[spawnIndex].position;
                enemyVector[i].transform.rotation = m_spawnPoints[spawnIndex].rotation;
                enemyVector[i].SetActive(true);
                break;
            }
        }
    }

    public void EnemyDead(GameObject enemy)
    {
        enemy.SetActive(false);
        SpawnEnemy();
    }
}
