using System;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System.Collections;

public class GoogleMobileAdsHandler : IDefaultInAppPurchaseProcessor
{
    private readonly string[] validSkus = { "com.ecode.TrainSurfers" };

    //Will only be sent on a success.
    public void ProcessCompletedInAppPurchase(IInAppPurchaseResult result)
    {
        result.FinishPurchase();
        GoogleMobileAdsDemoScript.OutputMessage = "Purchase Succeeded! Credit user here.";
    }

    //Check SKU against valid SKUs.
    public bool IsValidPurchase(string sku)
    {
        foreach(string validSku in validSkus)
        {
            if (sku == validSku)
            {
                return true;
            }
        }
        return false;
    }

    //Return the app's public key.
    public string AndroidPublicKey
    {
        //In a real app, return public key instead of null.
        get { return null; }
    }
}

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public  class GoogleMobileAdsScript : MonoBehaviour
{
    public static GoogleMobileAdsScript Instance;
    public static BannerView bannerView;
    public static InterstitialAd interstitial, rewardBasedVideo;
  //  public static RewardBasedVideoAd rewardBasedVideo = null;
    private static string outputMessage = "";

    public static string OutputMessage
    {
        set { outputMessage = value; }
    }

    IEnumerator DELAY()
    {
        yield return new WaitForSeconds(1);
        bannerView.Hide();
    }


    void Awake()
    {
        Instance = this;
        RequestBanner();
        RequestInterstitial();
      //  rewardBasedVideo = RewardBasedVideoAd.Instance;
        RequestRewardBasedVideo(0);
      //  RequestRewardBasedVideo(1);
        StartCoroutine(DELAY());
    }
    void Start()
    {
     
    }


   /// <summary>
   /// show the 
   /// </summary>
   public  void showbanermain()
    {
        RequestBanner();
        bannerView.Show();

    }

    #region các hàm chính
    public void showbaner()
    {
        bannerView.Show();
    }
    public void hidebaner()
    {
        bannerView.Hide();
    }
    public void showfullbaner()
    {
        ShowInterstitial();
        RequestInterstitial();
    }
    
    public void showvideo()
    {
        ShowRewardBasedVideo();
        RequestRewardBasedVideo(0);
    }
    AdRequest adrewet;

    int changevideo = 0;
    public void Getadsvideo()
    {
  
         
   
      
    }
    public  string baner_Adr = "ca-app-pub-6102026202830298/6732848768";
    public string fullbaner_Adr = "ca-app-pub-6102026202830298/8209581965";
    public string video_Adr = "ca-app-pub-6102026202830298/8069981161";
    //public string video_Adr = "ca-app-pub-6190532367875222/4694685199";
    public string baner_IOS = "ca-app-pub-6102026202830298/2023447564";
    public string fullbaner_IOS = "ca-app-pub-6102026202830298/3500180763";
    public string video_IOS = "ca-app-pub-6102026202830298/4976913965";
    #endregion

    private void RequestBanner()
    {
#if UNITY_EDITOR
            string adUnitId = "baner_Adr";
#elif UNITY_ANDROID
            string adUnitId = baner_Adr;
#elif UNITY_5 || UNITY_IOS || UNITY_IPHONE
            string adUnitId = baner_IOS;
#else
            string adUnitId = baner_Adr;
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
        bannerView.LoadAd(createAdRequest());
    }

    private void RequestInterstitial()
    {
        #if UNITY_EDITOR
            string adUnitId = "fullbaner_Adr";
#elif UNITY_ANDROID
            string adUnitId = fullbaner_Adr;
#elif UNITY_5 || UNITY_IOS || UNITY_IPHONE
            string adUnitId = fullbaner_IOS;
#else
            string adUnitId = fullbaner_Adr;
#endif

        // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);
        interstitial.LoadAd(createAdRequest());
    }

    // Returns an ad request with custom ad targeting.
    private AdRequest createAdRequest()
    {
        return new AdRequest.Builder()
                //.AddTestDevice(AdRequest.TestDeviceSimulator)
                //.AddTestDevice("F415B5CCA8A995ADB9AE223D3B9310BB")
                //.AddKeyword("game")
                //.SetGender(Gender.Male)
                //.SetBirthday(new DateTime(1985, 1, 1))
                //.TagForChildDirectedTreatment(false)
                //.AddExtra("color_bg", "9B30FF")
                .Build();
    }

    private void RequestRewardBasedVideo(int value)
    {
        #if UNITY_EDITOR
            string adUnitId = "video_Adr";
#elif UNITY_ANDROID
            string adUnitId = video_Adr;
#elif UNITY_5 || UNITY_IOS || UNITY_IPHONE
            string adUnitId = video_IOS;
#else
            string adUnitId = video_Adr;
#endif
        if (value == 0)
        {
            //rewardBasedVideo.LoadAd(createAdRequest(), adUnitId);
            rewardBasedVideo = new InterstitialAd(adUnitId);
            rewardBasedVideo.LoadAd(createAdRequest());

        }
        if (value == 1)
        {
          //  rewardBasedVideo1.LoadAd(createAdRequest(), adUnitId);
        }

    }

    private void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            print("Interstitial is not ready yet.");
        }
    }
    private void ShowRewardBasedVideo()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        } else
        {
            print("Reward based video ad is not ready yet.");
        }
    }
  

    public bool ADS_Video_GetIsloaded()
    {
        if (rewardBasedVideo != null)
        {
            Debug.Log("TAIR CHUWA " + rewardBasedVideo.IsLoaded());
            return rewardBasedVideo.IsLoaded();
        }
        else return true;
    }
}
