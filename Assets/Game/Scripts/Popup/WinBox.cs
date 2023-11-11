using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class WinBox : BaseBox
{
    #region instance
    private static WinBox instance;
    public static WinBox Setup(int score, bool doubleReward,bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<WinBox>(PathPrefabs.WIN_BOX));
            instance.Init();
        }

        instance.InitState(score, doubleReward);
        return instance;
    }
    #endregion

    #region Var
    
  //  [SerializeField] private Button btnBackHome;
    [SerializeField] private Button btnNext;
    [SerializeField] private Button btnDoubleReward;
    [SerializeField] private Button btnClose;
    public GameObject broadProgess;
    public ProgessIconText progessLevelChest;
    [SerializeField] private int score;
    [SerializeField] private Text tvScore;
    [SerializeField] private GachaBar gachaBar;
    [SerializeField] private BroadProgess broadProgessContro;
    public int totalProgessComplete = 2;
    public int countProgessComplete;
    public List<Transform> lsTranformPost;
    public bool doubleRewardWinBox;
    public AudioClip winMusic;
    #endregion


    private void Init()
    {  
        btnNext.onClick.AddListener(delegate { HandleOnClickBtnNext(); });
        btnClose.onClick.AddListener(delegate { HandleOnClickBtnBackHome(); });
        btnDoubleReward.onClick.AddListener(delegate { HandleOnClickBtnReward(); });
        //btnBackHome.onClick.AddListener(delegate { HandleOnClickBtnBackHome(); });

    }
    private void InitState(int paramScore, bool doubleReward)
    {
        //doubleRewardWinBox = false;
    
        btnNext.interactable = false;
        btnClose.interactable = false;
        btnDoubleReward.interactable = false;
        countProgessComplete = 0;
        gachaBar.InitState();
        score = paramScore;
        tvScore.text = "Claim" + "\n" + score;
        
        CheckOpenGiftBox(doubleReward);

  

        UseProfile.CurrentLevel += 1;
        if (UseProfile.CurrentLevel > KeyPref.MAX_LEVEL)
        {
            UseProfile.CurrentLevel = KeyPref.MAX_LEVEL;
        }
        GameController.Instance.musicManager.PlaySound(winMusic);
        GameController.Instance.admobAds.HandleShowMerec();
    }
    
    private void HandleOnClickBtnBackHome()
    {
        

        GameController.Instance.admobAds.ShowInterstitial(true,actionIniterClose: () =>
        {
            UpdateEgg(score);        
            Initiate.Fade(SceneName.HOME_SCENE, Color.black, 1.5f);

        }, actionWatchLog: "BackHomeWinBox");
    }

    private void HandleOnClickBtnNext()
    {
        GameController.Instance.admobAds.ShowInterstitial(true, actionIniterClose: () =>
        {
            //UpdateEgg(score);     
            //Close();
            //Initiate.Fade(SceneName.GAME_PLAY, Color.black, 2);
            UseProfile.Coin += 100;
            Next();

        }, actionWatchLog: "NextLevel");
      
       
        // SceneManager.LoadScene(SceneName.GAME_PLAY);
    }
    void Next()
    {
        GameController.Instance.admobAds.HandleHideMerec();
        if (AudioManager.instance)
        {
            AudioManager.instance.Play("Fill");
            GameManager.instance.vibration();
        }


        //NEXT BUTTON CALL
        if (PlayerPrefs.GetInt("Level", 1) >= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(UnityEngine.Random.Range(0, SceneManager.sceneCountInBuildSettings - 1));
            PlayerPrefs.SetInt("Level", (PlayerPrefs.GetInt("Level", 1) + 1));
        }
        else
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("Level", (PlayerPrefs.GetInt("Level", 1) + 1));
        }

        PlayerPrefs.SetInt("levelnumber", PlayerPrefs.GetInt("levelnumber", 1) + 1);
        Close();
    }
    private void HandleOnClickBtnReward()
    {


        GameController.Instance.admobAds.ShowVideoReward(delegate { ClaimReward(); }, delegate
        {
            GameController.Instance.moneyEffectController.SpawnEffectText_FlyUp_UI
            (   
                btnDoubleReward.transform,
                btnDoubleReward.transform.position,
                "No video at the moment!",
                Color.white,
                isSpawnItemPlayer: true
            );
        }, delegate { }, ActionWatchVideo.RewardEndGame, UseProfile.CurrentLevel.ToString());

      

     

    }
    void ClaimReward()
    {
        score *= gachaBar.ValueReward;
        List<GiftRewardShow> lstReward = new List<GiftRewardShow>();
        lstReward.Add(new GiftRewardShow() { amount = score, type = GiftType.Coin });
        UpdateEgg(score);
  
        RewardIAPBox.Setup2().Show(lstReward, delegate
        {
            UseProfile.Coin += (100 * gachaBar.ValueReward);
            Next();

        });
    }
    private void UpdateEgg(int param)
    {
        UseProfile.Coin += param;
     
    }
    private void CheckOpenGiftBox(bool doubleReward)
    {  
        if (progessLevelChest.gameObject.activeSelf)
        {
            progessLevelChest.Init(this);
        } 
    }

    public void OnOffAllButton(bool onInteractable)
    {
        btnNext.interactable = onInteractable;
        btnClose.interactable = onInteractable;
        btnDoubleReward.interactable = onInteractable;

   
    }
  
    public bool CanClaimpLevelChest
    {
        get
        {
            int tempLevel = 0;
            int tempSubtraction = 0;
            var tempLsLevelChest = new levelChest();
            var tempLevelChestOld = new levelChest();
            var tempContro = GameController.Instance.dataContain.levelChestData.lsLevelChest;
            var tempCurrent = GameController.Instance.dataContain.levelChestData.CurrentLevelChest;
            if (tempCurrent == null)
            {
                return false;
            }
            if (UseProfile.LevelOfLevelChest == 0)
            {

             
                return false;
            }
            else
            {

                for (int i = 0; i < tempContro.Count; i++)
                {
                    if (tempContro[i] == tempCurrent)
                    {

                        tempLevelChestOld = tempContro[i - 1];
                        tempLsLevelChest = tempCurrent;
                        break;
                    }
                }
            }

            var tempCur = UseProfile.CurrentLevelOfLevelChest;
            var tempCurPlus = tempCur + 1;
          //  Debug.LogError("ProgessLevelChestInit " + UseProfile.CurrentLevelOfLevelChest);
            tempSubtraction = (tempCurrent.level - tempLevelChestOld.level);

            if (tempCurPlus == tempSubtraction)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }


}
