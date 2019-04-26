using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private Transform trans;
    public GameObject player1;
    public GameObject player2;
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();

    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Midline")
        {
            Debug.Log("MidLine");
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            // rb.velocity = new Vector3(0,0,0);
        }
        if (collision.gameObject.tag == "Goal1")
        {
            Debug.Log("Goal for 2");
            gameController.GetComponent<GameController>().goal(2);    
        }
        else if (collision.gameObject.tag == "Goal2")
        {
            Debug.Log("Goal for 1");
            gameController.GetComponent<GameController>().goal(1);
        }
    }
}
