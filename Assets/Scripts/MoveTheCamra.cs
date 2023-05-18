using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheCamra : MonoBehaviour
{
    public float axisInput;
    public float speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        axisInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * axisInput * speed * Time.deltaTime);

    }
}
