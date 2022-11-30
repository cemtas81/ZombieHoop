using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdMob_Reward : MonoBehaviour
{
    private RewardedAd rewardedAd;

    public GameObject noThanks_Button; 
    int odulAlindi = 0;
    int secim = 0;

    //public static int gold_magnet;
    //public static int health_magnet;
    //public GameObject goldMagnetButton;
    //public GameObject healthMagnetButton;

    //[Header("Resume Reward")]
    //public GameObject failPanel;
    //public GameObject Age_Bar;
    //public GameObject CoinCountText;
    //public GameObject RoadOBJ;
    //public GameObject GroundSpawner;
    //public GameObject karakter;

    //[Header("Boss Scene")]
    //bool isOpen_BossScene = false;
    //[SerializeField] private GameObject bg;
    //[SerializeField] private GameObject ZombieBoss;
    //[SerializeField] private GameObject ZombieBoss2;
    //[SerializeField] private GameObject ZombieScript;

    private void FixedUpdate()
    {
        if (odulAlindi == 1)
            noThanks_Button.SetActive(false);
    }

    public void CreateAndLoadRewardedAd()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-9585813676258300/6526551808";
#elif UNITY_IPHONE
        adUnitId = "ca-app-pub-9585813676258300/6143408429";
#else
            adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        //this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    void Start()
    {
        //isOpen_BossScene = false;

        odulAlindi = 0;
        secim = 0;

        //gold_magnet = 0;
        //health_magnet = 0;

        MobileAds.Initialize(initStatus => { });
        this.CreateAndLoadRewardedAd();
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
        Debug.Log("Reklam Yuklendi.");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");

        Time.timeScale = 1;

        if (PlayerPrefs.GetInt("sound") == 0)
            AudioListener.volume = 1;

        Debug.Log("Reklam Kapandi.");
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed -= HandleRewardedAdClosed;
        this.CreateAndLoadRewardedAd();
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        odulAlindi = 1;
        MonoBehaviour.print("HandleRewardedAdRewarded event received for " + 3000.ToString() + "coins " + odulAlindi);



    }

    //public void HandleUserEarnedReward(object sender, Reward args)
    //{
    //    if (secim == 1) //level sonu paranın 5 katini alir.
    //    {
    //        PlayerPrefs.SetInt("allCoin", (int)((PlayerPrefs.GetInt("allCoin")) + (Coin.collectedCoin * RangeBar.multiplier * 5)));
    //        odulAlindi = 1;
    //        Invoke("Invoke_SceneLoad", .5f);
    //    }
        //else if(secim == 2) // bolumun gecilmesinin saglar.
        //{
        /*failPanel.SetActive(false);
        Age_Bar.SetActive(true);
        CoinCountText.SetActive(true);
        RoadOBJ.SetActive(false);
        GroundSpawner.SetActive(true);
        karakter.GetComponent<Animator>().SetTrigger("resume");*/

        //        if (PlayerPrefs.GetInt("sahneSecim") == 0)
        //        {
        //            SceneManager.LoadScene(0);
        //            PlayerPrefs.SetInt("sahneSecim", 1);
        //        }
        //        else if (PlayerPrefs.GetInt("sahneSecim") == 1)
        //        {
        //            SceneManager.LoadScene(0);
        //            PlayerPrefs.SetInt("sahneSecim", 2);
        //        }
        //        else if (PlayerPrefs.GetInt("sahneSecim") == 2)
        //        {
        //            SceneManager.LoadScene(0);
        //            PlayerPrefs.SetInt("sahneSecim", 3);
        //        }
        //        else if (PlayerPrefs.GetInt("sahneSecim") == 3)
        //        {
        //            SceneManager.LoadScene(0);
        //            PlayerPrefs.SetInt("sahneSecim", 4);
        //        }
        //        else if (PlayerPrefs.GetInt("sahneSecim") == 4)
        //        {
        //            SceneManager.LoadScene(0);
        //            PlayerPrefs.SetInt("sahneSecim", 5);
        //        }
        //        else if (PlayerPrefs.GetInt("sahneSecim") == 5)
        //        {
        //            SceneManager.LoadScene(0);
        //            PlayerPrefs.SetInt("sahneSecim", 6);
        //        }
        //        else if (PlayerPrefs.GetInt("sahneSecim") == 6)
        //        {
        //            SceneManager.LoadScene(0);
        //            PlayerPrefs.SetInt("sahneSecim", 7);
        //        }
        //        else if (PlayerPrefs.GetInt("sahneSecim") == 7)
        //        {
        //            SceneManager.LoadScene(0);
        //            PlayerPrefs.SetInt("sahneSecim", 0);
        //        }
        //    }
        //    else if(secim == 3) //silahin seviyesini arttirir.
        //    {
        //        PlayerPrefs.SetInt("weaponLevel", PlayerPrefs.GetInt("weaponLevel") + 1);
        //        PlayerPrefs.SetInt("weaponPrice", PlayerPrefs.GetInt("weaponPrice") + 45);
        //    }

        //    else if(secim == 4) //carpanin seviyesini arttirir.
        //    {
        //        PlayerPrefs.SetFloat("firstX", PlayerPrefs.GetFloat("firstX") + .6f);
        //        PlayerPrefs.SetInt("firstPrice", PlayerPrefs.GetInt("firstPrice") + 70);
        //    }

        //    else if(secim == 5) //age_bar in .12 dolmasini saglar.
        //    {
        //        Age_Bar.transform.GetChild(0).GetComponent<Image>().fillAmount += .12f;
        //    }

        //    else if (secim == 6) //altin miknatisini aktive eder.
        //    {
        //        gold_magnet = 1;
        //        goldMagnetButton.SetActive(false);
        //    }

        //    else if (secim == 7) //can miknatisini aktive eder.
        //    {
        //        health_magnet = 1;
        //        healthMagnetButton.SetActive(false);
        //    }

        //    else if (secim == 8) //boss sahnesini acar.
        //    {
        //        isOpen_BossScene = true;
        //        bg.SetActive(false);
        //        ZombieBoss.GetComponent<Animator>().SetTrigger("Start_Game");
        //        ZombieBoss2.GetComponent<Animator>().SetTrigger("Start_Game");
        //        ZombieScript.GetComponent<Zombie_Script>().Invoke_Particles();
        //        Zombie_Script.isGameStart = true;
        //    }

        //    string type = args.Type;
        //    double amount = args.Amount;
        //    MonoBehaviour.print(
        //        "HandleRewardedAdRewarded event received for "
        //                    + amount.ToString() + " " + type);
        //}

        //public void UserChoseToWatchAd1()
        //{
        //    secim = 1;

        //    if (this.rewardedAd.IsLoaded())
        //    {
        //        if (PlayerPrefs.GetInt("sound") == 0)
        //            AudioListener.volume = 0;

        //        this.rewardedAd.Show();
        //    }

        //    // Called when an ad request has successfully loaded.
        //    this.rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
        //}

        //public void UserChoseToWatchAd2()
        //{
        //    secim = 2;
        //    //Time.timeScale = 0;
        //    if (this.rewardedAd.IsLoaded())
        //    {
        //        if (PlayerPrefs.GetInt("sound") == 0)
        //            AudioListener.volume = 0;

        //        this.rewardedAd.Show();
        //    }

        //    // Called when an ad request has successfully loaded.
        //    this.rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;

        //}

        //public void UserChoseToWatchAd3()
        //{
        //    secim = 3;
        //    //Time.timeScale = 0;
        //    if (this.rewardedAd.IsLoaded())
        //    {
        //        if (PlayerPrefs.GetInt("sound") == 0)
        //            AudioListener.volume = 0;

        //        this.rewardedAd.Show();
        //    }
        //    // Called when an ad request has successfully loaded.
        //    this.rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
        //}

        //public void UserChoseToWatchAd4()
        //{
        //    secim = 4;
        //    //Time.timeScale = 0;
        //    if (this.rewardedAd.IsLoaded())
        //    {
        //        if (PlayerPrefs.GetInt("sound") == 0)
        //            AudioListener.volume = 0;

        //        this.rewardedAd.Show();
        //    }
        //    // Called when an ad request has successfully loaded.
        //    this.rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
        //}

        //public void UserChoseToWatchAd5()
        //{
        //    secim = 5;
        //    if (this.rewardedAd.IsLoaded())
        //    {
        //        if (PlayerPrefs.GetInt("sound") == 0)
        //            AudioListener.volume = 0;
        //        Time.timeScale = 0;
        //        this.rewardedAd.Show();
        //    }

        //    // Called when an ad request has successfully loaded.
        //    this.rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
        //}

        //public void UserChoseToWatchAd6()
        //{
        //    secim = 6;
        //    if (this.rewardedAd.IsLoaded())
        //    {
        //        if (PlayerPrefs.GetInt("sound") == 0)
        //            AudioListener.volume = 0;
        //        Time.timeScale = 0;
        //        this.rewardedAd.Show();
        //    }

        //    // Called when an ad request has successfully loaded.
        //    this.rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
        //}

        //public void UserChoseToWatchAd7()
        //{
        //    secim = 7;
        //    if (this.rewardedAd.IsLoaded())
        //    {
        //        if (PlayerPrefs.GetInt("sound") == 0)
        //            AudioListener.volume = 0;
        //        Time.timeScale = 0;
        //        this.rewardedAd.Show();
        //    }

        //    // Called when an ad request has successfully loaded.
        //    this.rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
        //}

        //public void UserChoseToWatchAd8()
        //{
        //    secim = 8;

        //    if (this.rewardedAd.IsLoaded())
        //    {
        //        if (PlayerPrefs.GetInt("sound") == 0)
        //            AudioListener.volume = 0;
        //        Time.timeScale = 0;
        //        this.rewardedAd.Show();
        //    }

        //    // Called when an ad request has successfully loaded.
        //    this.rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
        //}

        //void Invoke_SceneLoad()
        //{
        //    if (PlayerPrefs.GetInt("AdMob") == 0)
        //    {
        //        this.GetComponent<AdMob_Banner>().Banner_Destroy();
        //        this.GetComponent<AdMob_Inter>().InterDestroy();
        //    }

        //    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        //    if (PlayerPrefs.GetInt("sahneSecim") == 0)
        //    {
        //        SceneManager.LoadScene(0);
        //        PlayerPrefs.SetInt("sahneSecim", 1);
        //    }
        //    else if (PlayerPrefs.GetInt("sahneSecim") == 1)
        //    {
        //        SceneManager.LoadScene(0);
        //        PlayerPrefs.SetInt("sahneSecim", 2);
        //    }
        //    else if (PlayerPrefs.GetInt("sahneSecim") == 2)
        //    {
        //        SceneManager.LoadScene(0);
        //        PlayerPrefs.SetInt("sahneSecim", 3);
        //    }
        //    else if (PlayerPrefs.GetInt("sahneSecim") == 3)
        //    {
        //        SceneManager.LoadScene(0);
        //        PlayerPrefs.SetInt("sahneSecim", 4);
        //    }
        //    else if (PlayerPrefs.GetInt("sahneSecim") == 4)
        //    {
        //        SceneManager.LoadScene(0);
        //        PlayerPrefs.SetInt("sahneSecim", 5);
        //    }
        //    else if (PlayerPrefs.GetInt("sahneSecim") == 5)
        //    {
        //        SceneManager.LoadScene(0);
        //        PlayerPrefs.SetInt("sahneSecim", 6);
        //    }
        //    else if (PlayerPrefs.GetInt("sahneSecim") == 6)
        //    {
        //        SceneManager.LoadScene(0);
        //        PlayerPrefs.SetInt("sahneSecim", 7);
        //    }
        //    else if (PlayerPrefs.GetInt("sahneSecim") == 7)
        //    {
        //        SceneManager.LoadScene(0);
        //        PlayerPrefs.SetInt("sahneSecim", 0);
        //    }
        //}

    }
