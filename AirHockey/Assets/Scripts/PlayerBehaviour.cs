using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public float power;
    private Rigidbody rb;
    private Transform trans;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        float moveHorizontal,moveVertical;
        if (gameObject.tag == "Player1")
        {
            moveHorizontal = Input.GetAxis("Horizontal1");
            moveVertical = Input.GetAxis("Vertical1");
        }
        else
        {

            moveHorizontal = Input.GetAxis("Horizontal2");
            moveVertical = Input.GetAxis("Vertical2");
        }
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement*speed;

    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COlloision");
        if(collision.gameObject.transform.parent!=null &&collision.gameObject.transform.parent.gameObject.tag == "Boundary")
        {
            Debug.Log("Boundary");
           // rb.velocity = new Vector3(0,0,0);
        }
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Ball");
            collision.gameObject.GetComponent<Rigidbody>().AddForce(trans.forward * power);
        }
    }

}
