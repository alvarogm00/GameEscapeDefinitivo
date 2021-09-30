using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    float radius = 15f;
    public int amountToSpawn;
    public GameObject Enemy;
    float TimeBetweenSpawns = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeBetweenSpawns -= 1 *Time.deltaTime;
        if (TimeBetweenSpawns <= 0)
        {
            amountToSpawn= Random.Range(2, 5);
            Spawn();
        }
    }

    void Spawn()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            TimeBetweenSpawns = 3;
            float angle = i * Mathf.PI * Random.Range(0f, 360f) /*/ amountToSpawn*/;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, transform.position.y, Mathf.Sin(angle) * radius);
            GameObject go = Instantiate(Enemy, newPos, Quaternion.identity);
            Debug.Log(newPos);
        }
        
    }
}
