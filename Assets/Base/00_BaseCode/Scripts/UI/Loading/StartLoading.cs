using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class StartLoading : MonoBehaviour
{
    public Text txtLoading;
    public Image progressBar;
    private string sceneName;

    public void Init()
    {
    
        progressBar.fillAmount = 0f;

        StartCoroutine(LoadingText());
    }
    public void InitState()
    {


        StartCoroutine(ChangeScene());

    }

    // Use this for initialization
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);

        var _asyncOperation = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("levelnumber", 1) > SceneManager.sceneCountInBuildSettings - 1
         ? Random.Range(1, SceneManager.sceneCountInBuildSettings - 1)
         : PlayerPrefs.GetInt("levelnumber", 1), LoadSceneMode.Single);

        while (!_asyncOperation.isDone)
        {
            progressBar.fillAmount = Mathf.Clamp01(_asyncOperation.progress / 0.9f);
            yield return null;
    }
    }

    IEnumerator LoadingText()
    {
        var wait = new WaitForSeconds(1f);
        while (true)
        {
            txtLoading.text = "LOADING .";
            yield return wait;

            txtLoading.text = "LOADING ..";
            yield return wait;

            txtLoading.text = "LOADING ...";
            yield return wait;

        }
    }
}
