using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField] Image progressBar;
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProgress());
    }   
    IEnumerator LoadSceneProgress()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(0);                                     //비동기방식으로 씬을 불러오는 도중에 다른 작업이 가능
        op.allowSceneActivation = false;                                                        //씬의 로딩이 끝나면 자동으로 불러온 씬으로 이동할 것인지를 설정

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)                                                                  //바의 90%까지는 로딩 진행도에 따라 진행바를 채운다
            {
                progressBar.fillAmount = op.progress;
            }
            else                                                                                //페이크 로딩, 나머지 10%를 1초간 채운 뒤 씬을 불러온다.가끔 로딩창에서 전달 메시지를 보여줄 때 시간이 더 필요한 경우가 있다.
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(progressBar.fillAmount  >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
