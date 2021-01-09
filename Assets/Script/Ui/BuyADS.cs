using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BuyADS : MonoBehaviour {
    public string UrlApp1;
    public string UrlApp2;
    public string UrlApp3;
    public string UrlApp4;
    public string UrlApp5;
    public static BuyADS Instance;
    public Image mainimage, app1, app2, app3, app4, app5;
    public Text Shownameapp;
    public Button showbtn;
    public GameObject showbtnss;
    public GameObject showbtnssnotinternet;
    public Animator aminnotinternet;
    
    // Use this for initialization
    void Start () {
        Instance = this;
        amin.enabled = false;
        BuyADS.Instance.GetLisGame();
        WhatFBlog();
        //   
        //  showapp_Android();

#if UNITY_EDITOR
        // showapp_Android();
#elif UNITY_ANDROID
       //  showapp_Android();
#elif UNITY_IPHONE
        showapp_IOS();
        Showbtn();

#else
          
#endif
        // showapp();
    }

    public  void WhatFBlog()
    {
        if (PlayerPrefs.GetInt("alowgetcoin")==0)
        {
            showbtn.gameObject.SetActive(true);
        }
        else
        {
         
            showbtn.gameObject.SetActive(false);
        }
    }
    int randum(int value)
    {
        return Random.Range(0,3);
    }

    // public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
    public string url = "https://lh3.googleusercontent.com/8Kq1mSdXb50fNoEP2fzwWap4VEYhxvGcRvG7rl_z3sZBj0rs3Q-XHCF9XXs3kh75PGU=w300-rw";



    public void Openshow()
    {

#if UNITY_EDITOR
      //  jumptolink();
#elif UNITY_ANDROID
       // jumptolink();
#elif UNITY_IPHONE
    //jumptolink();
#endif

    }
    string openurl = "";

   public void jumptolink(string Geturl)
    {
        if (alow)
        {

            //  alow = false;
          


            StartCoroutine(checkInternetConnection(Geturl));
        }
       
    }
    IEnumerator checkInternetConnection(string Geturl)
    {
      
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            //if (amin != null)
            //{
            //    amin.StartPlayback();
            //    amin.enabled = false;
            //}
            if (showbtnss != null)
                showbtnss.transform.position = new Vector3(showbtnss.transform.position.x, Screen.height + Screen.height / 10, showbtnss.transform.position.z);
            //if (aminnotinternet != null)
            //{
            //    aminnotinternet.enabled = false;
            //}
            //if (showbtnssnotinternet != null)
            //{
            //    showbtnssnotinternet.transform.position = new Vector3(showbtnss.transform.position.x, Screen.height + Screen.height / 10, showbtnss.transform.position.z);
            //}
            aminnotinternet.Play("open");
            yield return new WaitForSeconds(0.5f);
            aminnotinternet.enabled = true;
            yield return new WaitForSeconds(1.5f);
            aminnotinternet.SetBool("open", true);
            yield return new WaitForSeconds(1.5f);
            aminnotinternet.SetBool("open", false);
            aminnotinternet.enabled = false;
            aminnotinternet.enabled = false;
        }
        else {
            if (continuedjumptolink)
            {
                continuedjumptolink = false;
                Application.OpenURL(Geturl);
                StartCoroutine(delayjumtolink());
                yield return new WaitForSeconds(3f);
            }
        }
        continuedjumptolink = true;
        alow = true;
    }
    string valuecoin;
    int valuecoinint;
    public void Getvaluue(Text value)
    {
        valuecoin = value.text ;
    }
    bool continuedjumptolink = true;
    IEnumerator delayjumtolink()
    {
        yield return new WaitForSeconds(0.2f);
        if (alow)
        {
           
            continuedjumptolink = true;
            if (Playermuving.player.transform.position.z < -5)
            {
                if (shopearm.active == true)
                {
                    UImanager.uimanager.onpenshopEarm();
                }
               
            }
            else
            {
                showText();
            }
       //     StartCoroutine(StartAnimationdelay("Get " + valuecoin + " coin"));
            managerdata.manager.savecoin(int.Parse(valuecoin));

        }
    }
 
    void showapp_IOS()
    {
        int randumapp = 0;
        randumapp = Random.Range(0, 3);
        UrlApp1 = "https://itunes.apple.com/us/app/animal-cute/id1121097861?mt=8";
        UrlApp2 = "https://itunes.apple.com/us/app/360-play/id1123256343?mt=8";
        UrlApp3 = "https://itunes.apple.com/us/app/magic-glyphs/id1121891846?mt=8";
        string openurl = "";
        switch (randumapp)
        {
            case 0:
                mainimage = app1;
                openurl = UrlApp1;
                break;
            case 2:
                mainimage = app2;
                openurl = UrlApp2;
                break;
            case 3:
                mainimage = app3;
                openurl = UrlApp3;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// show video
    /// </summary>
	public void  Earm_tovide()
    {
       StartCoroutine(checkInternetConnection());
    }

    IEnumerator checkInternetConnection()
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            aminnotinternet.Play("open");
            yield return new WaitForSeconds(0.5f);
            aminnotinternet.enabled = true;
            yield return new WaitForSeconds(1.5f);
            aminnotinternet.SetBool("open", true);
            yield return new WaitForSeconds(1.5f);
            aminnotinternet.SetBool("open", false);
            aminnotinternet.enabled = false;
            aminnotinternet.enabled = false;
        }
        else {

            if (GoogleMobileAdsScript.Instance.ADS_Video_GetIsloaded())
            {
              
                GoogleMobileAdsScript.Instance.showvideo();
                StartCoroutine(delayshow());
            }

        }
    }

    bool cliccontinued = true;
       IEnumerator delayshow()
    {
        yield return new WaitForSeconds(2);
        managerdata.manager.savekey(3);
        yield return new WaitForSeconds(2);
        if (Playermuving.player.transform.position.z<-5)
        {
            if (shopearm.active == true)
            {
                UImanager.uimanager.onpenshopEarm();
            }
            
        }
        else
        {
            showText();
        }
        yield return new WaitForSeconds(5);
    }
    public Text Information;
    public Animator amin;


    public void StartAnimation(string value)
    {
        StartCoroutine(checkInternetConnectionAnimation(value));
        }
    IEnumerator checkInternetConnectionAnimation(string value)
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
           
        }
        else {
            if (value == "Get 3 keys")
            {
                if (GoogleMobileAdsScript.Instance.ADS_Video_GetIsloaded())
                {
                    StartCoroutine(StartAnimationdelay(value));
                }
            }
            else
            {
                if (GoogleMobileAdsScript.Instance.ADS_Video_GetIsloaded())
                {
                    StartCoroutine(StartAnimationdelay(value));
                }
            }
        }
    }
    public GameObject shopearm;
    bool alow = true;
    public IEnumerator StartAnimationdelay(string value)
    {
       
        if (alow)
        {
            alow = false;
            amin.enabled = true;
            amin.Play("open");
            Showbtn();
            Information.text =  value;
            yield return new WaitForSeconds(0.5f);
            amin.enabled = true;
            yield return new WaitForSeconds(1.5f);
            amin.SetBool("open", true);
            yield return new WaitForSeconds(1.5f);
            amin.SetBool("open", false);
            amin.enabled = false;
            amin.enabled = false;
            if (Playermuving.player.transform.position.z<-5)
            {
                if (shopearm.active == true)
                {
                    UImanager.uimanager.onpenshopEarm();
                }
              
            }
            else
            {
                showText();
            }
            alow = true;
        }
    }

    public void StartAddcoinToLogFacebook(string value)
    {
        StartCoroutine(StartAnimationdelay(value));
    }
    public List<GameObject> lisapp = new List<GameObject>();
    public GameObject Lisapp;
    public void GetLisGame()
    { 
      
#if UNITY_EDITOR
        foreach (GameObject item in lisapp)
        {
            if (item.gameObject.tag == "appios")
            {
              
                item.SetActive(false);
             
            }
        }
#elif UNITY_ANDROID
            foreach (GameObject item in lisapp)
        {
            if (item.gameObject.tag == "appios")
            {
                item.SetActive(false);
            }
        }
#elif UNITY_5 || UNITY_IOS || UNITY_IPHONE
          foreach (GameObject item in lisapp)
        {
            if (item.gameObject.tag == "appadr")
            {
                item.SetActive(false);
            }
        }
#else
           
#endif

    }
    public Text GetEarm;
  public  void Showbtn()
    {
        if (fb.checkloging !=null)
        {
            if (fb.checkloging.WhatIsLoggerIn())
            {
                GetEarm.text = "You Got";
            }
            else
            {
                GetEarm.text = "Log to get coin";
            }
        }
      
    }
    public GameObject showinfor;
    public IEnumerator delayforcoloe()
    {
        showinfor.SetActive(true);
        yield return new WaitForSeconds(2);
        showinfor.SetActive(false);
    }

    public void Showtxt(bool  alow)
    {
        if (alow)
        {
            GetEarm.text = "You Got";
        }
        else
        {
            GetEarm.text = "Log to get coin";
        }
    }

    public Text textkey,texcoin;
    public void showText()
    {
        if (Playermuving.player !=  null)
        {
            if (Playermuving.player.transform.position.z >-4)
            {
                textkey.text = managerdata.manager.getkey().ToString();
                texcoin.text = managerdata.manager.Getcoin().ToString();
            }
        }
       
    }
    void OnDisable()
    {
        alow = true;
        if (amin != null)
        {
            amin.enabled = false;
        }
      
        if (showbtnss!= null)

        showbtnss.transform.position = new Vector3(showbtnss.transform.position.x, Screen.height + Screen.height/10, showbtnss.transform.position.z);
        if (aminnotinternet != null)
        {
            aminnotinternet.enabled = false;
        }
        if (showbtnssnotinternet != null)
        {
            showbtnssnotinternet.transform.position = new Vector3(showbtnss.transform.position.x, Screen.height + Screen.height / 10, showbtnss.transform.position.z);
        }
}
}
