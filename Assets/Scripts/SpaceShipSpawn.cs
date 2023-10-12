using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipSpawn : MonoBehaviour
{
    // SpaceShip Spawning
    [SerializeField]
    private Transform SpaceShipPosition;
    [SerializeField]
    private GameObject SpaceShipPrefab;
    [HideInInspector]
    // SpaceShipDestroyed & SpawnTime
    public bool SpaceShipDestroyed;
    [SerializeField]
    private float spawnTime = 3f;

    private PlayerDetailsUI playerDetailsUI;
    // Start is called before the first frame update
    void Start()
    {
        playerDetailsUI = GameObject.Find("Canvas").GetComponent<PlayerDetailsUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if(SpaceShipDestroyed == true && playerDetailsUI.lives > 0)
        {
            Invoke("SpaceShipSpawned", spawnTime);
            SpaceShipDestroyed = false;
        }

    }

    private void SpaceShipSpawned()
    {
        Instantiate(SpaceShipPrefab, SpaceShipPosition.position, SpaceShipPosition.rotation);
        playerDetailsUI.healthSliderControl = 100f;
        playerDetailsUI.healthSlider.value = 100f;
        Debug.Log(playerDetailsUI.healthSlider.value);

    }
}
