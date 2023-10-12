using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{

    // Destroying itself
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("UpperEnding"))
        {
            Destroy(gameObject);

        }
    }

    // Destroying Enemy and itself
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyLaser"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("EnemyLaser1"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("EnemyLaser2"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }
}

