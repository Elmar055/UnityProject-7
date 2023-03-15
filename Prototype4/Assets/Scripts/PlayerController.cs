using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // get rigidbody component
    private Rigidbody playerRb;
    // variable to check power
    public bool hasPowerup;
    // parent object of camera
    private GameObject focalPoint;
    // icon under the object
    public GameObject powerupIndicator;
    // player speed
    public float speed = 2f;
    // powerup strength 
    private float powerUpStrenght = 15f;

    // Start is called before the first frame update
    void Start()
    {
        // assign value to variables
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        // does not show icon on stage
        powerupIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward*forwardInput*speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    // when player and powerup object collide //other is powerup prefab
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup")) // check powerup tag
        {
            // destroy powerup
            Destroy(other.gameObject);
            hasPowerup = true;
            // stop executing powerupcountdownrouitine method for 7 seconds
            StartCoroutine(PowerupCountDownRoutine());
            // show icon on stage without waiting 7 seconds
            powerupIndicator.SetActive(true);

        }
    }

    // when player and enemy object collise // collision is enemy prefab
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // get rigidbody componenent of enemy
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();

            // get reverse vector
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position ;
            
            // give force to enemy
            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
        }
    }

    // it used in StartCoroutine method
    IEnumerator PowerupCountDownRoutine()
    {
        // wait 7 seconds and goes to the code after the method if this method used in StartCoroutine
        yield return new WaitForSeconds(7);
        // after 7 second execute this code if this method used in StartCoroutine
        hasPowerup = false;
        powerupIndicator.SetActive(false);

    }
}
