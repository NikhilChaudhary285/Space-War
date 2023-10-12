using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] EnemyPositions;

    [SerializeField]
    private GameObject[] EnemyPrefabs;

    private int randomIndex;
    private int randomPosition;
    private int prevRandomPosition;
    private int prevEnemy;

    private int instantiatedEnemies;
    [HideInInspector]
    public int destroyedEnemies;
    private int presentEnemies;
    [SerializeField]
    private int wantedEnemies = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EnemySpawn()
    {

        while (true) 
        {
            presentEnemies = instantiatedEnemies - destroyedEnemies;
            if (presentEnemies >= wantedEnemies)
            {
                yield return new WaitForSeconds(1);
                
            }
            else
            {
                randomIndex = Random.Range(0, EnemyPrefabs.Length);
                randomPosition = Random.Range(0, EnemyPositions.Length);
                if (prevRandomPosition == randomPosition & prevEnemy == randomIndex)
                {
                    continue;
                }
                yield return new WaitForSeconds(Random.Range(2, 5));
                Instantiate(EnemyPrefabs[randomIndex], EnemyPositions[randomPosition].position, EnemyPrefabs[randomIndex].transform.rotation);
                // prevent from repeat spawn position
                prevRandomPosition = randomPosition;
                // prevent from repeat enemy prefabs
                prevEnemy = randomIndex;

                instantiatedEnemies++;

            }
        }

    }

}
