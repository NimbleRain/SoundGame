using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{      
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Mainmenu");
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    LoadingSceneController.LoadScene("LoadingScene");
        //}

        if (Input.GetKeyDown(KeyCode.F1))
        {
            //LoadingSceneController.LoadScene("LoadingScene");
            SceneManager.LoadScene("Sound");            
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene("Sound2");
            //StartCoroutine(LoadSceneCoroutine());            
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene("Sound3");
            //StartCoroutine(LoadSceneCoroutine());            
        }
    }
    //IEnumerator LoadSceneCoroutine()
    //{
    //    //yield return SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive); //additive는 기존의 씬을 두고 새로운 씬을 부름
    //                                                                         //single은 기존의 씬은 사라지고 새로운 씬을 부름
    //}
}
