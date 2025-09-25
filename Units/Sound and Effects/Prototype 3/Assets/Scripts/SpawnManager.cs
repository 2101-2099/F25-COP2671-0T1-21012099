using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //variables
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatDelay = 2;
    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();      //getting player controller script

        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);                          //repeats the spawn obstacles function
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Spawn an object prefab at the spawn location
    void SpawnObstacle ()
    {
        //checks to see if the game is over and if not spawns
        if (playerController.gameOver == false)
        { 
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation); 
        }
    }
}
