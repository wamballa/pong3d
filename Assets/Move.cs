using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = 3; // Camera.main.farClipPlane;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        float maxClamp = 1.1f;
        float minClamp = -1.1f;

        float xPos = Mathf.Clamp(mousePosition.x, minClamp, maxClamp);
        float yPos = Mathf.Clamp(mousePosition.y, minClamp, maxClamp);

        //mousePosition.Normalize();

        Vector3 newPos = new Vector3(xPos, yPos, mousePosition.z);

        transform.position = newPos;


    }

    private void OnCollisionEnter(Collision collision)
    {

        /* 0.5,-0.5  0,-0.5  -0.5,-0.5
         * 0.5,0     0,0     -0.5,0
         * 0.5,0.5  0,0.5    -0.5,-0.5
        */
        Vector3 contactPoint = transform.position - collision.GetContact(0).point;
        float multiplier = 2f;

        Debug.Log("Collision point = " + contactPoint);
        Debug.Log("Ball direction = " + collision.transform.GetComponent<Rigidbody>().velocity);

        collision.transform.GetComponent<Rigidbody>().velocity =
            collision.transform.GetComponent<Rigidbody>().velocity
            + new Vector3(-contactPoint.x * multiplier, -contactPoint.y * multiplier, 0);

    }
}
