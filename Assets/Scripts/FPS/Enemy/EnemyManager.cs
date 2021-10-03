using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : TemporalSingleton<EnemyManager>
{
    public GameObject           m_enemy;
    public Transform[]          m_spawnPoints;
    private List<GameObject>    enemyVector = new List<GameObject>();

    public bool canSpawnEnemies = true;

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
        if (canSpawnEnemies)
        {
            for (int i = 0; i < enemyVector.Count; i++)
            {
                if (!enemyVector[i].activeSelf)
                {
                    int spawnIndex = Random.Range(0, m_spawnPoints.Length);
                    enemyVector[i].transform.position = m_spawnPoints[spawnIndex].position;
                    enemyVector[i].transform.rotation = m_spawnPoints[spawnIndex].rotation;
                    enemyVector[i].SetActive(true);
                    enemyVector[i].GetComponent<EnemySimpleStateMachine>().m_currentHealth = enemyVector[i].GetComponent<EnemySimpleStateMachine>().m_maxHealth;
                    if (enemyVector[i].GetComponent<EnemySimpleStateMachine>().m_collider != null)
                    {
                        enemyVector[i].GetComponent<EnemySimpleStateMachine>().m_collider.enabled = true;
                    }
                    enemyVector[i].GetComponent<EnemySimpleStateMachine>().m_collider.enabled = true;
                    break;
                }
            }
        }
    }

    public void EnemyDead(GameObject enemy)
    {
        enemy.SetActive(false);
        SpawnEnemy();
    }

    public void StopSpwaning(bool isSpawning)
    {
        canSpawnEnemies = isSpawning;
    }
}
