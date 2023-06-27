using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Text;
#if UNITY_IOS
using Unity.Advertisement.IosSupport;
#endif


public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [HideInInspector] public MoneyEffectController moneyEffectController;
     public UseProfile useProfile;
    public DataContain dataContain;
    [HideInInspector] public MusicManagerGameBase musicManager;
    public AdmobAds admobAds;
    [HideInInspector] public AnalyticsController AnalyticsController;
    public IapController iapController;
    [HideInInspector] public SceneType currentScene;
  


    protected void Awake()
    {
        Instance = this;
        Init();

        DontDestroyOnLoad(this);

        //GameController.Instance.useProfile.IsRemoveAds = true;


#if UNITY_IOS

    if(ATTrackingStatusBinding.GetAuthorizationTrackingStatus() == 
    ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
    {

        ATTrackingStatusBinding.RequestAuthorizationTracking();

    }

#endif

    }

    private void Start()
    {
     //   musicManager.PlayBGMusic();
     
    }

    public void Init()
    {

       
        //Application.targetFrameRate = 60;
        //useProfile.CurrentLevelPlay = UseProfile.CurrentLevel;
        admobAds.Init();
        //musicManager.Init();
        iapController.Init();
    

        // GameController.Instance.admobAds.ShowBanner();
    }

    public void LoadScene(string sceneName)
    {
        Initiate.Fade(sceneName.ToString(), Color.black, 2f);
    }

  
}
public enum SceneType
{
    StartLoading = 0,
    MainHome = 1,
    GamePlay = 2
}