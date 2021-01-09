using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// class quản lý taonf bộ hệ thống menu Ui vật phẩm và dữ liệu
/// </summary>
public class UImanager : MonoBehaviour {
    
    public GameObject showPlayeronlost;
   // public GameObject Evensystem;
    public Text cointxt;
    public Button btnplay;
    // các panel trong ui thua
    public Text yourcoinmuving; // điểm đường đi kỷ lục của bạn
    public Text yourcoinmuvingnow; // điểm hiện tại của bạn
    public Text yourcoin; // tổng coin của bạn
    public Text yourcoinnow; // coin lần chơi hiện tại
    public Text yourkeytxt; // chìa khóa
    public Button showbotton; // nut choi lai
    // diem cao max oi
    public Text newsoccoretxt; // hiển thị điểm cao mới
    // hien key
    public Text yourkey;  //so key dang co
    public Text yourkeyneed;  //số key cần cho lần hồi sinh này
    int needkey = 0; // số key cần cho lần hồi sinh này
    bool Closebox = true;
    public GameObject showieffcts;
    public Text coinmain;
    bool alowopen = true;
    float Slidertimerdowload;  //  gias gtrij cuar timer
    public static int coinmuving;
    public static int coin;
    public  Animator amin;
    public GameObject camerafolow;
    public static UImanager uimanager;


    // các bảng chọn hiển thị
    public GameObject paneloading ;
    public GameObject panellost; 
    public GameObject panelseleckey; 
    public GameObject panelcoin;
    public GameObject newcoinmaxmung;
    public GameObject panelshowitem;
    public GameObject panel_Earm_Coin;
    public GameObject panel_main_shop;
    // các thanh timer
    public Slider timerforkey; 
    public Slider Ontheloading; 
    public Slider timer;
    public Slider timeriteam; 
    public Slider timeriteamhut; 
    public Slider timeriteamx2; 
    public Slider timeriteamgiay; 
    public Slider timeriteambay;  


    // thanh chứa slider
    public GameObject panelslidervan;
    public GameObject panelsliderhut;
    public GameObject panelsliderx2;
    public GameObject panelslidergiay;
    public GameObject panelsliderbay;
    // public GameObject btnitemfly;
    private int checkthedie;


    public static bool selectkey;
    public Text showhighscoreinpanellost;

    public Text ShowHighscor3D;
    // Use this for initialization
    public int frameRate = 60;
    void Awake()
    {
        //yourcoinnow.transform.SetSiblingIndex(1);
        Application.targetFrameRate = frameRate;
    }
    void Start () {
        
        ShowHighscor3D.text = managerdata.manager.getmuving().ToString();
        if (managerdata.manager.getmuving() == 0)
        {
            ShowHighscor3D.text = "High score";
        }
        SetingInStart();
        if (LogInFb)
        {
            SetImageAvatarFAb();
        }
        getvan = true;
        Closebox = true;
      //  PlayerPrefs.DeleteAll();


    }
    public void SetingInStart()
    {
        yourkey.text = managerdata.manager.getkey().ToString();
        coin = 0;
        coinmuving = 0;
        amin = camerafolow.gameObject.GetComponent<Animator>();
        uimanager = this;
        // tắt các timer item
        panellost.gameObject.SetActive(false);
        panelseleckey.gameObject.SetActive(false);
        timeriteam.gameObject.SetActive(false);
        timeriteamhut.gameObject.SetActive(false);
        timeriteamx2.gameObject.SetActive(false);
        timeriteamgiay.gameObject.SetActive(false);
        timeriteambay.gameObject.SetActive(false);
        panelcoin.SetActive(false);
        paneloading.gameObject.SetActive(true);
        StartCoroutine(Loadingonthestart());
        alowcall = true;
        selectkey = false;
        showthenewsocore = false;
        newcoinmaxmung.gameObject.SetActive(false);
        panelbox.gameObject.SetActive(false);
        calll = true;
        btnplay.gameObject.SetActive(true);
        CloseShop();
        buyitemboxintheshop = false;
        showitembuyflylong();

        btnitemfly.gameObject.SetActive(false);
    }
    public void Again()
    {
        yourkey.text = managerdata.manager.getkey().ToString();
        coin = 0;
        coinmuving = 0;
        amin = camerafolow.gameObject.GetComponent<Animator>();
        uimanager = this;
        // tắt các timer item
        panellost.gameObject.SetActive(false);
        panelseleckey.gameObject.SetActive(false);
        timeriteam.gameObject.SetActive(false);
        timeriteamhut.gameObject.SetActive(false);
        timeriteamx2.gameObject.SetActive(false);
        timeriteamgiay.gameObject.SetActive(false);
        timeriteambay.gameObject.SetActive(false);
        panelcoin.SetActive(false);
        paneloading.gameObject.SetActive(false);
        panelmain.SetActive(true);
        alowcall = true;
        selectkey = false;
        showthenewsocore = false;
        newcoinmaxmung.gameObject.SetActive(false);
        calll = true;
        btnplay.gameObject.SetActive(true);
        CloseShop();
        buyitemboxintheshop = false;
        showitembuyflylong();
        btnitemfly.gameObject.SetActive(false);
    }
    /// <summary>
    /// chơi lại
    /// </summary>
    public  void playAgain()
    {
        if (calll)
        {
            BtnPause.gameObject.SetActive(true);

            //  Evensystem.SetActive(false);
            Playermuving.player.GetComponent<CapsuleCollider>().center = new Vector3(0, -0.08f, 0);
            Playermuving.player.GetComponent<CapsuleCollider>().radius = 0.46f;
            Playermuving.player.GetComponent<CapsuleCollider>().height = 1.77f;
            showPlayeronlost.SetActive(false);
            Time.timeScale = 0.8F;
            Playermuving.speedmuving = 15;
            inthepanelpause.playagain = true;
            GoogleMobileAdsScript.Instance.showbaner();
            Playagainshowhide.gameObject.SetActive(false);
            calll = false;
            coin = 0;
            coinmuving = 0;
            panellost.gameObject.SetActive(false);
            panelseleckey.gameObject.SetActive(false);
            timeriteam.gameObject.SetActive(false);
            paneloading.gameObject.SetActive(false);
            Perencamera.managerscen.playallgame();
           // Camerafolow.camfolowplayer.Intanceectff(); // tạo hiệu ứng
            StartCoroutine(playagain());
            showitembuyflylong();
            emty.emtyplayer.ResutTranformemty();
            
        }

    }
    public Button Playagainshowhide;
    bool calll;
    /// <summary>
    /// sửa lỗi animation không chạy
    /// </summary>
    /// <returns></returns>
    IEnumerator  playagain()
    {
        Playermuving.isplay = true;
        yield return new WaitForSeconds(0.5f);
        calll = true;
        Playermuving.player.clicontheplayagainseleckey();
        showitembuyflylong();
        OnOpenFlyAgain();
        for (int j = 0; j < 4; j++)
        {
            yield return new WaitForSeconds(0.5f);
            Playermuving.player.clicontheplayagainseleckey(); // lod lại animation
        }
        Playagainshowhide.gameObject.SetActive(true);
        StartCoroutine(timerforshowbtnitem()); // trễ  5s để tắt nút bay

    }

