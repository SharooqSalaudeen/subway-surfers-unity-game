using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// manager all player
/// </summary>
public class Playermuving : MonoBehaviour
{

    public GameObject head;
    public GameObject checkdie;
    Rigidbody rb;
    float poinstart;
    bool alowjupm; // biến cho nhả 1 phát
    // Use this for initialization
    public  GameObject playermodol;
    // các item
    public GameObject biinhxit;
    public GameObject biinhxit1; 
    public GameObject biinhxit2; 
    public GameObject baycaodai; 
    public GameObject baycaodai1; 
    public GameObject baycaodai2; 
    public GameObject baycao; 
    public GameObject van;
    public GameObject vangau; 
    public GameObject vangirl; 
    public Animator animationPlayer;
    float lastvectoryx;  // lưu vectory để đảo chiều player
    public GameObject destroicoin;
    [HideInInspector]
    float mainvectory = 15;
    public static  float speedmuving = 15;
    public static bool isplay;
    public static Playermuving player;
    Vector3 posisonanimation;
    Vector3 rotationanimation;
    float timeagainanimation;
    bool allowcall; // fix lỗi gọi bị 2 lần item
    int checkgetmosechange = 0;
    int stylemuving; // kiểu di chuyển trái hặch phải sửa lỗi input bị trễ
    public static float gettranformofplayerforitemvantomuving = 0; // lấy tọa độ của player để tính tọa độ va chạm lúc có ván trượt từ đó đưa toàn bộ các đối tượng trong khoảng  về phía sau
    // đeo giày lúc nhặt item giày
    public GameObject giayleft, giayrigh;

    public GameObject Rightcheck, LeftCheck;
    void Start()
    {
        setTranformitem();
        head = gameObject.transform.Find("head").gameObject;
        rotationanimation = playermodol.transform.eulerAngles;
        posisonanimation = playermodol.transform.position;
        savethetranformcheckformuvingvoin = transform.position.z;
        rb = GetComponent<Rigidbody>();
        SetFLyLong(false);
        checkgetmosechange = 0;
        baycao.SetActive(false);
        backnowmuvingship = false;
        van.SetActive(false);
        SetVan(false);
        touchtheship = false;
        allowcall = true;
        alowjupm = true;
        isplay = false;
        player = this;
        loaddatavan();
    }

    void SetFLyLong(bool style)
    {
        if (style)
        {
            baycaodai.SetActive(true);
            baycaodai1.SetActive(true);
            baycaodai2.SetActive(true);
        }
        else
        {
            baycaodai.SetActive(false);
            baycaodai1.SetActive(false);
            baycaodai2.SetActive(false);
        }
    }
    void SetVan(bool value)
    {
        if (value==false)
        {
            van.SetActive(false);
            vangirl.SetActive(false);
            vangau.SetActive(false);
        }
        else if (value)
        {
            van.SetActive(true);
            vangirl.SetActive(true);
            vangau.SetActive(true);
        }
    }
    public Transform vantranform;
    public Transform vantranformgau;
    public Transform vantranformgirl;
    public Transform vantranformdown;
    public List<GameObject> vantranformlist = new List<GameObject>(); 
    public List<GameObject> vantranformlistgau = new List<GameObject>();
    public List<GameObject> vantranformlistgirl = new List<GameObject>(); 
    public List<GameObject> vantranformdownlist = new List<GameObject>();
    public List<GameObject> Allplayer = new List<GameObject>();
    // tranform để xét các item vào các player tương ứng
   public void setTranformitem()
    {
        for (int i = 0; i < Allplayer.Count; i++)
        {
            if (managerdata.manager.Getnowcharacter()== Allplayer[i].name)
            {
                Allplayer[i].SetActive(true);
                switch (Allplayer[i].name)
                {
                    case "nvchinh":
                        playermodol = gameObject.transform.Find("nvchinh").gameObject;
                        giayleft.transform.position = new Vector3(tagettranformgiayleft.position.x + 0.2f, tagettranformgiayleft.position.y, tagettranformgiayleft.position.z);
                        giayleft.transform.parent = tagettranformgiayleft;
                        giayrigh.transform.position = new Vector3(tagettranformgiayright.position.x + 0.2f, tagettranformgiayright.position.y, tagettranformgiayright.position.z);
                        giayrigh.transform.parent = tagettranformgiayright;
                        break;
                    case "nvgirl":
                        playermodol = gameObject.transform.Find("nvgirl").gameObject;
                        giayleft.transform.position = new Vector3(tagettranformgiayleftgirl.position.x+0.1f, tagettranformgiayleftgirl.position.y, tagettranformgiayleftgirl.position.z);
                        giayleft.transform.parent = tagettranformgiayleftgirl;
                        giayrigh.transform.position = new Vector3(tagettranformgiayrightgirl.position.x + 0.1f, tagettranformgiayrightgirl.position.y-0.03f, tagettranformgiayrightgirl.position.z);
                        giayrigh.transform.parent = tagettranformgiayrightgirl;
                        break;
                    case "nvgau":
                        playermodol = gameObject.transform.Find("nvgau").gameObject;
                        giayleft.transform.position = new Vector3(tagettranformgiayleftgau.position.x+0.1f , tagettranformgiayleftgau.position.y, tagettranformgiayleftgau.position.z-0f);
                        giayleft.transform.eulerAngles = new Vector3(tagettranformgiayleftgau.eulerAngles.x, giayleft.transform.eulerAngles.y, giayleft.transform.eulerAngles.z+30);
                        giayleft.transform.parent = tagettranformgiayleftgau;
                        giayrigh.transform.position = new Vector3(tagettranformgiayrightgau.position.x + 0.2f, tagettranformgiayrightgau.position.y, tagettranformgiayrightgau.position.z);
                        giayrigh.transform.parent = tagettranformgiayrightgau;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Allplayer[i].SetActive(false);
            }
       

        }
        animationPlayer = playermodol.GetComponent<Animator>();
    }

    // các biến sét tranform paren tro từng item nhân vật
    public Transform savetranformvan;
    public Transform savetranformvangirl;
    public Transform savetranformvangau;
    public Transform tagettranformgiayleft;
    public Transform tagettranformgiayright;
    public Transform tagettranformgiayleftgirl;
    public Transform tagettranformgiayrightgirl;
    public Transform tagettranformgiayleftgau;
    public Transform tagettranformgiayrightgau;
    public Transform tagettranformbay;
    public Transform tagettranformbaygirl;
    public Transform tagettranformbaygau;
    /// <summary>
    /// kiểm tra dữ liệu trong ván trượt đang lưu cái nào
    /// </summary>
    public void loaddatavan()
    {
        foreach (Transform item in vantranform)  // tải ván trượt nhân vật jack
        {
            vantranformlist.Add(item.gameObject);
            
        }
        for (int i = 0; i < vantranformlist.Count; i++)
        {
            if (vantranformlist[i] != null)
            {
                if (vantranformlist[i].name == managerdata.manager.Getvanuser())
                {
                    vantranformlist[i].SetActive(true);
                }
                else
                {
                    vantranformlist[i].SetActive(false);
                }
            }
           
        }
        foreach (Transform item in vantranformgau) // tải ván trượt nhân vật fesd
        {
            vantranformlistgau.Add(item.gameObject);

        }
        for (int i = 0; i < vantranformlistgau.Count; i++)
        {
            if (vantranformlistgau[i] != null)
            {
                if (vantranformlistgau[i].name == managerdata.manager.Getvanuser())
                {
                    vantranformlistgau[i].SetActive(true);
                }
                else
                {
                    vantranformlistgau[i].SetActive(false);
                }
            }

        }

        foreach (Transform item in vantranformgirl) // tải ván trượt nhân vật girl
        {
            vantranformlistgirl.Add(item.gameObject);

        }
        for (int i = 0; i < vantranformlistgirl.Count; i++)
        {
            if (vantranformlistgirl[i] != null)
            {
                if (vantranformlistgirl[i].name == managerdata.manager.Getvanuser())
                {
                    vantranformlistgirl[i].SetActive(true);
                }
                else
                {
                    vantranformlistgirl[i].SetActive(false);
                }
            }

        }
        foreach (Transform item in vantranformdown) // tải ván trượt nằm
        {
            vantranformdownlist.Add(item.gameObject);

        }
        for (int i = 0; i < vantranformdownlist.Count; i++)
        {
            if (vantranformdownlist[i] != null)
            {
                if (vantranformdownlist[i].name == managerdata.manager.Getvanuser())
                {
                    vantranformdownlist[i].SetActive(true);
                }
                else
                {
                    vantranformdownlist[i].SetActive(false);
                }
            }

        }
    }

    bool delayleftright = false;
    // Update is called once per frame
    float xxx =1;
    void Update()
    {
      
     //   Debug.Log(xxx);
        if (isplay)
        {
            if (Time.timeScale != 0)
            {
                Getscore(Time.timeScale);
            }
            checkdie.transform.Translate(new Vector3(0, 0, speedmuving * Time.deltaTime));
            transform.Translate(new Vector3(0, 0, speedmuving * Time.deltaTime));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,-3.5f,3.5f), Mathf.Clamp(transform.position.y, 0.5f, 25), transform.position.z);
            if (Manageritem.van)
            {
                checkdie.transform.position = transform.position;
            }
            if (transform.position.y>9)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x,-2.5f,2.5f),transform.position.y,transform.position.z);
            }
            if (Manageritem.baycoin || Manageritem.baylongcoin|| delayleftright)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -2.5f, 15f), transform.position.z);
            }
            if (Manageritem.van == false)
            {
                downvan.SetActive(false); // tắt ván trượt  nằm dưới
                playermodol.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z); // sửa lỗ load tọa độ thỉnh thỏng bọ sai
            }
            if (rb.velocity.x==0)
            {
                if (transform.position.x!=-2.5f|| transform.position.x != 0|| transform.position.x != 2.5f)
                {
                    backtotruposison();
                }
            }
        }
      
        else if (isplay == false)
        {
            //rb.velocity = new Vector3(0,-3,0);
            if (transform.position.y < 0.78f)
            {
                transform.position = new Vector3(transform.position.x, 0.8f, transform.position.z);
            }
            if (transform.position.z<10)
            {
                timeagainanimation += Time.deltaTime;
                if (timeagainanimation >= 20)
                {
                    playagainanimation();
                    timeagainanimation = 0;
                }
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,-3,5),Mathf.Clamp(transform.position.y,-2,4),transform.position.z);
        }
        //Debug.Log(rb.velocity);
    }
  
    float coinmuving;
