using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody enemyRb;
    private GameObject player;
    public float speed=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 loodirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(loodirection * speed);
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
