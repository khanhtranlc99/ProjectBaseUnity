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

    public Button btnBoosterDrill;
    public Button btnDestroyScew;
    public Text tvCoin;
    public Text tvLevel;
    public Button btnNumDrill;
    public Button btnNumDestroyScew;
    public Text tvNumDrill;
    public Text tvNumDestroyScew;
    public Sprite spritePlus;
    public Sprite spriteNum;

    public void Init()
    {
        tvLevel.text = "Level " + UseProfile.CurrentLevel;
        tvCoin.text = "" + UseProfile.Coin;
        EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.CHANGE_COIN, HandleShowCoin);
        HandleShowStateBooster();
        HandleUnlock();
        OffBoosterSpecial();
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            GameController.Instance.admobAds.ShowOpenAppAdsReady();
        }
        else
        {
            NotiBox.Setup(delegate { NotiBox.Setup(null).Close(); }).Show();
        }
    }
    public void OffBoosterSpecial()
    {
      if ( UseProfile.CurrentLevel == 15 || UseProfile.CurrentLevel == 25 || UseProfile.CurrentLevel == 40 || UseProfile.CurrentLevel == 60 || UseProfile.CurrentLevel == 80 || UseProfile.CurrentLevel == 90 )
        {
            btnBoosterDrill.gameObject.SetActive(false);
        }
    }

    public void HandleUnlock()
    {
        if (UseProfile.CurrentLevel < 5)
        {
            btnBoosterDrill.gameObject.SetActive(false);
        }
        else
        {
            btnBoosterDrill.gameObject.SetActive(true);
        }
        if (UseProfile.CurrentLevel < 7)
        {
            btnDestroyScew.gameObject.SetActive(false);
        }
        else
        {
            btnDestroyScew.gameObject.SetActive(true);
        }

    }

    public void HandleShowStateBooster()
    {

        btnBoosterDrill.onClick.RemoveAllListeners();
        btnDestroyScew.onClick.RemoveAllListeners();
        btnNumDrill.onClick.RemoveAllListeners();
        btnNumDestroyScew.onClick.RemoveAllListeners();
        if (UseProfile.DrillBooster <= 0)
        {
            btnNumDrill.image.sprite = spritePlus;
            btnNumDrill.onClick.AddListener(delegate { SuggetBox.Setup(GiftType.DrillBooster).Show(); GameController.Instance.musicManager.PlayClickSound(); });
            tvNumDrill.gameObject.SetActive(false);
            btnBoosterDrill.onClick.AddListener(delegate { SuggetBox.Setup(GiftType.DrillBooster).Show(); GameController.Instance.musicManager.PlayClickSound(); });
        }
        else
        {
            btnNumDrill.image.sprite = spriteNum;
            tvNumDrill.gameObject.SetActive(true);
            tvNumDrill.text = "" + UseProfile.DrillBooster;
            btnBoosterDrill.onClick.AddListener(HandleBoosterDrill);

        }


        if (UseProfile.DestroyScewBooster <= 0)
        {
            btnNumDestroyScew.image.sprite = spritePlus;
            btnNumDestroyScew.onClick.AddListener(delegate { SuggetBox.Setup(GiftType.DestroyScewBooster).Show(); GameController.Instance.musicManager.PlayClickSound(); });
            tvNumDestroyScew.gameObject.SetActive(false);
            btnDestroyScew.onClick.AddListener(delegate { SuggetBox.Setup(GiftType.DestroyScewBooster).Show(); GameController.Instance.musicManager.PlayClickSound(); });
        }
        else
        {
            btnNumDestroyScew.image.sprite = spriteNum;
            tvNumDestroyScew.gameObject.SetActive(true);
            tvNumDestroyScew.text = "" + UseProfile.DestroyScewBooster;
            btnDestroyScew.onClick.AddListener(HandleBoosterDestroyScew);
        }



    }

    public void HandleBoosterDrill()
    {
        GameManager.instance.isUseDrillBooster = true;
        UseProfile.DrillBooster -= 1;
        HandleShowStateBooster();
        BlockBooster(false);
        if (UseProfile.CurrentLevel == 5)
        {
            TutBoosterDrill.Instance.Step_1();
        }
        GameController.Instance.musicManager.PlayClickSound();
    }
    public void HandleBoosterDestroyScew()
    {
        GameManager.instance.isUseDestroyScewBooster = true;
        UseProfile.DestroyScewBooster -= 1;
        HandleShowStateBooster();
        BlockBooster(false);
        if (UseProfile.CurrentLevel == 7)
        {
            TutBoosterDestroyScew.Instance.Step_1();
        }
        GameController.Instance.musicManager.PlayClickSound();
    }
    public void BlockBooster(bool param)
    {
        btnNumDrill.interactable = param;
        btnBoosterDrill.interactable = param;
        btnNumDestroyScew.interactable = param;
        btnDestroyScew.interactable = param;
    }

    private void HandleShowCoin(object param)
    {
        tvCoin.text = "" + UseProfile.Coin;

    }
    private void OnDestroy()
    {
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.CHANGE_COIN, HandleShowCoin);
    }
    public override void OnEscapeWhenStackBoxEmpty()
    {
    
    }
}
