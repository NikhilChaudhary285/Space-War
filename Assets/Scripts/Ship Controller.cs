using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    // Laser Spawning
    [SerializeField]
    public Transform laserSpawnPoint;
    [SerializeField]
    public GameObject laserPrefab;
    [SerializeField]
    private float laserSpeed = 5f;
    [SerializeField]
    private int intBullets = 2;
    [SerializeField]
    private float bulletDistance = 2f;
    [SerializeField]

    private float bulletShootTime = 1.5f;

    // SpaceShip Health
    public float spaceShipHealth = 100f;

    private Rigidbody2D shipBody;
    private Vector2 direction;
    public float moveSpeed;

    // SpaceShip Destroyed or its Lives or SpaceShipSpawn
    private PlayerDetailsUI playerDetailsUI;
    private SpaceShipSpawn spaceShipSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        shipBody = GetComponent<Rigidbody2D>();
        playerDetailsUI = GameObject.Find("Canvas").GetComponent<PlayerDetailsUI>();
        spaceShipSpawn = GameObject.Find("SpaceShipSpawnPoint").GetComponent<SpaceShipSpawn>();

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
            var laser = Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
            laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * laserSpeed;
            i++;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousepos.x > 0.2f)
            {
                direction = new Vector2(1, 0);

            }
            else if (mousepos.x < -0.2f)
            {
                direction = new Vector2(-1, 0);

            }

        }
        else
        {
            direction = new Vector2(0, 0);

        }
    }

    private void FixedUpdate()
    {
        shipBody.velocity = direction * moveSpeed * Time.deltaTime;

    }

    // Destroying EnemyLaser and itself
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyLaser"))
        {   // 10 damage rate
            Destroy(collision.gameObject);
            spaceShipHealth -= 10f;
            playerDetailsUI.healthSliderControl = spaceShipHealth;
            if (spaceShipHealth <= 0)
            {
                playerDetailsUI.healthSlider.value = 0f;
                spaceShipSpawn.SpaceShipDestroyed = true;
                playerDetailsUI.lives--;
                playerDetailsUI.ShowLives = true;
                Destroy(gameObject);

            }
            Debug.Log("EnemyLaser");

        }
        else if (collision.gameObject.CompareTag("EnemyLaser1"))
        {   // 20 damage rate
            Destroy(collision.gameObject);
            spaceShipHealth -= 20f;
            playerDetailsUI.healthSliderControl = spaceShipHealth;
            if (spaceShipHealth <= 0)
            {
                playerDetailsUI.healthSlider.value = 0f;
                spaceShipSpawn.SpaceShipDestroyed = true;
                playerDetailsUI.lives--;
                playerDetailsUI.ShowLives = true;
                Destroy(gameObject);
            }
            Debug.Log("EnemyLaser1");

        }
        else if (collision.gameObject.CompareTag("EnemyLaser2"))
        {   // 30 damage rate
            Destroy(collision.gameObject);
            spaceShipHealth -= 30f;
            playerDetailsUI.healthSliderControl = spaceShipHealth;
            if (spaceShipHealth <= 0)
            {
                playerDetailsUI.healthSlider.value = 0f;
                Destroy(gameObject);
                playerDetailsUI.lives--;
                playerDetailsUI.ShowLives = true;
                spaceShipSpawn.SpaceShipDestroyed = true;


            }
            Debug.Log("EnemyLaser2");

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerDetailsUI.healthSliderControl = 0f;
            playerDetailsUI.healthSlider.value = 0f;
            spaceShipSpawn.SpaceShipDestroyed = true;
            playerDetailsUI.lives--;
            playerDetailsUI.ShowLives = true;
            Destroy(gameObject);
            Debug.Log("Enemy");

        }
    }
}