public void Getscore(float value)
    {
        UImanager.coinmuving = (int)((transform.position.z - savethetranformcheckformuvingvoin) * 3 * (0.3f + value) * (0.3f + value) * (0.3f + value)); // lưu điểm theo tọa độ
    }
    public Transform tagetcutchemty;
    public Transform tagetcutchplayer;

    #region Hệ thống animator quản lý animation
    public void runamin()
    {
        animationPlayer.SetBool("jump", false);
        emty.emtyplayer.ExitJump();
    }
    public void jupamin()
    {
        animationPlayer.SetBool("jump", true);
    }

    /// <summary>
    ///  cho model về vị trí cũ
    /// </summary>
    public void playagainanimation()
    {
        playermodol.transform.position = new Vector3(-1.25f,0,-7);
        playermodol.transform.eulerAngles = rotationanimation;
    }
    public void OpenMenu3D()
    {
        animationPlayer.enabled = false;
        playagainanimation();
    }
    /// <summary>
    /// hàm load tọa độ khi ấn play
    /// đưa model về đúng vị trí xuất phát chạy
    /// </summary>
    public void intheplaysceenmain()
    {
        posisonanimation.x = 0;
        posisonanimation.y = 0.2f;
        transform.position = new Vector3(0, 0.8f, transform.position.z);
        posisonanimation = transform.position;
        posisonanimation.y = posisonanimation.y - 1;
        checkdie.transform.position = transform.position; // đư check đia về tọa độ của player
        playermodol.transform.position = posisonanimation;
        rotationanimation.y = 0;
        playermodol.transform.eulerAngles = rotationanimation;
        playermodol.GetComponent<Animator>().applyRootMotion = false;
        animationPlayer.SetBool("play", true);
        animationPlayer.SetBool("again", false);
        biinhxit.gameObject.SetActive(false);
        biinhxit1.gameObject.SetActive(false);
        biinhxit2.gameObject.SetActive(false);
    }
    #endregion


    #region hệ thống xử lý va chạm
    void OnCollisionEnter(Collision coll)
    {
        if (isplay == true)
        {
            if (transform.position.y<5)
            {
                delayleftright = false;
            }
            alowjupm = true;
            animationPlayer.SetBool("down", true);
            if (coll.gameObject.tag == "wall")
            {
                runamin();
            }
            if (transform.position.y <7)
            {
                if (coll.gameObject.tag == "mai")
                {
                    runamin();
                    Manageritem.baycoin = false;
                }
                if (coll.gameObject.tag == "die")
                {
                    Soundmanager.soundmanager.PlayPoliceSound();

                    if (Manageritem.baylongcoin == false && Manageritem.baycoin == false)
                    {
                        downvan.SetActive(false); // tắt ván trượt  nằm dưới
                        if (Manageritem.van)
                        {
                            StartCoroutine(checkhaveitemvan()); // check item ván
                        }
                        else if (Manageritem.van == false)
                        {
                            ExitAllItem();
                            Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.Effect()); // hiệu ứng rung camera
                            emty.emtyplayer.startatact();
                            emty.emtyplayer.StartCoroutine(emty.emtyplayer.alowcalltheactact());
                            emty.emtyplayer.StartCoroutine(emty.emtyplayer.animationrunplay());
                            enterthedie();
                        }
                    }

                }
                // check va chạm nga đưa player về vị trí đầu
                if (coll.gameObject.tag == "ship" || coll.gameObject.tag == "shipnotdie" || coll.gameObject.tag == "thanhchan" || coll.gameObject.tag == "cau")
                {
                    Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.Effect()); // hiệu ứng rung camera
                    StartCoroutine(delayanimationwentouchtheship());

                    rb.velocity = Vector3.zero;

                    rb.velocity = new Vector3(-lastvectoryx, 0, 0);
                    if (lastvectoryx > 0)
                    {
                        StartCoroutine(backlastpositionright());
                    }
                    else if (lastvectoryx < 0)
                    {
                        StartCoroutine(backlastpositionleft());
                    }
                    if (Manageritem.van == false)
                    {
                        touchtheship = true;

                    }
                    if (Manageritem.van == true)
                    {
                        touchtheship = true;
                    }
                }
                // check chết
                if (coll.gameObject.tag == "ship" || coll.gameObject.tag == "shipnotdie" || coll.gameObject.tag == "headship" || coll.gameObject.tag == "thanhchan" || coll.gameObject.tag == "cau")
                {

                    Manageritem.baylongcoin = false;
                    if (Manageritem.van == false)
                    {
                        StartCoroutine(CheckDie());
                        StartCoroutine(backtotruposison());
                    }
                    if (coll.gameObject.tag == "ship" || coll.gameObject.tag == "shipnotdie" || coll.gameObject.tag == "thanhchan" || coll.gameObject.tag == "cau")
                    {
                        StartCoroutine(checkhaveitemvan());
                    }
                }
                if (coll.gameObject.tag == "upcamera")
                {
                    backtodie();
                    rb.useGravity = false;
                    Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.delaycameraup(0.1f));
                }
                if (coll.gameObject.tag == "ship" || coll.gameObject.tag == "shipnotdie" || coll.gameObject.tag == "shipnotdie" || coll.gameObject.tag == "cau" || coll.gameObject.tag == "cau" || coll.gameObject.tag == "thanhchan" || coll.gameObject.tag == "cau" || coll.gameObject.tag == "thanhchan")
                {
                    if (Manageritem.baylongcoin == false && Manageritem.baycoin == false)
                    {
                        if (emty.emtyplayer != null && emty.alowcallhere)
                        {
                            Soundmanager.soundmanager.PlayPoliceSound();
                            if (Manageritem.van == false)
                            {
                                emty.emtyplayer.startatact();
                                emty.emtyplayer.StartCoroutine(emty.emtyplayer.alowcalltheactact());
                                emty.emtyplayer.StartCoroutine(emty.emtyplayer.animationrunplay());
                            }
                        }
                    }
                }
            }
        }
            

    }
    bool alowcallvan = true;
    /// <summary>
    /// kiểm tra ván trượt khi va chạm
    /// </summary>
    /// <returns></returns>
    public IEnumerator checkhaveitemvan()
    {
        if (Manageritem.van&& alowcallvan)
        {
            Soundmanager.soundmanager.PlayAgain();

            if (Manageritem.giay)
            {
                //animationPlayer.SetBool("rungiay", false);
                //Manageritem.giay = false;
            }
          
            alowcallvan = false;
            isplay = false;
            transform.Translate(0,0,-1);
            Makesupway.makemap.StartCoroutine(Makesupway.makemap.MuvingbackAllemtyWenhaveitemVan(true));
            transform.position = new Vector3(transform.position.x,3.5f,transform.position.z);
            Camerafolow.camfolowplayer.Intanceectff();
            gettranformofplayerforitemvantomuving = transform.position.z;
            yield return new WaitForSeconds(0.01f);
            Perencamera.managerscen.height = 3;
          //  head.GetComponent<Collider>().enabled = true; // tắt toàn bộ colider và lwucj hút trái đất trở về trạng thái đầu
            GetComponent<Collider>().enabled = true;
            GetComponent<Rigidbody>().useGravity = true;
            yield return new WaitForSeconds(0.3f);
            touchtheship = false;
            Manageritem.van = false;
            animationPlayer.SetBool("van", false);
            playermodol.transform.eulerAngles = gocquay;
            van.gameObject.SetActive(false);
            SetVan(false);
            Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.delaycameraup(-0.1f));   
            yield return new WaitForSeconds(0.5f);
            alowcallvan = true;
        }
    }

    /// <summary>
    /// chơi ngay lập tức tại vị trí hiện tại
    /// </summary>
    /// <returns></returns>
    public void playnowthehere()
    {
        animationPlayer.SetBool("play", true);
        animationPlayer.SetBool("again", false);
        animationPlayer.SetBool("die", false);
        animationPlayer.SetBool("flylong", false);
        animationPlayer.SetBool("van", false);
        animationPlayer.SetBool("bay", false);
        animationPlayer.applyRootMotion = false;
        transform.Translate(new Vector3(0, 4f, 0));
        playermodol.transform.eulerAngles = rotationanimation; // đươa gó quay về ban đầu
        playermodol.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z); //  
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
       // isplay = true;
        touchtheship = false;
    }
    public static bool backnowmuvingship = false;
    /// <summary>
    /// chạm đối diện vào colider die cho player chết ngay tai chỗ
    /// </summary>
    public void enterthedie()
    {
        rb.velocity = Vector3.zero;
        Perencamera.managerscen.height = 3;
        backnowmuvingship = true;
        isplay = false;
        transform.Translate(0,0,0);




        //checccc 
        emty.emtyplayer.OnanimationCash();
        gettranformofplayerforitemvantomuving = transform.position.z;
        Camerafolow.isdowham = false;
        UImanager.uimanager.Lost();
        animationPlayer.SetBool("die", true);
        animationPlayer.SetBool("jump", false);
        animationPlayer.SetBool("cut", false);
        animationPlayer.SetBool("again", false);
    }
    public void Enterdieinfart()
    {
        Perencamera.managerscen.height = 3;
     //   rb.velocity = Vector3.zero;
        backnowmuvingship = true;
        isplay = false;
        transform.Translate(0, 0, 0);
        emty.emtyplayer.OnanimationCash();
        gettranformofplayerforitemvantomuving = transform.position.z;
        Camerafolow.isdowham = false;
        animationPlayer.SetBool("die", true);
        animationPlayer.SetBool("jump", false);
        animationPlayer.SetBool("cut", false);
        animationPlayer.SetBool("again", false);

    }
    public  IEnumerator DelaytoFixAnimation()
    {
        for (int i = 0; i < 10; i++)
        {
            if (isplay)
            {
               
                break;
            }
            yield return new WaitForSeconds(0.1f);
            animationPlayer.SetBool("cut", true);
            animationPlayer.SetBool("die", true);
            animationPlayer.SetBool("again", false);
        }
    }
    /// <summary>
    /// cho player đi đúng làn đường
    /// </summary>
    /// <returns></returns>
  public  IEnumerator backtotruposison()
    {
        for (int i = 0; i < 300; i++)
        {
            yield return new WaitForFixedUpdate();
            if (rb.velocity.x <= 1&& rb.velocity.x >= -1)
            {
                if (transform.position.x != -2.5f || transform.position.x != 0f || transform.position.x != 2.5f)
                {
                    float d1, d2, d3, min;
                    d1 = Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(-2.5f, 0, 0));
                    d2 = Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(0, 0, 0));
                    d3 = Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(2.5f, 0, 0));
                    min = d1;
                    if (min > d2)
                    {
                        min = d2;
                        if (min > d3)
                        {
                            min = d3;
                        }
                    }
                    else if (min > d3)
                    {
                        min = d3;
                        if (min > d2)
                        {
                            min = d2;
                        }
                    }
                    if (min == d1)
                    {
                        transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);
                    }
                    else if (min == d2)
                    {
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                    }
                    else if (min == d3)
                    {
                        transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);
                    }
                    break;
                }
                else if (transform.position.x == -2.5f || transform.position.x == 0f || transform.position.x == 2.5f)
                {
                    break;
                }
            }
        }
        if (transform.eulerAngles.x!=0|| transform.eulerAngles.y !=0|| transform.eulerAngles.z !=0)
        {
     
            transform.eulerAngles = new Vector3(0,0,0);
        }
    }


    /// <summary>
    /// về vị trí cũ khi va cạnh phải
    /// </summary>
    /// <returns></returns>
    IEnumerator backlastpositionright()
    {
        for (int i = 0; i < 1000; i++)
        {
            yield return new WaitForSeconds(0.001f);
            transform.position = new Vector3((Mathf.Clamp(transform.position.x, poinstart, poinstart + 2.5f)), transform.position.y, transform.position.z);
            if (transform.position.x <= poinstart)
            {
                rb.velocity = Vector3.zero;
                break;
            }
        }
        rb.velocity = Vector3.zero;
    }


    /// <summary>
    /// về vị trí cũ khi va cạnh trái
    /// </summary>
    /// <returns></returns>
    IEnumerator backlastpositionleft()
    {
        for (int i = 0; i < 1000; i++)
        {
            yield return new WaitForSeconds(0.001f);
            transform.position = new Vector3((Mathf.Clamp(transform.position.x, poinstart - 2.5f, poinstart)), transform.position.y, transform.position.z);
            if (transform.position.x >= poinstart)
            {
                rb.velocity = Vector3.zero;
                break;
            }
        }
        rb.velocity = Vector3.zero;
    }
    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "wall" || coll.gameObject.tag == "headship")
        {
           alowjupm = true;
            runamin();
        }

        if (coll.gameObject.tag == "taungang")
        {
            Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.delaycameraup(0.1f));
            backtodie();
        }
    }

    /// <summary>
    /// fix lỗi bị chết ngay giwuax đường
    /// </summary>
  public  void backtodie()
    {
        float xx = transform.position.x;
        float yy = transform.position.y;
        float zz = transform.position.z;
        checkdie.transform.position = new Vector3(xx, yy, zz);
    }


    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "headship" || coll.gameObject.tag == "taungang")
        {
            positionchekdowcameray = transform.position.y;
            StartCoroutine(Checkcameradown());
        }
        if (coll.gameObject.tag == "upcamera") // xử lý va  vào cahj đoạn dốc cũng cho bật lại
        {
            rb.useGravity = true;

        }
    
    }
    float positionchekdowcameray;
    bool checkforcameradow;

    /// <summary>
    ///  animation ngoái nhì chảnh sát
    /// </summary>
    /// <returns></returns>
    IEnumerator  delayanimationwentouchtheship()
    {
        animationPlayer.SetBool("touchship", true);
        yield return new WaitForSeconds(0.1f);
        animationPlayer.SetBool("touchship", false);

    }
    bool alowbckmap = true;
    //
    /// <summary>
    ///  xử lý tất cả các item
    /// </summary>
    /// <param name="coll"></param>
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "backmap")
        {
            Perencamera.managerscen.height = 1;
            Makesupway.makemap.StartCoroutine(Makesupway.makemap.CreaTeCoinInmap5());
        }
        if (coll.gameObject.tag == "down")
        {
          //  Debug.Log("xuống");
            animationPlayer.SetBool("jump", true);
        }
        // coin chính
        if (coll.gameObject.tag == "coin")
        {
            Soundmanager.soundmanager.PlayCoinSound();
            GameObject createsound = Instantiate(destroicoin, coll.transform.position, transform.rotation) as GameObject;
            createsound.transform.parent = transform;
            if (coll.gameObject.name == "coinend")
            {
                StartCoroutine(exitdelaydestroiitem());
            }
            if (coll.gameObject.name == "coinendtem2")
            {
                StartCoroutine(exitdelaydestroiitemlong());
            }
            Destroy(coll.gameObject);
            // lư lại điểm
            if (Manageritem.x2coin)
            {
                UImanager.coin += 2;
            }
            else
            {
                UImanager.coin += 1;
            }
        }
        // item nhar cao
        if (coll.gameObject.tag == "iteamgiay")
        {
            //  StartCoroutine
            GetGiay();
            Destroy(coll.gameObject);
            UImanager.uimanager.StartCoroutine(UImanager.uimanager.delayslideritemgiay(40+managerdata.manager.GetDataItemGiay()*5));
        }
        // item x2 coinge
        if (coll.gameObject.tag == "x2coin")
        {
            Playermuving.player.StartCoroutine(Playermuving.player.EffectWenHavaeItem());

            Soundmanager.soundmanager.Getitemplay();
            Destroy(coll.gameObject);
            UImanager.uimanager.StartCoroutine(UImanager.uimanager.delayslideritemx2(40+managerdata.manager.GetDataItemX2()*10));
        }
        // item hút coin
        if (coll.gameObject.tag == "namcham")
        {
            GetIkmagnet();
            Destroy(coll.gameObject);
            UImanager.uimanager.StartCoroutine(UImanager.uimanager.delayslideritemhut(40 + managerdata.manager.GetDataItemMagnet() * 10));
        }
        // item bay 1 đoạn
        if (coll.gameObject.tag == "bay")
        {
            if (allowcall)
            {
                Destroy(coll.gameObject);
                Playermuving.player.StartCoroutine(Playermuving.player.EffectWenHavaeItem());
                IKanimation.IKMAGNET.SetIKBay();
                IKanimation.iklegth1 = 1;
                IKanimation.iklegth = 1;
                Soundmanager.soundmanager.Getitemplay();
                rb.velocity = Vector3.zero;
                allowcall = false;
                StartCoroutine(delaydestroiitem());
                Makesupway.makemap.StartCoroutine(Makesupway.makemap.creacoinforitemfly(coll.gameObject.transform.position.z + 40));
                Destroy(coll.gameObject);
                Manageritem.baycoin = true;
            }
        }
        // item hộp quà
        if (coll.gameObject.tag == "hopqua")
        {
            Playermuving.player.StartCoroutine(Playermuving.player.EffectWenHavaeItem());
            Soundmanager.soundmanager.Getitemplay();
            Manageritem.box = true;
            Destroy(coll.gameObject);
        }
        // item chìa khóa 
        if (coll.gameObject.tag == "key")
        {
            Soundmanager.soundmanager.Getitemplay();
            Playermuving.player.StartCoroutine(Playermuving.player.EffectWenHavaeItem());
            managerdata.manager.savekey(1);
            Destroy(coll.gameObject);
        }
        // item bay đoạn dai
        if (coll.gameObject.tag == "baycao")
        {
            animationPlayer.SetBool("van", false);
            Makesupway.makemap.StartCoroutine(Makesupway.makemap.createcoinforitemflylong(coll.gameObject.transform.position.z + 50));
            if (Manageritem.baycoin)
            {
                Manageritem.baycoin = false;
                IKanimation.IKMAGNET.Deleteikbay();
                animationPlayer.SetBool("bay", false);
                rb.mass = 1;
                rb.useGravity = false;
                baycao.SetActive(false);
            }
                Playermuving.player.StartCoroutine(Playermuving.player.EffectWenHavaeItem());
                Soundmanager.soundmanager.Getitemplay();
                allowcall = false;
                Destroy(coll.gameObject);
                StartCoroutine(delaydestroiitemlong());
        }
        // item ván trượt
        if (coll.gameObject.tag == "van")
        {
            Playermuving.player.StartCoroutine(Playermuving.player.EffectWenHavaeItem());
            Soundmanager.soundmanager.Getitemplay();
            if (managerdata.manager != null)
            {
               managerdata.manager.savevan(1);
            }
            StartCoroutine(delayfordestroiitemmain());
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "dowleft")
        {
            Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.dowcamera("down"));
            Perencamera.managerscen.height = 0;
        }

    }

    public void GetIkmagnet()
    {
        Playermuving.player.StartCoroutine(Playermuving.player.EffectWenHavaeItem());
        Soundmanager.soundmanager.Getitemplay();
        IKanimation.iklegth = 1;
        IKanimation.IKMAGNET.SetIKnamCham();
        magnet.SetActive(true);
        magnet1.SetActive(true);
        magnet2.SetActive(true);
    }

    public void GetGiay()
    {
        Playermuving.player.StartCoroutine(Playermuving.player.EffectWenHavaeItem());
        Soundmanager.soundmanager.Getitemplay();
        this.GetComponent<CapsuleCollider>().center = new Vector3(0, -0.45f, 0);
        this.GetComponent<CapsuleCollider>().radius = 0.46f;
        this.GetComponent<CapsuleCollider>().height = 1f;
        animationPlayer.SetBool("rungiay", true);
        giayleft.SetActive(true);
        giayrigh.SetActive(true);
      
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "backmap")
        {
            Perencamera.managerscen.height = 3;
        }
        // thoát  khỏi gầm cầu
        if ( coll.gameObject.tag == "dowleft")
        {
            Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.dowcamera("up"));
            Perencamera.managerscen.height = 3;
        }
        if (coll.gameObject.tag == "coin")
        {
            Destroy(coll.gameObject);
        }

    }
    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "backmap")
        {
            Perencamera.managerscen.height = 1;
        }
        // thoát  khỏi gầm cầu
        if (coll.gameObject.tag == "coin")
        {
            Destroy(coll.gameObject);
        }
    }
    // tính năng của player khi có item bay 1 đoạn
    IEnumerator delaydestroiitem()
    {
        Perencamera.managerscen.GetItemFly();

        Rightcheck.SetActive(false);
        LeftCheck.SetActive(false);
        GetComponent<Collider>().enabled = false;  // bỏ colider tránh va chạm
        GetComponent<CapsuleCollider>().enabled = false;
        baycao.SetActive(true);
        rb.mass = 0;
        rb.useGravity = false;
        animationPlayer.SetBool("bay", true);
        animationPlayer.SetBool("down", false);
        emty.emtyplayer.exittheactack();
        Camerafolow.speed = 4;
        if (Manageritem.van)  // nếu có ván trượt thì thoát khỏi ván trượt và thoát khỏi cả giày
        {
            playermodol.transform.eulerAngles = gocquay;
            Manageritem.van = false;
            animationPlayer.SetBool("van", false);
            SetVan(false);
        }
        if (Manageritem.giay) // nếu có giày thoát luôn khỏi item hgiayf
        {
            giayleft.SetActive(false);
            giayrigh.SetActive(false);
        }
        if (transform.position.y>=4f)
        {
            Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.dowcamwenFly()); // cho camera đi xuống để k bị khuất player
        }
        for (int i = 0; i < 500; i++)
        {
            yield return new WaitForSeconds(0.001f);
            if (transform.position.y < 14.9f)
            {
               // rb.velocity = new Vector3(0,6,0)
                      //rb.velocity = new Vector3(0, 10, 0);
                transform.Translate(new Vector3(0, 7 * Time.deltaTime, 0));
                ;            }
            else if (transform.position.y >= 14.9f)
            {
                Perencamera.managerscen.DeleteIItemFly();
                rb.velocity = Vector3.zero;
                transform.position = new Vector3(transform.position.x, 14.9f, transform.position.z);
                GetComponent<Collider>().enabled = true;  // bỏ colider tránh va chạm
                GetComponent<CapsuleCollider>().enabled = true;
                break;
            }
        }
        yield return new WaitForSeconds(1);
        Camerafolow.speed = 1;
    }

    // thoát khỏi trạng thái bay ngawns
    public  IEnumerator exitdelaydestroiitem()
    {
        Makesupway.makemap.Backshipitem();
        delayleftright = true;

        Rightcheck.SetActive(true);
        LeftCheck.SetActive(true);
        IKanimation.IKMAGNET.Deleteikbay();
        animationPlayer.SetBool("bay", false);
        if (Manageritem.baylongcoin == false)
        {
            rb.mass = 1;
            rb.useGravity = true;
        }
        baycao.SetActive(false);
        yield return new WaitForSeconds(0f);
        if (Manageritem.giay) // nếu có giày bật lại đôi giày
        {
            animationPlayer.SetBool("rungiay", true);
            giayleft.SetActive(true);
            giayrigh.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
      
        allowcall = true;
        yield return new WaitForSeconds(1f);
     //   delayleftright = false;
    }

    /// <summary>
    ///  // tính năng của player khi có item bay đoạn dài
    /// </summary>
    /// <returns></returns>
   public  IEnumerator delaydestroiitemlong()
    {
      //  GetComponent<Collider>().enabled = false;  // bỏ colider tránh va chạm
        GetComponent<CapsuleCollider>().enabled = false;
        Rightcheck.SetActive(false);
        LeftCheck.SetActive(false);
        Manageritem.baylongcoin = true;
        animationPlayer.SetBool("van", false);
        SetFLyLong(true);
        animationPlayer.SetBool("flylong", true);
        animationPlayer.SetBool("down", false);
        rb.mass = 0;
        rb.useGravity = false;
        if (Manageritem.van)  // nếu có ván trượt thì thoát khỏi ván trượt và thoát khỏi cả giày
        {
            playermodol.transform.eulerAngles = gocquay;
            Manageritem.van = false;
            animationPlayer.SetBool("van", false);
            SetVan(false);
        }
        if (Manageritem.giay) // nếu có giày thoát luôn khỏi item hgiayf
        {
            Manageritem.giay = false;
            giayleft.SetActive(false);
            giayrigh.SetActive(false);
        }
        if (transform.position.y >= 4f)
        {
            Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.dowcamwenFly()); // cho camera đi xuống để k bị khuất player
        }
        emty.emtyplayer.exittheactack();
        rb.velocity = Vector3.zero;
        Camerafolow.speed = 4;
        Perencamera.managerscen.ShowEffcts(true);
        Perencamera.heightDamping = 100;
        speedmuving = 30;

        for (int i = 0; i < 500; i++)
        {
            yield return new WaitForSeconds(0.0005f);
            SetVan(false);
            animationPlayer.SetBool("van", false);
            if (transform.position.y < 14.9f)
            {
                //rb.velocity = new Vector3(0, 10, 0);
                transform.Translate(new Vector3(0,20*Time.deltaTime,0));
            }
            else if (transform.position.y >= 14.9f)
            {
                UImanager.uimanager.StartCoroutine(UImanager.uimanager.delayslideritembay(50));
                Perencamera.managerscen.DeleteIItemFly();
                speedmuving = 30;
                transform.position = new Vector3(transform.position.x, 14.9f, transform.position.z);
                GetComponent<Collider>().enabled = true;   
                GetComponent<CapsuleCollider>().enabled = true;
                rb.velocity = Vector3.zero;
                break;
            }
        }
        Perencamera.heightDamping = 2;

        yield return new WaitForSeconds(2);
        Camerafolow.speed = 1;

    }
    /// <summary>
    /// thoát khỏi bay đọn dài
    /// </summary>
    /// <returns></returns>
    public IEnumerator exitdelaydestroiitemlong()
    {
        delayleftright = true;
        animationPlayer.SetBool("flylong", false);
        Makesupway.makemap.Backshipitem();
        Perencamera.managerscen.ShowEffcts(false);
        Rightcheck.SetActive(true);
        LeftCheck.SetActive(true);
        rb.mass = 1;
        rb.useGravity = true;
        SetFLyLong(false);
        Manageritem.baylongcoin = false;
        speedmuving = 15;
        allowcall = true;
        yield return new WaitForSeconds(2f); // chờ rơi xuống
     //   delayleftright = false;
    }
    /// <summary>
    /// khi play rẻ rơi xuống mới kiểm tra
    /// </summary>
    /// <returns></returns>
    public IEnumerator checkpositionwenplayrerdow()
        {
        for (int i = 0; i < 500; i++)
        {
            yield return new WaitForSeconds(0.02f);

            if (transform.position.y <7)
            {
               // Manageritem.baylongcoin = false;
                break;
            }

        }
    }

    /// <summary>
    //  khi có item ván trượt
    /// </summary>
    /// <returns></returns>
   public IEnumerator delayfordestroiitemmain()
    {
        if (managerdata.manager.getvan() >0)
        {
            setalowvan();
            UImanager.uimanager.StartCoroutine(UImanager.uimanager.delayslideritem(40,"van"));
            yield return new WaitForSeconds(0);
        }
    }

    public void setalowvan()
    {
        managerdata.manager.savevan(-1); // giảm số ván trong dữ liệu đi 1 cái
        SetVan(true);
        animationPlayer.SetBool("van", true);
        gocquay = transform.eulerAngles;
        playermodol.transform.Translate(0, 0.3f, 0);
    }
    Vector3 gocquay;
    /// <summary>
    /// dừng toàn bộ item
    /// </summary>
    /// <param name="nameitemanimation"> tên của animation cần dừng lại</param>
    /// <param name="nameitem"> tên của item cần dừng lại</param>
    public void stopanimationitem(string nameitemanimation ,string nameitem )
    {
        animationPlayer.SetBool(nameitemanimation, false);
        switch (nameitem)
        {
            case "van":
                playermodol.transform.eulerAngles = gocquay;
                playermodol.transform.Translate(0, -0.8f, 0);
                Manageritem.van = false;
                animationPlayer.SetBool("van", false);
                SetVan(false);
                break;
            case "giay":
                Manageritem.giay = false;
                animationPlayer.SetBool("rungiay", false);
                giayleft.SetActive(false);
                downvan.SetActive(false);
                giayrigh.SetActive(false);
                break;
            case "x2coin":
                Manageritem.x2coin = false;
                break;
            case "jupm":
                Manageritem.baycoin = false;
                break;
            case "jupmtong":
             //   SetFLyLong(false);
                break;
            case "hutcoin":
                magnet.gameObject.SetActive(false);
                magnet1.gameObject.SetActive(false);
                magnet2.gameObject.SetActive(false);
                IKanimation.iklegth = 0;
                Manageritem.hutcoin = false;
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// tính năng của player khi có item(hút coin, x2 coin , nhảy cao gấp đôi)
    /// </summary>
    /// <param name="value"> số s</param>
    /// <param name="nameiteam"> tên iteam</param>
    /// <returns></returns>
    IEnumerator delayfordestroiiteam(int value, string nameiteam)
    {
        UImanager.uimanager.StartCoroutine(UImanager.uimanager.delayslideritem(value, nameiteam));
        yield return new WaitForSeconds(value);
    }

    #endregion




    // input PC
    private void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Muvingright());
        }
        else
             if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(Muvingleft());
        }
        else
             if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Muvingdow());
        }
        else
             if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    #region Các hàm di chuyển
    // nhảy
   public void Jump()
    {

        if (Manageritem.baylongcoin == false&&Manageritem.baycoin == false)
        {
            if (alowjupm)
            {
                animationPlayer.SetBool("cash", false);
                animationPlayer.SetBool("die", false);
                alowjupm = false;
                transform.Translate(0, 0, 0.2f);
                checkpositionjump = transform.position.y;
                Soundmanager.soundmanager.PlaySwipe();
                jupamin();  
                emty.emtyplayer.jump();
                if (Manageritem.giay == false) // nhảy thường
                {
                    rb.velocity = new Vector3(0, 15, 0);
                    Physics.gravity = new Vector3(0, -40F, 0);
                }
                else  
                {
                    float tranformlimzcheckjump = transform.position.y;
                    rb.velocity = new Vector3(0, 27, 0);
                    Physics.gravity = new Vector3(0, -15F, 0);
                    StartCoroutine(delayforjumpdow());
                }
                animationPlayer.SetBool("down", false);
                StartCoroutine(FixJump());
            }
        }

    }

    float checkpositionjump;
    IEnumerator FixJump()
    {
        for (int i = 0; i < 20; i++)
        {
               yield return new WaitForSeconds(0.0001f);
            if (rb.velocity.y>1)
            {
                alowjupm = false;
                break;
            }
            rb.velocity = new Vector3(0, 15, 0);
        }
    }

    float tranformlimzcheckjump;

    /// <summary>
    /// hiệu ứng nhả cho tem giày
    /// </summary>
    /// <returns></returns>
    IEnumerator delayforjumpdow()
    {
        for (int i = 0; i < 200; i++)
        {
            yield return new WaitForSeconds(0.001f);
            if (transform.position.y >= tranformlimzcheckjump+ 7f)
            {
                rb.velocity = Vector3.zero;
                Physics.gravity = new Vector3(0, -9.8F, 0);
                break;
            }
        }
    }
    // cúi từng trường hợp item
  public GameObject downvan;
  public   IEnumerator Muvingdow()
    {
        Soundmanager.soundmanager.PlaySwipe();
        if (Manageritem.baylongcoin == false&&Manageritem.baycoin == false)
        {
            if (Manageritem.giay)
            {
                animationPlayer.SetBool("die", false);

                this.GetComponent<CapsuleCollider>().center = new Vector3(0, -0.45f, 0);
                this.GetComponent<CapsuleCollider>().radius = 0.46f;
                this.GetComponent<CapsuleCollider>().height = 1f;
                if (Manageritem.van==false)
                {
                    animationPlayer.SetBool("nam", true);
                }
                else if (Manageritem.van)
                {
                    SetVan(false);
                    downvan.SetActive(true);
                    animationPlayer.SetBool("downhavevan", true);
                }
                rb.velocity = new Vector3(0, -15, 0);
                yield return new WaitForSeconds(0.5f);
                if (Manageritem.van == false)
                {
                    animationPlayer.SetBool("nam", false);
                    animationPlayer.SetBool("downhavevan", false);

                }
                else if (Manageritem.van)
                {
                    SetVan(true);
                    downvan.SetActive(false);
                    animationPlayer.SetBool("nam", false);
                    animationPlayer.SetBool("downhavevan", false);
                }
            }
            else
            {
                animationPlayer.SetBool("die", false);

                // head.GetComponent<Collider>().enabled = false;
                this.GetComponent<CapsuleCollider>().center = new Vector3(0, -0.45f, 0);
                this.GetComponent<CapsuleCollider>().radius = 0.46f;
                this.GetComponent<CapsuleCollider>().height = 1f;
                if (Manageritem.van == false)
                {
                    animationPlayer.SetBool("nam", true);
                }
                else if (Manageritem.van)
                {
                    downvan.SetActive(true);
                    SetVan(false);
                    animationPlayer.SetBool("downhavevan", true);
                }
                rb.velocity = new Vector3(0, -10, 0);
                yield return new WaitForSeconds(0.5f);
                this.GetComponent<CapsuleCollider>().center = new Vector3(0, -0.08f, 0);
                this.GetComponent<CapsuleCollider>().radius = 0.46f;
                this.GetComponent<CapsuleCollider>().height = 1.77f;

                if (Manageritem.van == false)
                {
                    animationPlayer.SetBool("nam", false);
                    animationPlayer.SetBool("downhavevan", false);
                }
                else if (Manageritem.van)
                {
                    SetVan(true);
                    downvan.SetActive(false);
                    animationPlayer.SetBool("nam", false);
                    animationPlayer.SetBool("downhavevan", false);
                }
            }
        }

    }
    int xx;
    // sang phải
   public IEnumerator Muvingright()
    {
        if (delayleftright && transform.position.x <= -2.5f)
        {
            yield return 0;
        }
        else
        {
            if (speedmuving > 10)
            {
                Soundmanager.soundmanager.PlaySwipe();

                for (int i = 0; i < 1000; i++) //player dừng lại mới cho đi tiếp
                {
                    yield return new WaitForSeconds(0.00001f);
                    if (rb.velocity.x >= -1f && rb.velocity.x <= 1f)
                    {
                        rb.velocity = new Vector3(0, rb.velocity.y, 0);
                        break;
                    }
                    if (Manageritem.baycoin || Manageritem.giay || Manageritem.baylongcoin)
                    {
                        if (transform.position.x == -2.5f || transform.position.x == 2.5f)
                        {
                            rb.velocity = new Vector3(0, rb.velocity.y, 0);
                            break;
                        }
                    }
                }
                if (Manageritem.baycoin == false || Manageritem.baylongcoin == false)
                {
                    transform.Translate(0, 0, 0.2f);
                }
                poinstart = this.transform.position.x;
                while (rb.velocity.x == 0)
                {
                    if (transform.position.y > 3.9f && transform.position.y < 4.3f)
                    {
                        rb.velocity = new Vector3(-mainvectory, 5f, 0);
                    }
                    else if (transform.position.y <= 3.9f)
                    {
                        rb.velocity = new Vector3(-mainvectory, rb.velocity.y, 0);
                    }
                    else if (transform.position.y >= 4.3f)
                    {
                        if (Manageritem.baycoin == false && Manageritem.baylongcoin == false)
                        {
                            rb.velocity = new Vector3(-mainvectory, -3.5f, 0);
                        }
                        if (Manageritem.baycoin || Manageritem.baylongcoin)
                        {
                            Debug.Log("ádgsdgdf");
                            rb.velocity = new Vector3(-mainvectory, 0, 0);
                        }

                    }
                }
                stylemuving = 0;
                StartCoroutine(checktranformforcamfolow("righ"));
                if (Manageritem.van == false)
                {
                    StartCoroutine(jumptoleftorright("amintoleft"));
                }
                else if (Manageritem.van)
                {
                    StartCoroutine(jumptoleftorright("amintoleftvan"));
                }
                lastvectoryx = -mainvectory;
                StartCoroutine(CheckStop());
            }

        }
    }
   
    //  sang trái
   public  IEnumerator Muvingleft()
    {
        if (delayleftright&&transform.position.x>=2.5f)
        {
            yield return 0;
        }
        else
        {
            if (speedmuving > 10)
            {
                Soundmanager.soundmanager.PlaySwipe();

                for (int i = 0; i < 1000; i++)
                {
                    yield return new WaitForSeconds(0.001f);
                    if (rb.velocity.x >= -1f && rb.velocity.x <= 1f)
                    {
                        rb.velocity = new Vector3(0, rb.velocity.y, 0);

                        break;
                    }
                    if (Manageritem.baycoin || Manageritem.giay || Manageritem.baylongcoin)
                    {
                        if (transform.position.x == -2.5f || transform.position.x == 2.5f)
                        {
                            rb.velocity = new Vector3(0, rb.velocity.y, 0);
                            break;
                        }
                    }
                }
                poinstart = this.transform.position.x;
                if (Manageritem.baycoin == false || Manageritem.baylongcoin == false)
                {
                    transform.Translate(0, 0, 0.2f);
                }
                while (rb.velocity.x == 0)
                {
                    if (transform.position.y > 3.9f && transform.position.y < 4.3f)
                    {
                        rb.velocity = new Vector3(mainvectory, 5f, 0);
                    }
                    else if (transform.position.y <= 3.9f)
                    {
                        rb.velocity = new Vector3(mainvectory, rb.velocity.y, 0);
                    }
                    else if (transform.position.y >= 4.3f)
                    {
                        if (Manageritem.baycoin == false && Manageritem.baylongcoin == false)
                        {
                            rb.velocity = new Vector3(mainvectory, -3.5f, 0);
                        }
                        if (Manageritem.baycoin || Manageritem.baylongcoin)
                        {
                            rb.velocity = new Vector3(mainvectory, 0, 0);
                        }

                    }
                }
                stylemuving = 1;

                StartCoroutine(checktranformforcamfolow("left"));
                if (Manageritem.van == false)
                {
                    StartCoroutine(jumptoleftorright("amintoright"));
                }
                else if (Manageritem.van)
                {
                    StartCoroutine(jumptoleftorright("amintorightvan"));
                }
                lastvectoryx = mainvectory;
                StartCoroutine(CheckStop());
            }
        }
       
    }



    /// <summary>
    /// hàm delay set cho animation sang trái hoặc phải
    /// </summary>
    /// <param name="stylemuving"></param>
    /// <returns></returns>
    IEnumerator jumptoleftorright(string stylemuving)
    {
       
        switch (stylemuving)
        {
            case "amintoright":
                animationPlayer.SetBool("muvinftoright", true);
                yield return new WaitForSeconds(0.3f);
                animationPlayer.SetBool("muvinftoright", false);
                break;
            case "amintoleft":
                animationPlayer.SetBool("muvingtolef", true);
                yield return new WaitForSeconds(0.25f);
                animationPlayer.SetBool("muvingtolef", false);
                break;
            case "amintorightvan":
                animationPlayer.SetBool("phaitruot", true);
                yield return new WaitForSeconds(0.4f);
                animationPlayer.SetBool("phaitruot", false);
                break;
            case "amintoleftvan":
                animationPlayer.SetBool("traitruot", true);
                yield return new WaitForSeconds(0.4f);
                animationPlayer.SetBool("traitruot", false);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// hàm delay set cho camera đi theo
    /// </summary>
    /// <param name="stylemuving"></param>
    /// <returns></returns>
    IEnumerator checktranformforcamfolow(string style)
    {
        switch (style)
        {
            case "left":
                for (int i = 0; i < 200; i++)
                {
                    yield return new WaitForSeconds(0.01f);
                    if (transform.position.x >= 1.5f || (transform.position.x > -1.5f && transform.position.x < 0.2f))
                    {
                        Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.delaytofolowleft());
                        break;
                    }
                    if (rb.velocity.x < -1)
                    {
                        break;
                    }
                }
                break;
            case "righ":
                for (int i = 0; i < 200; i++)
                {
                    yield return new WaitForSeconds(0.01f);
                    if (transform.position.x <= -1.5f || (transform.position.x > -0.02f && transform.position.x < 1.5f))
                    {
                        Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.delaytofolowright());
                        break;
                    }
                    if (rb.velocity.x > 1)
                    {
                        break;
                    }
                }
                break;
            default:
                break;
        }
        yield return 0;
    }



    #endregion
    float distince;


    /// <summary>
    /// kiểm tra tọa độ playẻ dừng
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckStop()
    {
        distince = 0;
        for (int i = 0; i < 20; i++)
        {
            if (rb.velocity.x <  1&& rb.velocity.x >-1)
            {
                switch (stylemuving)
                {
                    case 0:
                        rb.velocity = new Vector3(-mainvectory, 0, 0);
                        break;
                    case 1:
                        rb.velocity = new Vector3(mainvectory, 0, 0);
                        break;
                    default:
                        break;
                }
            }
           
            yield return new WaitForSeconds(0.02f);
            transform.position = new Vector3((Mathf.Clamp(transform.position.x, poinstart - 2.5f, poinstart + 2.5f)), transform.position.y, transform.position.z);
            distince = Vector3.Distance(new Vector3(poinstart,0,0),new Vector3(transform.position.x,0,0));
            if (distince >= 2.5f)
            {
                rb.velocity = Vector3.zero;
                StartCoroutine(backtotruposison());
                break;
            }
            if (touchtheship)
            {
                touchtheship = false;
                break;
            }
        }
    }
    // kiểm tra player có đứng trên tàu  mà sau 1 time tọa đọ nó giảm xuống nhỏ hơn thì cho camera xuống
    IEnumerator Checkcameradown()
    {
        if (transform.position.y >= 3.44f)
        {
            for (int i = 0; i < 100; i++)
            {
                yield return new WaitForSeconds(0.01f);
                if (transform.position.y < positionchekdowcameray - 0.5f)
                {
                    Camerafolow.camfolowplayer.StartCoroutine(Camerafolow.camfolowplayer.delaycameraup(-0.1f));
                    break;
                }
            }
        }
        else
        {
            yield return new WaitForSeconds(0);

        }

    }


    /// <summary>
    /// kiểm tra chết theo tranform của checkdie
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckDie()
    {
        //for (int i = 0; i < 50; i++)
        //{
           yield return new WaitForSeconds(0.01f);
        //    if (transform.position.z < checkdie.transform.position.z - 2f)
        //    {
        //        if (isplay == false)
        //        {
        //            break;
        //        }
        //        if (Manageritem.van)
        //        {
        //            destroigameojectwenhaheitemvan = true;
        //            checkdie.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //            animationPlayer.SetBool("van", false);
        //            playermodol.transform.eulerAngles = gocquay;
        //            van.SetActive(false);
        //            Manageritem.van = false;
        //            break;
        //        }

        //        else if (Manageritem.van == false)
        //        {
        //            animationPlayer.SetBool("die", true);
        //            UImanager.uimanager.Lost();
        //            gamelost();
        //            break;
        //        }
        //    }
        //}
        //yield return new WaitForSeconds(0.2f);
        //destroigameojectwenhaheitemvan = false;
    }


    /// <summary>
    /// thua
    /// </summary>
    public void gamelost()
    {
        if (animationPlayer != null)
        {
          animationPlayer.SetBool("die", true);
        }
        isplay = false;
    }
    public static bool destroigameojectwenhaheitemvan;
    float tranformformuvingwendie;
    float muvingsecon = 50;
    bool touchtheship; // kiểm tra chạm vào cạnh vạt cản
    /// <summary>
    /// đưa player về map tiếp theo khi chết tải lại toàn bộ tọa độ của map và player về đúng vị trí xuất phát
    /// tái sử dụng lại toàn bộ hệ thống map và vật cản
    /// </summary>
    public IEnumerator playagain(int vlalue)
    {
        Time.timeScale = 1f;
        animationPlayer.SetBool("again", false);
        animationPlayer.SetBool("play", true);
        animationPlayer.SetBool("die", false);
        if (transform.position.z < 100)
        {
            tranformformuvingwendie = Vector3.Distance(transform.position, new Vector3(0, 0, 100)) + 40;
            muvingsecon = 50;
        }
        else if (transform.position.z >= 100)
        {
            tranformformuvingwendie = ((Makesupway.checkshowx) - transform.position.z) + 40;
            muvingsecon = 50;
        }
         Makesupway.makemap.StartCoroutine(Makesupway.makemap.MuvingbackAllemtyWendie());
        Makesupway.backtobehigh = -1;
        posisonanimation.x = 0;
        posisonanimation.y = 0.2f;
        transform.position = new Vector3(0, 0.8f, transform.position.z);
        posisonanimation = transform.position;
        posisonanimation.y = posisonanimation.y - 1;
        checkdie.transform.position = transform.position; // đư check đia về tọa độ của player
        playermodol.transform.position = posisonanimation;
        rotationanimation.y = 0;
        playermodol.transform.eulerAngles = rotationanimation;
        playermodol.GetComponent<Animator>().applyRootMotion = false;
        if (Makesupway.checkshowx >transform.position.z +30)
        {
            Makesupway.makemap.randumtheemty();
        }
        OurtCut();
        transform.position = new Vector3(0, transform.position.y + 1, transform.position.z);
        Makesupway.backtobehigh = 1;
        playermodol.GetComponent<Animator>().applyRootMotion = false;
        yield return new WaitForSeconds(0.5f);
        rb.useGravity = true;
        gameObject.GetComponent<Collider>().enabled = true;
        head.GetComponent<Collider>().enabled = true;
        if (vlalue == 1)
        {
            savethetranformcheckformuvingvoin = savethetranformcheckformuvingvoin + tranformformuvingwendie + 50;
        }
        if (vlalue ==0)
        {
            savethetranformcheckformuvingvoin = transform.position.z; 
        }
        emty.emtyplayer.Agan();
        playermodol.transform.eulerAngles = rotationanimation; 
        animationPlayer.applyRootMotion = false;
        posisonanimation.y = 0;
        posisonanimation.x = 0;
        touchtheship = false;
    }
    float savethetranformcheckformuvingvoin; // lưu lại tọa độ để tính điểm đi chuyển
    /// <summary>
    /// load lại khi vào màn hiện tại kh i chọn khóa hồi sinh
    /// </summary>
    public void clicontheplayagainseleckey()
    {
       // isplay = true;
        animationPlayer.SetBool("play", true);
        animationPlayer.SetBool("die", false);
        animationPlayer.SetBool("again", false);
    }

  
    /// <summary>
    /// load
    /// liên tực fix lỗi player đứng đang di chuyển vẫn 
    /// nằm 1 chỗ
    /// </summary>
    public void fixanimation()
    {
        animationPlayer.SetBool("again", true);
        try
        {
            animationPlayer.SetBool("again", true);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public static bool isCatch;
   // AvatarIKHint bị bắt
    public void Inthecatch()
    {
        playermodol.transform.eulerAngles = new Vector3(0,180,0);
        playermodol.transform.position = new Vector3(transform.position.x-0.5f, transform.position.y-1, transform.position.z-0.6f);
    }

    /// <summary>
    /// chạy nagy lập tức khi play
    /// </summary>
    public void muvingtomodelonthestart()
    {
        Vector3 betten = new Vector3(0,0.2f,-3.3f);
        playermodol.transform.LookAt(betten);
        StartCoroutine(delaystop());
        animationPlayer.applyRootMotion = false;
        animationPlayer.SetBool("play", true);

    }
    IEnumerator delaystop()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
        }
    }
    public static bool isstartnow = false;
    
    /// <summary>
    ///  bị bắt
    /// </summary>
    /// <returns></returns>
    public IEnumerator OntheCasth()
    {
        animationPlayer.SetBool("cash", true);
      yield return new WaitForSeconds(0f);

    }

    // thoát khỏi bị bắt
    public void OurtCut()
    {
        animationPlayer.SetBool("cash", false);
        //StartCoroutine(delayourtcut());
    }

    public IEnumerator delayourtcut()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.02f);
            if (isplay == false)
            {
                break;
            }
            animationPlayer.SetBool("cut", false);
        }
    }

    public void loadinganimation()
    {
        animationPlayer.enabled = true;
        playagainanimation();
        IkEmty.IKMAGNET.sEttaget();
        Start();
        Playermuving.player.loaddatavan();
        Playermuving.player.setTranformitem();
        StartCoroutine(delayFixposition());
    }


    IEnumerator delayFixposition()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.02f);
            playagainanimation();

        }
    }
    /// <summary>
    /// hủy toàn bộ item
    /// </summary>
    public void ExitAllItem()
    {
        IkEmty.iklegth1 = 0;
        IkEmty.iklegth = 0;
        IKanimation.iklegth = 0;
        magnet.SetActive(false);
        magnet1.SetActive(false);
        magnet2.SetActive(false);
        baycaodai.SetActive(false);
        baycao.SetActive(false);
        giayleft.SetActive(false);
        giayrigh.SetActive(false);
        SetVan(false);
    }
    public GameObject magnet; // năm châm hút
    public GameObject magnet1; // năm châm hút
    public GameObject magnet2; // năm châm hút

    /// <summary>
    /// chêtsss cmnr .............
    /// </summary>
    void Chết_Rồi()
    {
        IkEmty.iklegth1 = 0;
        IkEmty.iklegth = 0;
        IKanimation.iklegth = 0;
        isplay = false;
    }

    public GameObject itemeffct;
    public IEnumerator EffectWenHavaeItem()
    {
        itemeffct.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        itemeffct.SetActive(false);
    }
    /// <summary>
    /// tạm dừng chơi
    /// </summary>
    public void PauseGame()
    {
        speedmuving = 0;
     
       // Manageritem.baylongcoin = true;

        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        animationPlayer.enabled = false;
        emty.emtyplayer.OnthePause();
    }
    /// <summary>
    /// trở về chơi lại
    /// </summary>
    public void ExitPause()
    {
        emty.emtyplayer.OntheResume();
        rb.velocity = Vector3.zero;
        
        animationPlayer.enabled = true;
        if (Manageritem.baylongcoin == false  )
        {
            rb.useGravity = true;
            speedmuving = 15;
        }
        else if (Manageritem.baylongcoin )
        {
            rb.useGravity = false;
            speedmuving = 28;
        }
    }

}