    /// <summary>
    /// tải map
    /// </summary>
    /// <returns></returns>
    IEnumerator Loadingonthestart()
    {
        paneloading.gameObject.SetActive(true);
        awakemainmenu();
        panelmain.SetActive(false);
         for (int i = 0; i <100; i++)
        {
            yield return new WaitForSeconds(0.05f);
            Ontheloading.value = i;
            if (i== 99)
            {
                paneloading.gameObject.SetActive(false);
                Perencamera.managerscen.GetComponent<Animator>().enabled = true;
                Soundmanager.soundmanager.PlayBackgroudSound();
                awakemainmenu();
               
            }
        }
    }

    /// <summary>
    /// timer test
    /// </summary>
	public void Ontherchangetimer()
    {
        Slidertimerdowload = timer.value;
        Slidertimerdowload = Slidertimerdowload / 100;
        Time.timeScale = Slidertimerdowload;

    }
    public GameObject UIHowToPlay;

    /// <summary>
    /// vào chơi
    /// </summary>
    public void play()
    {
        panelcoin.SetActive(true);
        panelmain.SetActive(false);
        StartCoroutine(Playdelay());
        Soundmanager.soundmanager.PlayPoliceSound();
        // Evensystem.SetActive(false);
    }
    
    IEnumerator Playdelay()
    {
        mapitro.instance.Muvingship();
        emty.emtyplayer.StartCoroutine(emty.emtyplayer.intheplay());
        yield return new WaitForSeconds(0.3f);
       // Debug.Log("chơi lại");
        Perencamera.managerscen.GetComponent<Animator>().SetBool("play",true);
        folow.distance = 10;
        yield return new WaitForSeconds(0.5f);
        Playermuving.isplay = true;
        Playermuving.speedmuving = 5;
        GoogleMobileAdsScript.Instance.showbaner();
        if (PlayerPrefs.HasKey("hd") == false)
        {
            UIHowToPlay.SetActive(true);
        }
        btnitemfly.gameObject.GetComponent<Image>().enabled = false;
        btnitemfly.gameObject.GetComponent<Button>().enabled = false;
        Playermuving.player.muvingtomodelonthestart(); // chạy model về phía tâm tọa độ
        showitembuyflylong();
        amin.SetBool("play", true);
        amin.SetBool("again", false);
        btnplay.gameObject.SetActive(false);
        emty.emtyplayer.actac();
        emty.emtyplayer.animationrunplay();
        emty.die = 1;
        btnplay.gameObject.SetActive(false);
        if (managerdata.manager.GetFly() >= 1)
        {
            yield return new WaitForSeconds(2f);
            btnitemfly.gameObject.GetComponent<Image>().enabled = true;
            btnitemfly.gameObject.GetComponent<Button>().enabled = true;
            btnitemfly.gameObject.SetActive(true);
            CountItemFly.text = managerdata.manager.GetFly().ToString();
            StartCoroutine(timerforshowbtnitem());
        }
      
    }


    #region hệ thống các thanh slider


    /// <summary>
    /// timer cho item ván tươysl
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerator delayslideritem(int value,string nameitem)
    {


        if (Manageritem.van == false)
        {
            Manageritem.van = true;
            timeriteam.gameObject.SetActive(true);
            panelslidervan.SetActive(true);
            timeriteam.maxValue = 300;
            int vl = 0;
            timeriteam.value = vl;
            for (int i = 0; i < 300; i++)
            {
                timeriteam.gameObject.GetComponent<Slider>().enabled = true;
                timeriteam.gameObject.SetActive(true);
                panelslidervan.SetActive(true);
                vl++;
                timeriteam.value = vl;
                yield return new WaitForSeconds(0.1f);
                if (Manageritem.van == false|| Manageritem.baylongcoin == true)
                {
                    timeriteam.gameObject.SetActive(false);
                    panelslidervan.SetActive(false);
                    if (alowdelay)
                    {
                        Playermuving.player.stopanimationitem("van", "van");
                    }
                   
                    break;
                }
            }
            panelslidervan.SetActive(false);
            timeriteam.gameObject.SetActive(false);
            if (alowdelay)
            {
                Playermuving.player.stopanimationitem("van", "van");
            }
        }
        else
        {
           
            alowdelay = false;
            Manageritem.van = false;
            yield return new WaitForSeconds(0.2f);
            alowdelay = true;

             StartCoroutine(delayslideritem(1,""));
            Playermuving.player.setalowvan();
        }

    }
    bool alowdelay = true;
    int Getvalueslider(int value)
    {
        int valueoffitem = 10;
        valueoffitem = valueoffitem + value * 3;
        valueoffitem = valueoffitem * 10;
        return valueoffitem;

    }
    int valuex2;

    /// <summary>
    /// timer cho item hút coin hút coin về phía player 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerator delayslideritemhut(int value)
    {
        Debug.Log(timeriteamhut.maxValue);
        if (Manageritem.hutcoin== false)
        {
            Manageritem.hutcoin = true;
            timeriteamhut.gameObject.SetActive(true);
            panelsliderhut.gameObject.SetActive(true);
            timeriteamhut.maxValue = Getvalueslider(managerdata.manager.GetDataItemMagnet());
            timeriteamhut.value = 0;
            timeriteamhut.gameObject.GetComponent<Slider>().enabled = true;
            valuex2 = 0;
            for (int i = 0; i < timeriteamhut.maxValue; i++)
            {
                valuex2++;
                timeriteamhut.value = valuex2;
                yield return new WaitForSeconds(0.1f);
                if (Manageritem.hutcoin == false)
                {
                    panelsliderhut.gameObject.SetActive(false);
                    timeriteamhut.gameObject.SetActive(false);
                    break;
                }
            }
            timeriteamhut.gameObject.SetActive(false);
            panelsliderhut.gameObject.SetActive(false);
            Playermuving.player.stopanimationitem("hutcoin", "hutcoin");
        }
        else
        {
            Manageritem.hutcoin = false;
            yield return new WaitForSeconds(0.2f);
            Playermuving.player.GetIkmagnet();
            StartCoroutine(delayslideritemhut(1));
        }
    }
    
