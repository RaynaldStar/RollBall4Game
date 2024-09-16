using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 5;
    public Rigidbody playerRb;
    public GameObject focalPoint;
    public bool hasPowerUp;
    public float powerUpStrange = 25;
    public GameObject powerUpRing;
    private float _verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        powerUpRing.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * force * _verticalInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpRing.SetActive(true);
            StartCoroutine(PowerUpCoroutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Player collided with " + collision.gameObject + " with PowerUp!");
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            enemyRb.AddForce(awayFromPlayer * powerUpStrange, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCoroutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerUpRing.SetActive(false);
        Debug.Log("Буст закончился!");
    }

}
