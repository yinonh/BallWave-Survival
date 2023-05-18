using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject center;
    public float axisInput;
    public float speed = 50;
    public Rigidbody playerRb;
    public bool hasPowerUp;
    //public bool hasSizeUp;
    public GameObject indicator;
    public int jumpForce;
    public bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (center.gameObject.GetComponent<SpwanManager>().start)
        {
            axisInput = Input.GetAxis("Vertical");
            playerRb.AddForce(center.transform.forward * axisInput * speed);
            axisInput = Input.GetAxis("Jump");
            if (canJump)
            {
                playerRb.AddForce(center.transform.up * axisInput * jumpForce, ForceMode.Impulse);
                canJump = false;
            }
            indicator.transform.position = transform.position;
            if (transform.position.y < -5)
                gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 opisitDiraction = enemyRb.gameObject.transform.position - transform.position;
            enemyRb.AddForce(opisitDiraction * 15, ForceMode.Impulse);
        }
        //if (collision.gameObject.CompareTag("Enemy") && hasSizeUp)
        //{
        //    Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
        //    Vector3 opisitDiraction = enemyRb.gameObject.transform.position - transform.position;
        //    enemyRb.AddForce(opisitDiraction * 5, ForceMode.Impulse);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            indicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(startPowerUpCount());
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
        //if (other.CompareTag("sizeUp"))
        //{
        //    Debug.Log("hello");
        //    hasSizeUp = true;
        //    indicator.gameObject.SetActive(true);
        //    Destroy(other.gameObject);
        //    StartCoroutine(startSizeUpCount());
        //}
    }

    //IEnumerator startSizeUpCount()
    //{
    //    transform.localScale = new Vector3(3f, 3f, 3f);
    //    yield return new WaitForSeconds(7);
    //    hasSizeUp = false;
    //    transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    //    indicator.gameObject.SetActive(false);
    //}
    IEnumerator startPowerUpCount()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        indicator.gameObject.SetActive(false);
    }
}
