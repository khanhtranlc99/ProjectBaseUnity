using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutBoosterDrill : MonoBehaviour
{
    public static TutBoosterDrill Instance;
    public GameObject hand_1;
    void Start()
    {
        Instance = this;
        CheckIsReady();
    }

    public void CheckIsReady()
    {
        if (UseProfile.CurrentLevel == 5)
        {
            hand_1.SetActive(true);
            GameController.Instance.AnalyticsController.StartTut_2();
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
        GameController.Instance.AnalyticsController.EndTut_2();
    }
}
