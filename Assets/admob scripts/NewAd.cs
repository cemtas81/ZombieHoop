using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;


public class NewAd : MonoBehaviour
{
    //public Image can;
    //public bool death;
    //public float kalan;
    public enum AdmobBannerSize
    {
        Banner,
        SmartBanner,
        IABBanner,
        MediumRectangle,
        LeaderBoard
    };

    [Header("Admob Setup")]
    public bool showTestAds = true;

    [Space(20), Header("Admob Ids")]
    [SerializeField] private string admobAppId = "";
    [Space(10)]
    [SerializeField] private string admobBannerId = "";
    [SerializeField] private string admobIntersititialId = "";
    [SerializeField] private string admobRewardedId = "";

    private string admobTestBannerId = "ca-app-pub-3940256099942544/6300978111";
    private string admobTestIntersititialId = "ca-app-pub-3940256099942544/1033173712";
    private string admobTestRewardedId = "ca-app-pub-3940256099942544/5224354917";

    [Space(20), Header("Admob Banner Ad Setup")]
    [SerializeField] private AdmobBannerSize bannerSize = AdmobBannerSize.SmartBanner;
    [SerializeField] private AdPosition bannerPosition = AdPosition.Bottom;

    private BannerView bannerView;
    private InterstitialAd interstitial;
    

    public void Start()
    {
        MobileAds.Initialize(initStatus => { });
        MobileAds.Initialize(interstitial => { });
       
        RequestInterstitial();
    }
  

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();

        //.AddKeyword("game")

    }

    #region Banner Ad Controlles
    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }

    public void RequestBanner()
    {
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }

        AdSize size = AdSize.SmartBanner;

        switch (bannerSize)
        {
            case AdmobBannerSize.SmartBanner:
                size = AdSize.SmartBanner;
                break;
            case AdmobBannerSize.MediumRectangle:
                size = AdSize.MediumRectangle;
                break;
            case AdmobBannerSize.IABBanner:
                size = AdSize.IABBanner;
                break;
            case AdmobBannerSize.LeaderBoard:
                size = AdSize.Leaderboard;
                break;
            default:
                size = AdSize.Banner;
                break;
        }

        if (showTestAds)
        {
            this.bannerView = new BannerView(admobTestBannerId, size, bannerPosition);
        }
        else
        {
            this.bannerView = new BannerView(admobBannerId, size, bannerPosition);
        }

        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        

        this.bannerView.LoadAd(this.CreateAdRequest());
    }
    #endregion

    #region Intersititial Ad Controller
    public void RequestInterstitial()
    {
        if (this.interstitial != null)
        {
            if (interstitial.IsLoaded() == false)
            {
                this.interstitial.Destroy();
            }
            else
            {
                return;
            }

        }

        if (showTestAds)
        {
            this.interstitial = new InterstitialAd(admobTestIntersititialId);
        }
        else
        {
            this.interstitial = new InterstitialAd(admobIntersititialId);
        }

        this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
        this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
       

        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    public bool IsIntersititialAdLoaded()
    {
        return this.interstitial.IsLoaded();
    }

    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            
        }
        StartCoroutine(bekleme());
    }
    IEnumerator bekleme()
    {
        yield return new WaitForSeconds(0.5f);
        
        RequestInterstitial();
       
    }
    #endregion

    #region Rewarded Video Controlles
    private bool isRewardedRequested = false;
    //public void RequesRewardedVideoAd()
    //{
    //    if (this.rewardedAd != null)
    //    {
    //        if (this.rewardedAd.IsLoaded())
    //        {
    //            return;
    //        }
    //    }
    //    this.rewardedAd = RewardBasedVideoAd.Instance;
    //    this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
    //    this.rewardedAd.OnAdFailedToLoad += RewardedAdFailedToLoad;
    //    this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
    //    this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
    //    this.rewardedAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
    //    AdRequest request = this.CreateAdRequest();
    //    if (showTestAds)
    //    {
    //        this.rewardedAd.LoadAd(request, admobTestRewardedId);
    //    }
    //    else
    //    {
    //        this.rewardedAd.LoadAd(request, admobRewardedId);
    //    }
    //}

    //public bool IsRewardedAdLoaded()
    //{
    //    return this.rewardedAd.IsLoaded();
    //}

    //public bool ShowRewardedAd()
    //{
    //    if (this.rewardedAd.IsLoaded())
    //    {
    //        this.rewardedAd.Show();
    //        return true;
    //    }
    //    return false;
    //}
    #endregion

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeftApplication event received");
    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        Debug.Log("reklamhazir");
       
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("reklamhazirlanamadi");
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialOpened event received");
        Debug.Log("acildi");
        
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        Debug.Log("kapandi");
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialLeftApplication event received");
    }

    #endregion

    #region RewardedAd callback handlers

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void RewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        //RequesRewardedVideoAd();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
    }
    #endregion
}
