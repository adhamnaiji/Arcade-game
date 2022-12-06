using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody playerRb;
    private GameObject focalpointt;
    public bool poweron = false;
    public GameObject powerupindicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalpointt = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float inputplayeer = Input.GetAxis("Vertical");
        playerRb.AddForce(focalpointt.transform.forward * speed * inputplayeer);
        powerupindicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            poweron = true;
            powerupindicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        poweron = false;
        powerupindicator.gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision collition)
    {
        if(collition.gameObject.CompareTag("Enemy") && poweron)
        {
            Rigidbody enemyRigidbody = collition.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromplayer = (collition.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayfromplayer*10,ForceMode.Impulse);
            Debug.Log("5edmet mreguel");
        }
    }
}
