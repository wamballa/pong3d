using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody rb;
    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startDir = Vector3.forward + Vector3.up;

        startDir = Vector3.back;

        Debug.Log("Start direction = " + startDir);
        rb.velocity = startDir * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }



}
