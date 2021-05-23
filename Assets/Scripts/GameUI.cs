using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    private static GameUI m_instance;
    public static GameUI Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameUI>();
            }
            return m_instance;
        }
    }
    private float maxTime = 15.0f;               //시간 제한
    
    public GameObject gameOverUI;
    Player playerCon;
    Bullet bullet;
    public Text tryAgainBtn;
    float remainTime;    
    Image TimeBar;
    private void Awake()
    {
        TimeBar = GetComponent<Image>();       
       // tryAgainBtn = GetComponent<Text>();
       
        //playerCon = GetComponent<Player>();
        //bullet = GetComponent<Bullet>();
    }
    void Start()
    {       
        remainTime = maxTime;   
        gameOverUI.SetActive(false);
       // TimeBar.enabled = true;
        //tryAgainBtn.gameObject.SetActive(false);
        //playerCon.enabled = true;
        //bullet.enabled = true;
    }
    
    void Update()
    {        
        if (remainTime >= 0 )
        {          
            remainTime -= Time.deltaTime;
            TimeBar.fillAmount = remainTime / maxTime;            
        }
        else
        {
            gameOverUI.SetActive(true);             
            tryAgainBtn.gameObject.SetActive(true);                    
        }       
    }        
    public void SetActiveGameoverUI(bool active)
    {
        gameOverUI.SetActive(active);
        
    }
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Bullet.Initialized();        
    }    
}
