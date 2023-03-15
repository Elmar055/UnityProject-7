using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // enemy speed
    public float speed = 3f;
    // enemy rigidbody component
    private Rigidbody playerRb;
    // player gameobject
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // assigning values to variables
        playerRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // distance between two vectors(player,enemy)
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        // move to player
        playerRb.AddForce(lookDirection * speed);
        // destroy the object when crossing the border
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