    /// <summary>
    /// timer cho item x2 coin
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerator delayslideritemx2(int value)
    {
        if (Manageritem.x2coin == false)
        {


            Manageritem.x2coin = true;
            timeriteamx2.gameObject.SetActive(true);
            panelsliderx2.gameObject.SetActive(true);
            //timeriteamx2.maxValue = value * 5;
            timeriteamx2.maxValue = Getvalueslider(managerdata.manager.GetDataItemX2());
            timeriteamx2.value = 0;
            int vl = 0;
            timeriteamx2.value = vl;
            for (int i = 0; i < timeriteamx2.maxValue; i++)
            {
                timeriteamx2.gameObject.GetComponent<Slider>().enabled = true;

                vl++;
                timeriteamx2.value = vl;
                if (Manageritem.x2coin == false)
                {
                    panelsliderx2.gameObject.SetActive(false);
                    break;
                }
                yield return new WaitForSeconds(0.1f);
            }
            panelsliderx2.gameObject.SetActive(false);
            timeriteamx2.gameObject.SetActive(false);
            Playermuving.player.stopanimationitem("x2coin", "x2coin");
        }
        else if (Manageritem.x2coin)
        {
            Manageritem.x2coin = false;
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(delayslideritemx2(1));

        }


    }

    /// <summary>
    /// timer cho item giày
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerator delayslideritemgiay(int value)
    {
        if (Manageritem.giay== false)
        {
            Manageritem.giay = true;
            timeriteamgiay.gameObject.SetActive(true);
            panelslidergiay.gameObject.SetActive(true);
            timeriteamgiay.maxValue = Getvalueslider(managerdata.manager.GetDataItemGiay());
            timeriteamgiay.value = 0;
            // timeriteamgiay.maxValue = value * 10;
            int vl = 0;
            timeriteamgiay.value = vl;
            for (int i = 0; i < timeriteamgiay.maxValue; i++)
            {
                timeriteamgiay.gameObject.GetComponent<Slider>().enabled = true;
                vl++;
                timeriteamgiay.value = vl;
                yield return new WaitForSeconds(0.1f);
                if ( Manageritem.giay == false)
                {
                    panelslidergiay.gameObject.SetActive(false);
                    timeriteamgiay.gameObject.SetActive(false);
                    Playermuving.player.stopanimationitem("giay", "giay");
                    break;
                }
            }
            panelslidergiay.gameObject.SetActive(false);
            timeriteamgiay.gameObject.SetActive(false);
            Playermuving.player.stopanimationitem("giay", "giay");
        }
        else if (Manageritem.giay)
        {
            Manageritem.giay = false;
            yield return new WaitForSeconds(0.2f);
            Playermuving.player.GetGiay();
            StartCoroutine(delayslideritemgiay(1));

        }

    }


    /// <summary>
    /// timer cho item bay đọa dài
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerator delayslideritembay(int value)
    {
         
        Perencamera.managerscen.GetItemFly();
        timeriteambay.gameObject.SetActive(true);
        panelsliderbay.gameObject.SetActive(true);
        timeriteambay.maxValue = 100+ managerdata.manager.GetDataItemFly()*30;
        timeriteam.gameObject.SetActive(false);
        panelslidervan.SetActive(false);
        int vl = 0;
        timeriteambay.value = vl;
        for (int i = 0; i < timeriteambay.maxValue; i++)
        {
            if (inthepanelpause.fixFlylong)
            {
                yield return new WaitForSeconds(3);
                inthepanelpause.fixFlylong = false;
            }
            timeriteambay.gameObject.GetComponent<Slider>().enabled = true;
            vl++;
            timeriteambay.value = vl;
            yield return new WaitForSeconds(0.1f);
            if (Manageritem.baylongcoin == false)
            {
                panelsliderbay.gameObject.SetActive(false);
                timeriteambay.gameObject.SetActive(false);
                break;
            }
        }
        if (Manageritem.baylongcoin)
        {
            yield return new WaitForSeconds(3f);
              Playermuving.player.StartCoroutine(Playermuving.player.exitdelaydestroiitemlong());
        }
        timeriteambay.gameObject.SetActive(false);

    }

    #endregion
    bool alowcall;
    private bool showthenewsocore; // biến hiện  menu điểm cao mới

    /// <summary>
    ///  thua
    /// </summary>
    public void Lost()
    {
      
        if (coinmuving > managerdata.manager.getmuving())
        {
            newsoccoretxt.text = coinmuving.ToString();
            showthenewsocore = true;
        }
        if (PlayerPrefs.HasKey("hd") == false)
        {
            PlayerPrefs.SetInt("hd", 1);
            Makesupway.isnewgame = false;
        }

        PlayerPrefs.Save();
        managerdata.manager.savemuving(coinmuving);
        managerdata.manager.savecoin(coin);
        showhighscoreinpanellost.text = managerdata.manager.getmuving().ToString();
        if (alowcall)
        {
            alowcall = false;
            checkthedie++;
            yourkey.text = managerdata.manager.getkey().ToString();
            yourkeyneed.text = needkey.ToString();
            StartCoroutine(delayforAgain());
        }
    }
        int showbane = 0;
    public static bool getvan;
    IEnumerator Delayvankey()
    {
        getvan = false;
        yield return new WaitForSeconds(3);
        getvan = true;

    }

