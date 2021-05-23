using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mainmenu : MonoBehaviour
{
    
    public void OnClickNewGame()
    {
        SceneManager.LoadScene("Sound");
        Debug.Log("새 게임");        

    }

    public void OnClickLoad()
    {
        Debug.Log("불러오기");
    }
    public void OnClickOption()
    {
        Debug.Log("옵션");
    }
    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
