using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    private Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Allows the player to jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    //looks for a collision with the player
    private void OnCollisionEnter(Collision collision)
    {
        //allows the player to jump again after hitting the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        //sets the game over condition
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