    public GameObject BtnPause;
    /// <summary>
    ///     
    /// </summary>
    /// <returns></returns>
    public IEnumerator delayforAgain()
    {
        yield return new WaitForSeconds(0.25f);
        panelseleckey.gameObject.SetActive(true);
        showbane++;
        Manageritem.mngitem.DeleteAllItemWendie();
        if (checkthedie > 2)
        {
            needkey = (int)(Mathf.Pow(2, checkthedie));
        }
        else if (checkthedie == 1)
        {
            needkey = 1;
        }
        else if (checkthedie == 2)
        {
            needkey = 2;
        }
        yourkeyneed.text = needkey.ToString();
        selectkey = false;
        Playermuving.player.Enterdieinfart();
        btnitemfly.gameObject.SetActive(false);
        panellost.gameObject.SetActive(false);
        DeleteAllSlider();
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.001f);
            if (selectkey == true)
            {
                if (managerdata.manager.getkey() >= needkey)
                {
                    Soundmanager.soundmanager.PlayAgain();
                    if (getvan)
                    {
                        StartCoroutine(Delayvankey());
                    }
                    alowcall = true;
                    Playermuving.player.StartCoroutine(Playermuving.player.EffectWenHavaeItem());
                    Playermuving.player.OurtCut(); 
                    Makesupway.makemap.StartCoroutine(Makesupway.makemap.MuvingbackAllemtyWenhaveitemVan(false));
                    StartCoroutine(playnowintheseleckey());
                    Camerafolow.camfolowplayer.Intanceectff(); 
                    Playermuving.player.backtodie(); 
                    yourkey.text = managerdata.manager.getkey().ToString();
                    managerdata.manager.savekey(-needkey);
                    emty.emtyplayer.ResutTranformemty();
                    Perencamera.managerscen.height = 3;
                    break;
                }
                else if (managerdata.manager.getkey() < needkey)
                {
                    selectkey = false;
                    showNorinnapkey();
                }
            }
            timerforkey.value -= 1;
            if (i==99)
            {
                goodCPU.intance.GetStartrotay(false);
                Camerafolow.camfolowplayer.gameObject.GetComponent<Camera>().farClipPlane = 3;
                Playermuving.player.OurtCut();
                GoogleMobileAdsScript.Instance.hidebaner();
                inthepanelpause.playagain = true;
                if (showbane >= 2)
                {
                    GoogleMobileAdsScript.Instance.showfullbaner();
                    showbane = 0;
                }
                 if (selectkey == false)
                    {
                    Playermuving.isplay = false;
                    needkey = 0;
                    checkthedie = 0;
                    coinforuplv = 5000;
                    Playermuving.player.StartCoroutine(Playermuving.player.playagain(0));
                    if (Manageritem.box == false)
                    {
                        if (Playermuving.isplay==false)
                        {
                            StartCoroutine(playopenmenumainsocore());
                        }
                    }
                    else if (Manageritem.box)
                    {
                        Time.timeScale = 1;
                        panelbox.SetActive(true);
                        openbox();
                        Manageritem.box = false;
                    }
                }
                if (showthenewsocore==false)
                {
                    panelseleckey.gameObject.SetActive(false);
                    BtnPause.gameObject.SetActive(false);
                }
                else if (Manageritem.box==false)
                {
                   // showPlayeronlost.SetActive(true);
                }
                BtnPause.gameObject.SetActive(false);
            }
        }
        yield return new WaitForSeconds(1);
        if (selectkey == false)
        {
            Perencamera.managerscen.StartCoroutine(Perencamera.managerscen.delayfolowcameradie());
        }
        alowcall = true;
        timerforkey.value = 100;
    }
    // xóa toàn bộ slider item
    void DeleteAllSlider()
    {
        timeriteam.enabled = false;  //
        timeriteamhut.enabled = false;
        timeriteamx2.enabled = false;
        timeriteamgiay.enabled = false;
        timeriteambay.enabled = false;
    }
    // bật tắt menu chọn khóa
    public GameObject notinapkey;
    public void showNorinnapkey()
    {
        notinapkey.SetActive(true);
    }

    public void Hidenotinnapkey()
    {
        notinapkey.SetActive(false);
    }

    public static bool Playnowintheseleckey;
    /// <summary>
    /// play ngay lâp
    /// </summary>
    /// <returns></returns>
   private IEnumerator playnowintheseleckey()
    {
        Playnowintheseleckey = true;
        panelseleckey.gameObject.SetActive(false); // ẩn menu chọn khóa
        Playermuving.player.playnowthehere();
        Playnowintheseleckey = false;
        yield return new WaitForSeconds(0.5f);

    }

    /// <summary>
    /// mở menu mới play
    /// </summary>
    /// <returns></returns>
    private IEnumerator playopenmenumainsocore()
    {
        if (showthenewsocore == false)
        {
            Playermuving.isplay = false;
            panellost.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            yourcoinmuving.text = managerdata.manager.getmuving().ToString(); // đường đi max
            StartCoroutine(delayforcoinmuving(coinmuving, coin));
            yourcoinmuving.text = managerdata.manager.getmuving().ToString();
            yourcoin.text = managerdata.manager.Getcoin().ToString();
            yourkeytxt.text = managerdata.manager.getkey().ToString();
            coinmuving = 0;
            coin = 0;
            if (coinmuving>= managerdata.manager.getmuving())
            {
                managerdata.manager.savemuving(coinmuving);
            }
            add = 1;
            fb.checkloging.checkLogin(); 
        }
        else if (showthenewsocore)
        {
            Playermuving.isplay = false;
            Soundmanager.soundmanager.PlaynewHighscore();
            newcoinmaxmung.gameObject.SetActive(true);
            LoaDingcharacterOnshowNewHideSocore();
            showthenewsocore = false;
        }
        panelseleckey.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        alowcall = true;

        Playagainshowhide.gameObject.SetActive(true);
        notinapkey.SetActive(false);
       
    }
    public void tabtabcontinued()
    {
        StartCoroutine(taptocontinuedinthenewsocore());
    }
    public void GetAllValueToPanelCoinLost()
    {
        yourcoin.text = managerdata.manager.Getcoin().ToString();
        yourkeytxt.text = managerdata.manager.getkey().ToString();
    }
    public Transform Lischaracter;
    List<GameObject> showlisChaRacTer = new List<GameObject>();
    public GameObject opennewHideSocore;
    /// <summary>
    ///  tải character để show lên khi  hiện điểm cao
    /// </summary>
    void LoaDingcharacterOnshowNewHideSocore()
    {
        Playermuving.isplay = false;
        panelcoin.SetActive(false); // tắt các coin
        opennewHideSocore.gameObject.SetActive(true);
        foreach (Transform item in Lischaracter)
        {
            showlisChaRacTer.Add(item.gameObject);
        }
        
        for (int i = 0; i < showlisChaRacTer.Count; i++)
        {
            if (showlisChaRacTer[i].gameObject.name == managerdata.manager.Getnowcharacter())
            {
                showlisChaRacTer[i].SetActive(true);
            }
            else
            {
                showlisChaRacTer[i].SetActive(false);
            }
        }
    }

    public void ShowCharacterLost(bool value)
    {
        if (value)
        {
            showPlayeronlost.SetActive(true);
        }
        else
        {
            showPlayeronlost.SetActive(false);

        }
    }
    /// <summary>
    /// clic vào để hiể thị  lúc đạt điểm cao mới
    /// </summary>
    public IEnumerator taptocontinuedinthenewsocore()
    {
        NewHighscore.newhigh.backtotranform();
        panelcoin.SetActive(true); // tắt các coin
        opennewHideSocore.gameObject.SetActive(false);
        newcoinmaxmung.gameObject.SetActive(false);
        panellost.gameObject.SetActive(true);
       // showPlayeronlost.SetActive(true);
        yield return new WaitForSeconds(1);
        yourcoinmuving.text = managerdata.manager.getmuving().ToString(); // đường đi max
        StartCoroutine(delayforcoinmuving(coinmuving, coin));
        yourcoinmuving.text = managerdata.manager.getmuving().ToString();
        yourcoin.text = managerdata.manager.Getcoin().ToString();
        coinmuving = 0;
        coin = 0;
        panellost.gameObject.SetActive(true); // hiện mà hình thua cuộc
        add = 1;
        if (coinmuving >= managerdata.manager.getmuving())
        {
            managerdata.manager.savemuving(coinmuving);
        }
        fb.checkloging.checkLogin(); // kieemr tra menu facebook
       //;
    }
    /// <summary>
    /// hiệu ứng coin và điểm tăng dần
    /// </summary>
    /// <param name="value">đường đi</param>
    /// <param name="value1"></param>
    /// <returns></returns>
    private IEnumerator delayforcoinmuving( int  value, int value1)
    {
        int valuefodelay = value / 20;
        int valuefodelay1 = value1 / 20;
        int valuefordelaysecon = 0;
        int valuefordelaysecon1 = 0;
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.06f);
            valuefordelaysecon += valuefodelay;
            valuefordelaysecon1 += valuefodelay1;
            yourcoinmuvingnow.text = valuefordelaysecon.ToString();
            yourcoinnow.text = valuefordelaysecon1.ToString();
        }
        yourcoinmuvingnow.text = value.ToString();
        yourcoinnow.text = value1.ToString();
    }

    /// <summary>
    ///  chọn khóa hồi sinh
    /// </summary>
    public void ontheseleckey()
    {
        selectkey = true;
    }


 

    #region quản lý animation
    public GameObject panelbox;
    /// <summary>
    /// hiện box
    /// </summary>
    public void openbox()
    {
        panelbox.SetActive(true);
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<Animator>().SetBool("box",true);
    }
    /// <summary>
    /// mở hộp quà
    /// </summary>
    public void tabtothebox()
    {
        if (alowopen)
        {
            alowopen = false;
            StartCoroutine(DelayforOpen());
            gameObject.GetComponent<Animator>().Play("mian",0);
            gameObject.GetComponent<Animator>().SetBool("open", true);
            randumiteminthebox();
            showieffcts.SetActive(true);
        }
        Closebox = false;
        StartCoroutine(delayOpen());

    }
  
    IEnumerator DelayforOpen()
    {
        yield return new WaitForSeconds(5);
        alowopen = true;
    }
    /// <summary>
    /// đóng hộp quà
    /// </summary>
    public void tabtoclosebox()
    {

        if (Closebox)
        {
            showieffcts.SetActive(false);

            gameObject.GetComponent<Animator>().SetBool("open", false);
            gameObject.GetComponent<Animator>().SetBool("box", false);
            yourrandumitembox.gameObject.SetActive(false);
            showtexbox.gameObject.SetActive(false);
            gameObject.GetComponent<Animator>().enabled = false;
            panelbox.SetActive(false);
            if (buyitemboxintheshop == false)
            {
                StartCoroutine(playopenmenumainsocore());
            }
            else if (buyitemboxintheshop)
            {
                buyitemboxintheshop = false;
            }
        }
    }
    IEnumerator delayOpen()
    {
        yield return new WaitForSeconds(2);
        Closebox = true;
    }
    #endregion




    /// <summary>
    ///  ran dum quà gồm có  các loại item  500 coin , 1000 coin ,3 ván trượt , 1 key hồi sinh
    /// </summary>
    public void randumiteminthebox()
    {
        int ranitem = Random.Range(0,4);
        int coin = 0;
        int itemvan = 0;
        int key = 0;
        switch (ranitem)
        {
            case 0:
                // 500 điểm coin
                coin = 500;
                yourrandumitembox.text = "Get 500 coin";
                managerdata.manager.savecoin(coin);
                break;
            case 1:
                //  1000 điểm coin
                coin = 1000;
                yourrandumitembox.text = "Get 1000 coin";
                managerdata.manager.savecoin(coin);
                break;
            case 2:
                // 3 vanns trượt
                itemvan = 3;
                yourrandumitembox.text = "x3 skateboard";
                managerdata.manager.savevan(itemvan);
                break;
            case 3:
                // 1 chìa khóa
                key = 1;
                yourrandumitembox.text = "x1 Key revival";
                managerdata.manager.savekey(key);
                break;
            default:
                break;
        }
        yourrandumitembox.gameObject.SetActive(true);
        showtexbox.gameObject.SetActive(true);
       // onpenshop();
    }

    public Text yourrandumitembox;

    public Text showtexbox;

    /// <summary>
    ///  về menu chính
    /// </summary>
    public void gotohome()
    {
        GoogleMobileAdsScript.Instance.hidebaner();
        Time.timeScale = 1;
        IkEmty.iklegth1 = 0;
        IkEmty.iklegth = 0;
        IKanimation.iklegth = 0;
        Playermuving.backnowmuvingship = true;
        Application.LoadLevel("mainlv");
    }


    #region  các cài đặt trong main menu





        /*************************

        menu chính

        ***************************/

    void awakemainmenu()
    {
        showbuyvaninthemain.SetActive(false);
        showsetting.SetActive(false);
        panelmain.SetActive(true);
        showvan.text = managerdata.manager.getvan().ToString();
        showvan1.text = managerdata.manager.getvan().ToString();
        showcoin.text = managerdata.manager.Getcoin().ToString();
        showkey.text = managerdata.manager.getkey().ToString();
    }
    public Text showvan, showvan1, showcoin, showkey;
    public GameObject showbuyvaninthemain, showsetting;
    public GameObject panelmain;
    public Image notshowsound;
    public Text showsown;
    /// <summary>
    /// clic vào nút mua ván trượt
    /// </summary>
    public void openbuyvan()
    {
        showbuyvaninthemain.SetActive(true);
    }
   

    /// <summary>
    /// clic vào mua
    /// </summary>
    public void clicthebtnbuyvan()
    {
        if (managerdata.manager.Getcoin() >= 300)
        {
            managerdata.manager.savecoin(-300);
            managerdata.manager.savevan(1);
            showvan.text = managerdata.manager.getvan().ToString();
            showvan1.text = managerdata.manager.getvan().ToString();
            showcoin.text = managerdata.manager.Getcoin().ToString();
            showkey.text = managerdata.manager.getkey().ToString();
        }
    }


    /// <summary>
    /// đóng menu mua ván trượt
    /// </summary>
    public void closebuyvan()
    {
        showbuyvaninthemain.SetActive(false);
    }

    /// <summary>
    /// mở moenu cài đặt
    /// </summary>
    public void cliconthesetting()
    {
        if (managerdata.manager.getsetting() == 0)
        {
            notshowsound.gameObject.SetActive(true);
            showsown.text = "Sound OFF";
            // gọi hàm âm thanh tắt ở đây
        }
        else if (managerdata.manager.getsetting() == 1)
        {
            notshowsound.gameObject.SetActive(false);
            showsown.text = "Sound On";
            // gọi hàm âm thanh bật ở đây

        }

        showsetting.SetActive(true);

    }


    /// <summary>
    /// đóng menu cài đặt
    /// </summary>
    public void closeonthesetting()
    {
        showsetting.SetActive(false);
        if (inthepanelpause.ispause)
        {
            inthepanelpause.pauses.closemenuseting();
        }

    }
    /// <summary>
    /// thay đổi cài ặt âm thanh gọi  hàm bật tắt âm thanh ở đây
    /// </summary>
    public void changesound()
    {


        if (managerdata.manager.getsetting() == 0)
        {
            managerdata.manager.savesetting(1);
        }
        else if (managerdata.manager.getsetting() == 1)
        {
            managerdata.manager.savesetting(0);

        }
        if (managerdata.manager.getsetting() == 0)
        {
            notshowsound.gameObject.SetActive(true);
            showsown.text = "Sound OFF";
            // gọi hàm âm thanh tắt ở đây
        }
        else if (managerdata.manager.getsetting() == 1)
        {
            notshowsound.gameObject.SetActive(false);
            showsown.text = "Sound On";
        }

        Soundmanager.soundmanager.PlayBackgroudSound();
    }

    public void LoadDataSound()
    {
        if (managerdata.manager.getsetting() == 0)
        {
            notshowsound.gameObject.SetActive(true);
            showsown.text = "Sound OFF";
        }
        else if (managerdata.manager.getsetting() == 1)
        {
            notshowsound.gameObject.SetActive(false);
            showsown.text = "Sound On";
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    /**************************

        menu shop

    ***************************/
    public GameObject shoppanel; // panel chứa toàn bộ shop
    public Text txtkeyinshop, txtcoininshop;  // coin và điểm
    public Text counHoverboard;  // số vàn truwoj trong bngr ván trượt
    public Image imgHoverboard; //menu ván trượt
    public Image MysteryBox; //menu hộp quà 
    public Image imgheadstart; //menu  itembay
    bool buyitemboxintheshop; // phân biệt gữa hộp quà mua và hộp quà được tặng
    ILayoutElement layout;
    Animator layoutamin;

    public Button btnitemfly;

    /// <summary>
    /// mở menu shop khi đang ở menu chính
    /// </summary>
    public void onpenshop()
    {
        loaditem();
        shoppanel.SetActive(true);
        panel_Earm_Coin.SetActive(false);
        panel_main_shop.SetActive(true);
        txtkeyinshop.text = managerdata.manager.getkey().ToString();
        txtcoininshop.text = managerdata.manager.Getcoin().ToString();
        counHoverboard.text = "You have "+ managerdata.manager.getvan().ToString();
        showyouhaveHeadstar.text = "You have" + managerdata.manager.GetFly();
    }
    public Text showtextog_facebook;
    /// <summary>
    /// mở menu shop khi đang ở menu chính
    /// </summary>
    public void onpenshopEarm()
    {
        if (PlayerPrefs.GetInt("alowgetcoin") != 1)
        {
            showtextog_facebook.text = "Login to get coins";
        }
          
        else
        {
            showtextog_facebook.text = "You got";
        }
        loaditem();
        shoppanel.SetActive(true);
        panel_Earm_Coin.SetActive(true);
        panel_main_shop.SetActive(false);
        txtkeyinshop.text = managerdata.manager.getkey().ToString();
        txtcoininshop.text = managerdata.manager.Getcoin().ToString();
        counHoverboard.text = "You have " + managerdata.manager.getvan().ToString();
        showyouhaveHeadstar.text = "You have" + managerdata.manager.GetFly();
       

    }


    /// <summary>
    ///  đóng shop
    /// </summary>
    public void CloseShop()
    {
        shoppanel.SetActive(false);
    }
    /// <summary>
    /// mở lớn menu mua ván trượt
    /// </summary>
    public void OpenBigMenuHoverboard()
    {
        setanimation(imgHoverboard);

    }
    /// <summary>
    /// mở lớn menu mua hộp quà
    /// </summary>
    public void OpenBigMenuMysteryBox()
    {
        setanimation(MysteryBox);
    }

    /// <summary>
    /// mở lớn menu mua item bay
    /// </summary>
    public void OpenBigMenuHeadstart()
    {
        setanimation(imgheadstart);
    }

    /// <summary>
    ///  set các animation khi mở
    /// </summary>
    /// <param name="animation"></param>
    private void setanimation(Image animation)
    {
        if (layoutamin != null)
        {
            layoutamin.SetBool("close", true);
            layoutamin.SetBool("open", false);
        }
        layoutamin = animation.GetComponent<Animator>();
        layoutamin.SetBool("open", true);
        layoutamin.SetBool("close", false);
    }

    /// <summary>
    ///  mua  ván trượt trong shop
    /// </summary>
    public void ClicBuyHoverboardInShop()
    {
        if (managerdata.manager.Getcoin() >=300)
        {
            managerdata.manager.savecoin(-300);
            managerdata.manager.savevan(1);
            txtkeyinshop.text = managerdata.manager.getkey().ToString();
            txtcoininshop.text = managerdata.manager.Getcoin().ToString();
            counHoverboard.text = "You have : "+ managerdata.manager.getvan().ToString();
        }

    }

    /// <summary>
    /// mua hộp quà trong shop
    /// </summary>
    public void ClicBuyMysteryBox()
    {
        if (managerdata.manager.Getcoin() >=500)
        {
            
            managerdata.manager.savecoin(-500);
            txtkeyinshop.text = managerdata.manager.getkey().ToString();
            txtcoininshop.text = managerdata.manager.Getcoin().ToString();
            buyitemboxintheshop = true;
            openbox();
        }
    
    }
    /// <summary>
    /// hiện item  khi vào chơi
    /// </summary>
    public void showitembuyflylong()
    {
       
        if (managerdata.manager.GetFly() > 0)
        {
            btnitemfly.gameObject.SetActive(true);
            if (Playermuving.player.gameObject.transform.position.z>10)
            {
                btnitemfly.gameObject.GetComponent<Image>().enabled = true;
                btnitemfly.gameObject.GetComponent<Button>().enabled = true;
            }
            btnitemfly.gameObject.SetActive(true);
        }
        else if (managerdata.manager.GetFly() <= 0)
        {
            btnitemfly.gameObject.SetActive(false);

        }
        CountItemFly.text = managerdata.manager.GetFly().ToString();
    }

    /// <summary>
    ///  thời gian cho hiện item
    /// </summary>
    /// <returns></returns>
    IEnumerator timerforshowbtnitem()
    {
        yield return new WaitForSeconds(3);
        btnitemfly.gameObject.SetActive(false);
    }


    public Text CountItemFly;
    /// <summary> 
    /// chọn item bay để bay lúc mới chơi
    /// </summary>
    public void ClicOnFly()
    {
        if (delayforgetitemfly)
        {
            if (Playermuving.isplay)
            {
                Perencamera.managerscen.ShowEffcts(true);
                delayforgetitemfly = false;
                StartCoroutine(GetFlyItem());
                Manageritem.usingbayitembuy = true;
                Makesupway.makemap.StartCoroutine(Makesupway.makemap.createcoinforitemflylong(Playermuving.player.gameObject.transform.position.z + 40));
                panelshowitem.GetComponent<Animator>().SetBool("clic", true);
                managerdata.manager.SaveFly(-1);
                Playermuving.player.StartCoroutine(Playermuving.player.delaydestroiitemlong());
                CountItemFly.text = managerdata.manager.GetFly().ToString();
            }
          
        }
    }
    bool delayforgetitemfly = true;
    IEnumerator GetFlyItem()
    {
        yield return new WaitForSeconds(1);
        delayforgetitemfly = true;
    }
    /// <summary>
    ///  kiểm tra xem còn  số item k nếu còn thì hiện lại nut bấm
    /// </summary>
    void OnOpenFlyAgain()
    {
        if (managerdata.manager.GetFly() > 0)
        {
            //btnitemfly.gameObject.SetActive(true);
         panelshowitem.GetComponent<Animator>().SetBool("clic", false);
        }
    }

    /// <summary>
    /// mua item bay 1 đoạn tại đầu màn chơi
    /// </summary>
    public void ClicBuyHesdstart()
    {
        if (managerdata.manager.Getcoin() >=2000)
        {
            managerdata.manager.savecoin(-2000);
            managerdata.manager.SaveFly(1);
            txtkeyinshop.text = managerdata.manager.getkey().ToString();
            txtcoininshop.text = managerdata.manager.Getcoin().ToString();
            showyouhaveHeadstar.text = "You have : " + managerdata.manager.GetFly();

        }
    }




    public Text showyouhaveHeadstar;






    /****************************************8

        HỆ THỐNG LV ITEM NÂNG CẤP ITEM LIÊN KẾT DỮ LIỆU

    *****************************************/




    #region lvitem

    public Slider jetpackslider;  // biến item slider
    public Image imgjetpack;// menu nâng caapsbay dài
    public Image imgSuperSneakers; //menu nâng cấp giày
    public Image imgSuperMagnet; //menu nâng cấp hút coin
    public Image imgX2Coin; //menu nâng cấp x2 coin
    public Text txtcoinlvjetpack;  //lưu các giái trị giá mua coin từng lv
    public Text gettx;
    /// <summary>
    /// mở menu nâng cấp bay dài
    /// </summary>
    public void ClicItemJetpack()
    {
        setanimation(imgjetpack);
    }
    /// <summary>
    /// mở menu nâng cấp giày
    /// </summary>
    public void ClicItemSuperSneakers()
    {
        setanimation(imgSuperSneakers);
    }

    /// <summary>
    /// mở menu nâng cấp hút coin
    /// </summary>
    public void ClicItemSuperMagnet()
    {
        setanimation(imgSuperMagnet);
    }



    /// <summary>
    /// mở menu nâng cấp x2 coin
    /// </summary>
    public void ClicItemX2()
    {
        setanimation(imgX2Coin);
    }



    /// <summary>
    /// tải dữ liệu item lúc mở menu
    /// </summary>
    public void loaditem()
    {
        int valuelv = managerdata.manager.GetDataItemFly();
        int valueprice = managerdata.manager.Getprice(valuelv);
        loadatherimg(imgjetpack, valuelv, valueprice);
        valuelv = managerdata.manager.GetDataItemGiay();
        valueprice = managerdata.manager.Getprice(valuelv);
        loadatherimg(imgSuperSneakers, valuelv, valueprice);
        valuelv = managerdata.manager.GetDataItemMagnet();
        valueprice = managerdata.manager.Getprice(valuelv);
        loadatherimg(imgSuperMagnet, valuelv, valueprice);
        valuelv = managerdata.manager.GetDataItemX2();
        valueprice = managerdata.manager.Getprice(valuelv);
        loadatherimg(imgX2Coin, valuelv, valueprice);
    }

    public GameObject slder;


    /// <summary>
    /// tải dữ liệu cho từng thanh menu
    /// </summary>
    /// <param name="img"></param>
    /// <param name="valuelv"></param>
    /// <param name="valueprice"></param>
    void loadatherimg(Image img,int valuelv, int valueprice)
    {

        jetpackslider = img.transform.Find("Slider").gameObject.GetComponent<Slider>();
        gettx = img.transform.Find("txtseo").gameObject.GetComponent<Text>();
        jetpackslider.value = valuelv;
        gettx.text = valueprice.ToString();
        txtkeyinshop.text = managerdata.manager.getkey().ToString();
        txtcoininshop.text = managerdata.manager.Getcoin().ToString();
    }

    /// <summary>
    /// mua nâng cấp item bay
    /// </summary>
    public void BuyitemSuperSneakers()
    {
        int valuelv = managerdata.manager.GetDataItemGiay();
        int valueprice = managerdata.manager.Getprice(valuelv);
       // Buyallitem(valuelv , valueprice, imgjetpack);
        if (managerdata.manager.Getcoin() >= valueprice)
        {
            managerdata.manager.savecoin(-valueprice);
            valuelv = valuelv + 1;
            managerdata.manager.SaveDataItemGiay(1);
            valueprice = managerdata.manager.Getprice(valuelv);
            loadatherimg(imgSuperSneakers, valuelv, valueprice);  // load lại dữ liệu trên menu
        }
    }


    /// <summary>
    /// mua nâng cấp item x2 coin
    /// </summary>
    public void BuyitemX2()
    {
        int valuelv = managerdata.manager.GetDataItemX2();
        int valueprice = managerdata.manager.Getprice(valuelv);
        // Buyallitem(valuelv , valueprice, imgjetpack);
        if (managerdata.manager.Getcoin() >= valueprice)
        {
            managerdata.manager.savecoin(-valueprice);
            valuelv = valuelv + 1;
            managerdata.manager.SaveDataItemX2(1);
            valueprice = managerdata.manager.Getprice(valuelv);
            loadatherimg(imgX2Coin, valuelv, valueprice);  // load lại dữ liệu trên menu
        }
    }




    /// <summary>
    /// mua nâng cấp item giày
    /// </summary>
    public void BuyitemJetpack()
    {
        int valuelv = managerdata.manager.GetDataItemFly();
        int valueprice = managerdata.manager.Getprice(valuelv);
        // Buyallitem(valuelv , valueprice, imgjetpack);
        if (managerdata.manager.Getcoin() >= valueprice)
        {
            managerdata.manager.savecoin(-valueprice);
            valuelv = valuelv + 1;
            managerdata.manager.SaveDataItemFly(1);
            valueprice = managerdata.manager.Getprice(valuelv);
            loadatherimg(imgjetpack, valuelv, valueprice);  // load lại dữ liệu trên menu
        }
    }


    /// <summary>
    /// mua nâng cấp item hút
    /// </summary>
    public void BuyitemSuperMagnet()
    {
        int valuelv = managerdata.manager.GetDataItemMagnet();
        int valueprice = managerdata.manager.Getprice(valuelv);
        // Buyallitem(valuelv , valueprice, imgjetpack);
        if (managerdata.manager.Getcoin() >= valueprice)
        {
            managerdata.manager.savecoin(-valueprice);
            valuelv = valuelv + 1;
            managerdata.manager.SaveDataItemMagnet(1);
            valueprice = managerdata.manager.Getprice(valuelv);
            loadatherimg(imgSuperMagnet, valuelv, valueprice);  // load lại dữ liệu trên menu
        }
    }



    /// <summary>
    /// hàm mua tất cả các item
    /// </summary>
    /// <param name="valuelv"></param>
    /// <param name="valuepice"></param>
    /// <param name="img"></param>
    private void Buyallitem(int valuelv, int valuepice,Image img)
    {
        if (managerdata.manager.Getcoin() >= valuepice)
        {
            managerdata.manager.savecoin(-valuepice);
            valuelv = valuelv + 1;
            loadatherimg(img, valuelv, valuepice);  // load lại dữ liệu trên menu
        }
    }

    #endregion

    #endregion

    public void Geetcoin()
    {
        cointxt.text = "" + coinmuving;
        coinmain.text = "" + coin;
    }

    float cahe = 0;
    public Text showwhisthighscore;
    // Update is called once per frame
    void Update () {
        cahe += Time.deltaTime;
        if (cahe >60)
        {
            Caching.ClearCache();
            cahe = 0;
        }
        if (Playermuving.player != null)
        {
            if (Playermuving.isplay)
            {
                panellost.gameObject.SetActive(false);
                Geetcoin();
                if (managerdata.manager.getmuving() - coinmuving >0)
                {
                    gettex.text = (managerdata.manager.getmuving() - coinmuving).ToString();
                }
                else
                {
                    gettex.text = "000";
                }

                if (Time.timeScale <= 1.1f)
                {
                    if (coinmuving > coinforuplv)
                    {
                        coinforuplv = coinforuplv * 2;
                        Time.timeScale += 0.05f;
                    }
                }
            }
 
        }
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        SHOW.text ="FPS : "+ fps.ToString();
        layout = imgHoverboard.GetComponent<ILayoutElement>();
     }
    public Text SHOW;
    float deltaTime = 0.0f;
    int add = 1;
    public Text gettex;
    int gettexint = 0;
    float time;
  public static  int coinforuplv = 5000;

    /// <summary>
    /// thoát game
    /// </summary>
    void OnApplicationPause()
    {
        if (Playermuving.isplay)
        {
            inthepanelpause.pauses.pause();
        }
    }

   public IEnumerator DelayForLogin()
    {
        yield return new WaitForSeconds(1);
       

    }


    public Image Avatarfb;
    public static Image saveImage;
    public static bool LogInFb ;
    public void SetImageAvatarFAb()
    {
           // Avatarfb.sprite = saveImage.sprite;
    }
    public void SetImgAvatarFB(Image img)
    {
        //saveImage.sprite = img.sprite;
    }
     }
