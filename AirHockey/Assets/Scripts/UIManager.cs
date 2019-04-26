using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] pauseObjects;
    public Text pauseText;
    public Button resume;
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("Show on pause");
        hidePause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPause();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePause();
            }
        }
    }
    public void showPause()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }
    public void hidePause()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            pauseText.text = "Pause";
            Time.timeScale = 0;
            showPause();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePause();
        }
    }

    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level,LoadSceneMode.Single);
    }
    public void gameFinished(int player)
    {
        pauseText.text = "Player "+player.ToString()+" Win";
        showPause();
        resume.gameObject.SetActive(false);
    }
    public void gameExit()
    {
        Application.Quit();
    }

}
