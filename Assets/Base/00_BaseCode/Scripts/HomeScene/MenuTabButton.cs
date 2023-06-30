using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public enum ButtonType
{ 
    HomeButton,
    ShopButton,
    RankButton
}

public class MenuTabButton : MonoBehaviour
{
    public ButtonType buttonType;
    public Animator animator;
    [SerializeField] private bool isSelected;
    [SerializeField] private Button button;
     HomeScene homeScene;

    public void Init(HomeScene paramHomeScene)
    {
      
        homeScene = paramHomeScene;
        button.onClick.AddListener(delegate { homeScene.HandleClickButton(buttonType); });
        isSelected = false;
    }
   
    
    public virtual void GetSelected()
    {
   
        if (!isSelected)
        {
            animator.ResetTrigger("Normal");
            animator.SetTrigger("Selected");
            //homeScene.HandleClickButton(buttonType);
            isSelected = true;
        }
      
    }

    public  void GetBackToNormal()
    {
     
        animator.ResetTrigger("Selected");
        animator.SetTrigger("Normal");
        isSelected = false;
 
    }


}