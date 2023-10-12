using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemy : MonoBehaviour
{
    [SerializeField]
    private float laserSpeed = 5f;
    [SerializeField]
    private float enemySpeed = 0.8f;
    [SerializeField]
    private float health = 80f;
    [SerializeField]
    private int intBullets = 1;
    [SerializeField]
    private float bulletDistance = 0f;
    [SerializeField]
    private float bulletShootTime = 3f;

    [SerializeField]
    private Transform enemyLaserSpawnPoint;
    [SerializeField]
    private GameObject enemyLaserPrefab;
    private Rigidbody2D enemybody;
    private string movement;

    private EnemySpawner enemySpawner;
    private PlayerDetailsUI playerDetailsUI;

    // Start is called before the first frame update
    void Start()
    {
        enemybody = GetComponent<Rigidbody2D>();
        enemySpawner = GameObject.Find("RandomSpawners").GetComponent<EnemySpawner>();
        playerDetailsUI = GameObject.Find("Canvas").GetComponent<PlayerDetailsUI>();

        StartCoroutine(LaserSpawner());

    }

    IEnumerator LaserSpawner()
    {
        int i = 0;
        while (true)
        {
            if (i == intBullets)
            {
                yield return new WaitForSeconds(bulletShootTime);
                i = 0;
            }
            yield return new WaitForSeconds(bulletDistance);
            var laser = Instantiate(enemyLaserPrefab, enemyLaserSpawnPoint.position, enemyLaserSpawnPoint.rotation);
            laser.GetComponent<Rigidbody2D>().velocity = Vector2.down * laserSpeed;
            i++;

        }

    }
    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (movement == "left")
        {
            enemybody.velocity = new Vector2(-enemySpeed, -enemySpeed);
        }
        else if (movement == "right")
        {
            enemybody.velocity = new Vector2(enemySpeed, -enemySpeed);
        }
        else
        {
            enemybody.velocity = new Vector2(enemySpeed, -enemySpeed);
        }


    }

    // Destroying itself
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LowerEnding"))
        {
            Destroy(gameObject);

        }
    }

    // Destroying SpaceShip
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            health -= 20f;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                playerDetailsUI.scoredEnemies++;
                enemySpawner.destroyedEnemies++;
                Debug.Log(enemySpawner.destroyedEnemies);
                Destroy(gameObject);

            }

        }

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            movement = "right";

        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            movement = "left";

        }

    }

}



