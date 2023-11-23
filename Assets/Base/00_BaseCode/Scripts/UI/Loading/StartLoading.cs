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
    public bool wasRunLoad;
    private int prevenOpenAppAds;

    public void Init()
    {
        wasRunLoad = false;
        progressBar.fillAmount = 0f;

        StartCoroutine(LoadingText());
        StartCoroutine(ChangeScene());
    }
    public void InitState()
    {

        if(!wasRunLoad)
        {
            wasRunLoad = true;
        
        }
   

    }

    // Use this for initialization
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        sceneName = "";
        if (UseProfile.CurrentLevel < 60)
        {
            sceneName = "Level " + UseProfile.CurrentLevel;
        }
        else
        {
            sceneName = "Level " + UnityEngine.Random.Range(1, 60);
        }



        var _asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

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
    private IEnumerator OnChangeScene()
    {
        yield return new WaitForSeconds(1);
        prevenOpenAppAds += 1;
   
    }

}
