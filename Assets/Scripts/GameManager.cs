using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameoverText;
    //private Text timeText;
    //private Text restart;

    private float surviveTime;
    public bool isGameover { get; private set; }

    
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        FindObjectOfType<Player>().OnDeath += EndGame;
    }
   
    void Update()
    {
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            //timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            //if (Input.GetKeyDown(KeyCode.R))
            //{
            //    SceneManager.LoadScene("Mainmenu");
            //}
        }
    }    
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);        
    }
}
