using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;
using MoreMountains.NiceVibrations;
using UnityEngine.Events;

public class GameScene : BaseScene
{
    public Button btnShowInter;
    public Button btnShowReward;
    public Button btnBack;
    public void Init()
    {
        ShowBanner();
        btnShowInter.onClick.AddListener(delegate { OnClickShowInter(); });
        btnShowReward.onClick.AddListener(delegate { OnClickShowReward(); });
        btnBack.onClick.AddListener(delegate { OnClickBack(); });
    }
    public void OnClickShowInter()
    {
        GameController.Instance.admobAds.ShowInterstitial();
    }

    public void OnClickShowReward()
    {
        GameController.Instance.admobAds.ShowVideoReward(delegate { });
    }
    public void OnClickBack()
    {
        GameController.Instance.LoadScene("HomeScene");
    }
    public void ShowBanner()
    {
        GameController.Instance.admobAds.googleAdmobe.RequestBannerAd();
      //  Debug.LogError("ShowBanner");
    }






    public override void OnEscapeWhenStackBoxEmpty()
    {
        throw new NotImplementedException();
    }
}
