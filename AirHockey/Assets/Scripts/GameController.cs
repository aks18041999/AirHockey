using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public int goal1 = 0;
    public int goal2 = 0;
    private int startSide;
    public Text scoreText;
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;
    private Vector3 initial_pos1;
    private Vector3 initial_pos2;
    private Vector3 ball_pos;
    public GameObject midline;
    public GameObject uiManager;
    //public GameObject gui;

    void Start()
    {
        startSide = (int)((Random.value)*10)%2;
        goal1 = 0;goal2 = 0;
        initial_pos1 = player1.GetComponent<Transform>().position;
        initial_pos2 = player2.GetComponent<Transform>().position;
        if (startSide == 0) ball.GetComponent<Transform>().position = new Vector3(2, 0.5f, 0); 
        else ball.GetComponent<Transform>().position = new Vector3(-2, 0.5f, 0);
        Physics.IgnoreCollision(ball.GetComponent<Collider>(), midline.GetComponent<Collider>());
        scoreText.text = goal1.ToString() + "::" + goal2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void goal(int side)
    {
        Debug.Log("GameController Get Goal for"+side);
        
        if (side == 1)
        { goal1++;
            ball.GetComponent<Transform>().position = new Vector3(-2, 0.5f, 0);

        }
        else
        {
            goal2++;
            ball.GetComponent<Transform>().position = new Vector3(2, 0.5f, 0);
        }
        scoreText.text = goal2.ToString() + "::" + goal1.ToString();
        if (goal1 == 3)
        {
            uiManager.GetComponent<UIManager>().gameFinished(1);
        }
        if(goal2 == 3)
        {
            uiManager.GetComponent<UIManager>().gameFinished(2);
        }
        Debug.Log("Goal 1=" + goal1);
        Debug.Log("Goal 2=" + goal2);
        player1.transform.position = initial_pos1;
        player2.transform.position = initial_pos2;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        

    }
    
}
