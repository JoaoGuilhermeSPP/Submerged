using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADSMANAGER : MonoBehaviour
{
    private BannerView bannerView;
    private string bannerID = "ca-app-pub-4730318860441923/9411927295";
 private InterstitialAd interstitialAd;
    private string interstitialID = "ca-app-pub-4730318860441923/1206397549";
 
   
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => {});
      RequestInterstitial();
        RequesBanner();
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RequesBanner(){
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }
       private void RequestInterstitial(){
        AdRequest request = new AdRequest.Builder().Build();
        InterstitialAd.Load(interstitialID, request,(InterstitialAd ad, LoadAdError error) =>{
            if(error != null || ad==null){
                Debug.LogError("intertitial ad failede to load an ad" + "with erro : " + error);
                return;
            }
            Debug.Log("Intertitial ad loaded with response : " 
            + ad.GetResponseInfo());

            interstitialAd =ad;
        });
    }
    public void intertitialShow(){
        interstitialAd.Show();
    }
   
}
