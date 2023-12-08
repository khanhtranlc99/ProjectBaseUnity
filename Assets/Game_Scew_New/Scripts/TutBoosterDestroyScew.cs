using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutBoosterDestroyScew : MonoBehaviour
{
    public static TutBoosterDestroyScew Instance;
    public GameObject hand_1;
    void Start()
    {
        Instance = this;
        CheckIsReady();
    }

    public void CheckIsReady()
    {
        if (UseProfile.CurrentLevel == 7)
        {
            hand_1.SetActive(true);
        }
    }
    public void Step_1()
    {
        hand_1.SetActive(false);
        TutorialSuport.Instance.handSuport.SetActive(true);
    }
    public void Step_2()
    {
        TutorialSuport.Instance.handSuport.SetActive(false);
    }
}
