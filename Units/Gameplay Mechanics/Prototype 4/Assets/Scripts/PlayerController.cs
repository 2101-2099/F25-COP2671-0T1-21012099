using System.Collections;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    private Rigidbody playerRB;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    public float speed = 5.0f;
    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        //player input
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);

        //powerup indicator around the player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    //player collides with the powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    //amount of time the player has before taking away powerup
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    //collision with the enemy while having a powerup
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collision with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
