using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Rigidbody enemyRb;
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diraction = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(diraction * speed);
        if (transform.position.y < -5)
            Destroy(gameObject);
    }
}
