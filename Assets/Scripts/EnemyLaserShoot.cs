using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserShoot : MonoBehaviour
{

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroying itself
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LowerEnding"))
        {
            Destroy(gameObject);

        }
    }
    
}
