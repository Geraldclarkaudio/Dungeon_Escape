using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField]
    private string _androidGameID;
    [SerializeField]
    private string _iOSGameID;
    [SerializeField]
    private string _rewardedVideoAndroid;
    [SerializeField]
    private string _rewardedVideoIOS;
    [SerializeField]
    private bool _testMode = true;

    private string _adUnitId;
    private string _rewardAd;

    void Awake()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            _adUnitId = _androidGameID;
            _rewardAd = _rewardedVideoAndroid;
        }
        else
        {
            _adUnitId = _iOSGameID;
            _rewardAd = _rewardedVideoIOS;
        }

        Advertisement.Initialize(_adUnitId, _testMode);
    }

    public void ShowRewardedVideo()
    {
        if(Advertisement.IsReady(_rewardAd))
        {
            Advertisement.Show(_rewardAd);
        }
        else
        {
            Debug.Log("Rewarded Video Is Not Ready");
        }
    }

    public void OnUnityAdsDidFinish(string placementID, ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                GameManager.Instance._player.AddGems(100);
                UIManager.Instance.OpenShop(GameManager.Instance._player.diamonds);
                //give currency
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Awarded Ad is Ready!");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("No add: error");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad started!");
    }

    private void OnEnable()
    {
        Advertisement.AddListener(this);

    }
    private void OnDisable()
    {
        Advertisement.RemoveListener(this);
    }
}
