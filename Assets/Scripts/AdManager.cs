using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    public static AdManager instance;

    string AndroidGameID = "4919362";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(AndroidGameID);

        Advertisement.AddListener(this);
    }


    public void ShowAds()
    {
        print("Show ads");
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void ShowRewardedAds()
    {
        print("Show rewarded ads");
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            print("Reward The User");
        }
        if (showResult == ShowResult.Skipped)
        {
            print("User Skipped Ad");
        }
    }
}
