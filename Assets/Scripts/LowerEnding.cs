using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerEnding : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("RandomSpawners").GetComponent<EnemySpawner>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemySpawner.destroyedEnemies++;
            Debug.Log(enemySpawner.destroyedEnemies);
        }
    }
    void DestroyObjectDelayed()
    {

    }
}
