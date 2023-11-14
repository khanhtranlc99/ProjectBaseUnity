using System.Collections;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_IOS
using UnityEngine.iOS;
#elif UNITY_ANDROID
using Google.Play.Review;
#endif

public class AppReview : MonoBehaviour
{
#if UNITY_ANDROID
    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;
    private Coroutine _coroutine;
#endif
    public void Init()
    {
    #if UNITY_ANDROID
        _coroutine = StartCoroutine(InitReview());
   #endif
    }


    // Ham nay Show AppReview
    public void RateAndReview()
    {
#if UNITY_IOS
        Device.RequestStoreReview();
#elif UNITY_ANDROID
        StartCoroutine(LaunchReview());
#endif
    }

#if UNITY_ANDROID
    private IEnumerator InitReview(bool force = false)
    {
        if (_reviewManager == null) _reviewManager = new ReviewManager();

        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            if (force) DirectlyOpen();
            yield break;
        }

        _playReviewInfo = requestFlowOperation.GetResult();
    }

    public IEnumerator LaunchReview()
    {
        if (_playReviewInfo == null)
        {
            if (_coroutine != null) StopCoroutine(_coroutine);
            yield return StartCoroutine(InitReview(true));
        }
        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        Debug.LogError(_playReviewInfo);
        yield return launchFlowOperation;

        _playReviewInfo = null;
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            DirectlyOpen();
            yield break;
        }
    }
#endif

    public void DirectlyOpen()
    {
        Application.OpenURL($"https://play.google.com/store/apps/details?id={Application.identifier}");
    }
}