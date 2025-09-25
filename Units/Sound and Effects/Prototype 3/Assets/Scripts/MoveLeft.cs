using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //variables
    private float speed = 30;
    private PlayerController playerController;
    private float leftBound = -15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();      //getting player controller script
    }

    // Update is called once per frame
    void Update()
    {
        //moves the background if the game is not over
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        //gets rid of obstacles that are outside the player's view
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
