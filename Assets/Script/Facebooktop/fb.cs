using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using System;

public class fb : MonoBehaviour
{
    public static fb checkloging;
    public Image imglog;
    public Text whattex;
    public GameObject paneloffline;
    public GameObject cldt;
    public GameObject PanelOnline;
    public GameObject PanelActip;
    /// <summary>
    /// kiểm tra dăng nhập
    /// </summary>
    public void checkLogin()
    {
        if (isadspanel == true)
        {
            if (PanelActip.active)
            {
                 StartCoroutine(whaitload());
            }
        }
    }
    IEnumerator whaitload()
    {
        yield return new WaitForSeconds(1);
        if (FB.IsLoggedIn)
        {
            showtop = true;
            imglog.gameObject.SetActive(false);
            whattex.text = "";
            cldt.gameObject.SetActive(true);
            Setscore(managerdata.manager.getmuving());
            FB.API("/me", HttpMethod.GET, GetUserInfoCallback);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, GetAvatar);
        }
        else {
            imglog.gameObject.SetActive(true);
            whattex.text = " ";
        }
    }
    
    void Awake()
    {
        if (PlayerPrefs.HasKey("alowgetcoin")== false)
        {
            PlayerPrefs.SetInt("alowgetcoin",0);
            PlayerPrefs.Save();
        }
        //if (!FB.IsInitialized)
        //{
        //    FB.Init(InitCallback, OnHideUnity);
        //}
        //else {
        //    FB.ActivateApp();
        //}
    }

    void OnEnable()
    {
        //if (!FB.IsInitialized)
        //{
        //    FB.Init(InitCallback, OnHideUnity);
        //}
        //else {
        //    FB.ActivateApp();
        //}
    }
    private void InitCallback()
    {
        if (FB.IsLoggedIn)
        {
            print("login okkkkkkkkkkkkkk");
            var perms = new List<string>();
            //perms.Add("email,public_profile,publish_actions,user_games_activity,user_friends");
            perms.Add("email,public_profile");
            FB.LogInWithReadPermissions(perms, AuthCallback);
            // Continue with Facebook SDK
            // ...
        }
        else {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            // Time.timeScale = 0;
        }
        else {
            // Resume the game - we're getting focus again
            // Time.timeScale = 1;
        }
    }


    public void longin()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallback, OnHideUnity);
        }
        else {
            FB.ActivateApp();
        }
        //// cldt.gameObject.SetActive(true);
        //if (!FB.IsInitialized)
        //{
        //    // Initialize the Facebook SDK
        //    FB.Init(InitCallback, OnHideUnity);
        //}
        //else {
        //    // Already initialized, signal an app activation App Event
        //    FB.ActivateApp();
        //}
        StartCoroutine(checkInternetConnection());


    }
    bool checkinternet = true;
    public Animator amin;
    IEnumerator checkInternetConnection( )
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {

            amin.Play("open");
            yield return new WaitForSeconds(0.5f);
            amin.enabled = true;
            yield return new WaitForSeconds(1.5f);
            amin.SetBool("open", true);
            yield return new WaitForSeconds(1.5f);
            amin.SetBool("open", false);
            amin.enabled = false;
            amin.enabled = false;
        }
        else {

            PanelOnline.gameObject.GetComponent<Image>().enabled = true;
            cldt.gameObject.GetComponent<Image>().enabled = true;
            if (FB.IsLoggedIn == false)
            {
                FB.Init(InitCallback, OnHideUnity);
                // ...
            }
            var perms = new List<string>();
            
           // perms.Add("email,public_profile");
            perms.Add("email,public_profile");
            FB.LogInWithReadPermissions(perms, AuthCallback);
            imglog.gameObject.SetActive(false);
            PanelOnline.gameObject.SetActive(true);

        }
    }
    public GameObject showbtnss;
    void OnDisable()
    {
        if (amin != null)
        {
            amin.enabled = false;

        }
        if (showbtnss != null)
            showbtnss.transform.position = new Vector3(showbtnss.transform.position.x, Screen.height + Screen.height / 10, showbtnss.transform.position.z);
    }
    /// <summary>
    ///  chia sẻ loại 1
    /// </summary>
    public void share()
    {
        FB.ShareLink(
       new Uri("https://developers.facebook.com/"),
       callback: ShareCallback
);


    }
    Uri a = new Uri("https://pixabay.com/static/uploads/photo/2013/07/12/17/41/button-152243_960_720.png");
    Uri b = new Uri("https://developers.facebook.com/");
    /// <summary>
    /// share kiểu 2 đầy đủ hơn
    /// </summary>
    public void Share()
    {
        FB.FeedShare(

            linkName: "Loạn 12 Con giáp",
            linkCaption: "I thought up a witty tagline about larches",
            linkDescription: "There are a lot of larch trees around here, aren't there?",
            picture: a,
            link: b,
              callback: FeedCallback
            );
    }

    private void FeedCallback(IShareResult result)
    {
        throw new NotImplementedException();
    }

    public void moichoi()
    {
        FB.AppRequest(
            message: "fgfgf ",
            title: "titalll "
            );
    }

    public void iven()
    {
        FB.Mobile.AppInvite(
         new Uri("https://fb.me/810530068992919"),
         new Uri("http://i.imgur.com/zkYlB.jpg"),
          AppInviteCallback
       );
    }

    private void AppInviteCallback(IAppInviteResult result)
    {
        throw new NotImplementedException();
    }

    private void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !String.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error: " + result.Error);
        }
        else if (!String.IsNullOrEmpty(result.PostId))
        {
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        }
        else {
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
        }
    }
    /// <summary>
    /// khai báo lấy thông tin nguwoif chơi
    /// </summary>
    /// <param name="result"></param>
    private void AuthCallback(ILoginResult result)
    {
        if (result.Error != null)
        {
            print(result.Error);
            return;
        }
        FB.API("/me", HttpMethod.GET, GetUserInfoCallback);
        FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, GetAvatar);
      

        // For testing purposes, also write to a file in the project folder
        // File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
    }

    /// <summary>
    /// lấy ảnh người chơi
    /// </summary>
    /// <param name="result"></param>
    private void GetAvatar(IGraphResult result)
    {
        if (result.Error != null)
        {
            print(result.Error);
            return;
        }
        picture.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2(0.5f, 0.5f));
        pictureshow.sprite = picture.sprite;
        //UImanager.LogInFb = true;
        //UImanager.uimanager.SetImgAvatarFB(pictureshow);
    }
    public List<Image> lisimageavatar = new List<Image>();
    public Text name;
    public Image picture;
    public Image pictureshow;
    /// <summary>
    /// lấy tên người chơi
    /// </summary>
    /// <param name="result"></param>
    private void GetUserInfoCallback(IGraphResult result)
    {
        if (result.Error != null)
        {
            print(result.Error);
            return;
        }

        name.text = string.Format("{0}", result.ResultDictionary["name"]);
        print(result);
        if (isadspanel == false)
        {
            checkLogin();
        }

    }


    // Use this for initialization
    void Start()
    {
        checkloging = this;
    }

    public List<object> socorelist = null;

    public GameObject scolepanen;
    public GameObject scolepanenlis;


    /// <summary>
    /// truy vaans troongs tin coin vaf xeeps hang coin
    /// </summary>
    public void Getcoinallfrend()
    {
        FB.API("/app/scores?fields=score,user.Limit(30)", HttpMethod.GET, Scorecallback);

    }
    List<GameObject> liscoinfrend;
    List<GameObject> lisfrend = new List<GameObject>();
    /// <summary>
    /// /load list bạn bè
    /// </summary>
    /// <param name="result"></param>
    private void Scorecallback(IGraphResult result)
    {
        countlis = 0;
        string sc = result.RawResult;
        socorelist = Util.DeserializeScores(sc);
        // xóa hết đi
        foreach (Transform child in scolepanenlis.transform)
        {
            if (child.gameObject.tag != "earm"&& child.gameObject.tag != "appadr"&& child.gameObject.tag != "appios")
            {
                GameObject.Destroy(child.gameObject);
            }
          
        }
        while (lisimageavatar.Count != 0)
        {
            lisimageavatar.Remove(lisimageavatar[0]);
        }
        while (lisTip.Count != 0)
        {
            lisTip.Remove(lisTip[0]);
        }
  
        int xstt = 1;
        //vứt vào list
        // string namespaces = name.text.ToString();
        foreach (object score in socorelist)
        {
            var entry = (Dictionary<string, object>)score;
            var user = (Dictionary<string, object>)entry["user"];
            GameObject ScorePanel;
            ScorePanel = Instantiate(scolepanen) as GameObject;
            ScorePanel.gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
           // ScorePanel.transform.parent = scolepanenlis.transform;
            Transform names = ScorePanel.transform.Find("name");
            Transform scorescore = ScorePanel.transform.Find("coin");
            Transform stt = ScorePanel.transform.Find("stt");
            Text stxt = stt.GetComponent<Text>();  // số thứ tự
            Text nametext = names.GetComponent<Text>(); // tên 
            Text cointext = scorescore.GetComponent<Text>(); // điểm
            stxt.text = xstt.ToString();
            nametext.text = user["name"].ToString();
            string[] arrListStr = nametext.text.Split(' ');
            string[] st = nametext.text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            //nametext.text = st[0];
            //cointext.text = entry["score"].ToString(); // khi dăng ký được sửa chỗ này lại  k nhớ
            cointext.text = managerdata.manager.getmuving().ToString();
            Transform TheUserAvatar = ScorePanel.transform.Find("Avatar");
            Image UserAvatar = TheUserAvatar.GetComponent<Image>();
            FB.API(Util.GetPictureURL(user["id"].ToString(), 128, 128), HttpMethod.GET, delegate (IGraphResult pictureResult)
            {
                if (pictureResult.Error != null) // lõi thì
                {
                    Debug.Log(pictureResult.Error);
                }
                else // lấy ảnh
                {
                    UserAvatar.sprite = Sprite.Create(pictureResult.Texture, new Rect(0, 0, 128, 128), new Vector2(0, 0));
                }

            });
            string[] st1 = name.text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            // tô màu xanh đậm cho chính mình
            if (st[0] == st1[0])
            {
                Color cl = new Color();
                cl.r = 0.3f;
                cl.g = 1;
                cl.b = 0;
                cl.a = 1;
                ScorePanel.GetComponent<Image>().color = cl;
                countlis = xstt;
            }
            xstt++;

            lisimageavatar.Add(UserAvatar);

        }
        foreach (Transform item in scolepanenlis.transform)
        {
            lisTip.Add(item.gameObject);
        }
        Debug.Log("số lượng cuối" + lisimageavatar.Count);
        GetavataShowTopTip(1);
    }

    int countlis; // thứ tự hiện tại
    int coin;
    static int coinbet;
    public static int STT = 0;
    GameObject GetCoin;
    GameObject GetStt;
    public static bool showtop = false;
    public List<GameObject> lisTip = new List<GameObject>();
    /// <summary>
    /// lấy avatar của người điểm cao tiếp theo
    /// </summary>
    public void GetavataShowTopTip(int location)
    {
        if (countlis - location < 0)
        {
            if (socorelist.Count < 2 && socorelist != null)
            {
                //foreach (GameObject item in socorelist)
                //{
                //    item.GetComponent<Text>().text = managerdata.manager.getmuving().ToString(); 
                //}

                pictureshow.sprite = picture.sprite;
            }
            return;
        }
       // GetCoin = lisTip[countlis - location].gameObject.transform.FindChild("coin").gameObject; // lấy đối tượng coin
                                                                                                 //  GetStt = lisTip[countlis- location].gameObject.transform.FindChild("stt").gameObject; // lấy đối tượng số thứ tự
        //coinbet = int.Parse(GetCoin.GetComponent<Text>().text); // lấy điểm coin 
                                                                // Debug.Log("điểm cao tiếp theo "+ coinbet);
        pictureshow.sprite = lisimageavatar[countlis - location].sprite;
        STT = coinbet;

        if (socorelist.Count < 2 && socorelist != null)
        {
            //foreach (GameObject item in socorelist)
            //{
            //    item.GetComponent<Text>().text = managerdata.manager.getmuving().ToString();
            //}
            pictureshow.sprite = picture.sprite;
        }
        // STT = int.Parse(GetStt.GetComponent<Text>().text); // lấy số thư tự
    }

    /// <summary>
    /// lưu điểm vào dữ liệu
    /// </summary>
    /// <param name="value"></param>
    public void Setscore(int value)
    {
        var scoreData = new Dictionary<string, string>();
        scoreData["score"] = value.ToString();
        FB.API("/me/scores", HttpMethod.POST, delegate (IGraphResult result)
        {
            Debug.Log("cái j " + result.RawResult);
        }, scoreData);
        Getcoinallfrend();  

    }

    bool isadspanel = true;

    public void GetCoinInADS_Logto_Facebook(string value)
    {
        StartCoroutine(checkInternetlogfb(value));
    }
    IEnumerator checkInternetlogfb(string value)
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            amin.Play("open");
            yield return new WaitForSeconds(0.5f);
            amin.enabled = true;
            yield return new WaitForSeconds(1.5f);
            amin.SetBool("open", true);
            yield return new WaitForSeconds(1.5f);
            amin.SetBool("open", false);
            amin.enabled = false;
            amin.enabled = false;
        }
        else {

            if (PlayerPrefs.GetInt("alowgetcoin") != 1)
            {
                isadspanel = false;


                if (FB.IsLoggedIn)
                {
                    managerdata.manager.savecoin(300);
                    PlayerPrefs.Save();
                    BuyADS.Instance.StartAddcoinToLogFacebook(value);
                    StartCoroutine(delayfixf());
                    PlayerPrefs.SetInt("alowgetcoin", 1);
                }
                else {
                    if (FB.IsLoggedIn == false)
                    {
                        FB.Init(InitCallback, OnHideUnity);
                    }
                    var perms = new List<string>();
                    perms.Add("email,public_profile");
                    FB.LogInWithReadPermissions(perms, AuthCallback);
                }
            }




        }
    }
    IEnumerator  delayfixf()
    {
        Debug.Log("sahbdsfbh");
        yield return new WaitForSeconds(1);
             BuyADS.Instance.WhatFBlog();
    }

    IEnumerator delaylogtofacebook(string value)
    {
        yield return new WaitForSeconds(2);
        isadspanel = true;
        yield return new WaitForSeconds(5);
        BuyADS.Instance.StartAddcoinToLogFacebook(value);
        BuyADS.Instance.StartCoroutine(BuyADS.Instance.StartAnimationdelay("Get 300 coins"));
        managerdata.manager.savecoin(300);
        UImanager.uimanager.onpenshopEarm();
    }
    public bool WhatIsLoggerIn()
    {
        return FB.IsLoggedIn;
    }

    public void isloging()
    {
       
    }

  

    public void GetAvatarInpLAY()
    {
        if (FB.IsLoggedIn)
        {
            //var perms = new List<string>();
            //perms.Add("email,public_profile");
            //FB.LogInWithReadPermissions(perms, AuthCallback2);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, GetAvatar2);
        }
    }

    private void AuthCallback2(ILoginResult result)
    {
        if (result.Error != null)
        {
            print(result.Error);
            return;
        }
        FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, GetAvatar2);
    }

 
    

/// <summary>
/// lấy ảnh người chơi
/// </summary>
/// <param name="result"></param>
private void GetAvatar2(IGraphResult result)
{
    if (result.Error != null)
    {
        print(result.Error);
        return;
    }
        imgshowmain.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2(0.5f, 0.5f));
}
    public Image imgshowmain;
}