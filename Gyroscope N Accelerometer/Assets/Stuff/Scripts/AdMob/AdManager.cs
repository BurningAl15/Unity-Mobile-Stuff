using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;
public class AdManager : MonoBehaviour {

    public static AdManager Instance { set; get; }

    public string bannerId, videoId;

	// Use this for initialization
	void Start () {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        #if UNITY_EDITOR
        #elif UNITY_ANDROID

        Admob.Instance().initAdmob(bannerId,videoId);
        Admob.Instance().setTesting(true);
        Admob.Instance().loadInterstitial();
        #endif
    }

    // Update is called once per frame
    void Update () {
    }

    public void ShowBanner()
    {
        #if UNITY_EDITOR
        #elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 5);
        #endif
    }

    public void ShowVideo()
    {
        #if UNITY_EDITOR
        #elif UNITY_ANDROID
        if(Admob.Instance().isInterstitialReady())
        {
            Admob.Instance().showInterstitial();
        }
        #endif
    }
}
