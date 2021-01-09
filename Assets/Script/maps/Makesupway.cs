using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// class chính tạo toàn bộ hệ thống map -  iteam và vật cản , randum vật cản , map
public class Makesupway : MonoBehaviour {

    // tạo map
    public GameObject makesupway; //  đường ray
    public GameObject makesupwaymap1; //  map 1
    public GameObject makesupwaymap2; //  map 2
    public GameObject makesupwaymap3; //  map 3
    enum stylecreate { left, betten, righ }
    stylecreate newstyle;
    // tạo vật cản
    private GameObject makeemtyshipdie; //  toa tàu trung gian
    public GameObject makeemtyshipdie1; //  toa tàu 2
    public GameObject makeemtyshipdie2; //  toa tàu 2
    public GameObject makeemtyshipdiemuving; //  toa tàu 1 chạy lao về player
    public GameObject makeemtyship; // tạo toa tàu có cát
    public GameObject makeembars_smore; // thanh chắn thấp
    public GameObject makeembars_big; // thanh chắn cao
    public GameObject makeembars_biger; // thanh chắn lớn
    public GameObject makeembridge; // cầu chân giữa
    public GameObject makeembridgeleft; // cầu chân phải
    public GameObject makeembridgerigh; // cầu chân trái
    public GameObject makeembridgebehig; // cầu chân 2 bên
    public GameObject powerpoles; // cột điện
    Vector3 locationemty = new Vector3(0, 0, 0); // lưu vị trí tạo vật cản
    // tạo item
    public GameObject makeitemcoin; //  coin chính
    public GameObject makeitemhutcoin; //  hút coin
    public GameObject makeitembay; //  bay 1 đoạn
    public GameObject makeitembaylong; //  bay 1 đoạn dài
    public GameObject makeitemnhay; // giày nhả cao 
    public GameObject makeitemx2coin; // x2  coin
    public GameObject makeitemvan; // ván trượt
    public GameObject makeitembox; // hôp quà
    public GameObject makeitemkey; // chìa khóa
    GameObject bettwen;
    int randummap;
    int randumemty;
    Vector3 location = new Vector3(0,0,0);
    enum stylecreatecoin { line, backtolef, backtoright, up } 
    enum stylecreatecoinposisition { left, bettwen, right, leftup, betwenup, rightup ,foritemfle} 
    public enum createitemposition { lef, righ, betten, lefup, righup, bettenup, jumpleft, jupmrifht, jumpbetten, jumpupleft, jumpupright, jumpupbetten }
    // lưu các map tái sử dụng
    List<GameObject> map = new List<GameObject>();
    List<GameObject> map1 = new List<GameObject>();
    List<GameObject> map2 = new List<GameObject>();
    List<GameObject> map21 = new List<GameObject>();
    List<GameObject> map22 = new List<GameObject>();
    List<GameObject> supwaylist = new List<GameObject>();
    // lưu từng đoạn vật cản
    private List<GameObject> mapemty1 = new List<GameObject>();
    private List<GameObject> mapemty2 = new List<GameObject>();
    private List<GameObject> mapemty3 = new List<GameObject>();
    private List<GameObject> mapemty4 = new List<GameObject>();
    private List<GameObject> mapemty5 = new List<GameObject>();
    private List<GameObject> mapemty6 = new List<GameObject>();
    private List<GameObject> mapemty7 = new List<GameObject>();
    private List<GameObject> mapemty8 = new List<GameObject>();
    private List<GameObject> mapemty9 = new List<GameObject>();
    private List<GameObject> mapemty10 = new List<GameObject>();
    private List<GameObject> mapemty11 = new List<GameObject>();
    private List<GameObject> mapemty12 = new List<GameObject>();
    private List<GameObject> mapemty13 = new List<GameObject>();
    private List<GameObject> mapemty14 = new List<GameObject>();
    private List<GameObject> mapemty15 = new List<GameObject>();
    private List<GameObject> mapemty16 = new List<GameObject>();
    private List<GameObject> mapemty17 = new List<GameObject>();
    private List<GameObject> mapemty18 = new List<GameObject>();
    private List<GameObject> mapemty19 = new List<GameObject>();
    private List<GameObject> mapemty20 = new List<GameObject>();
    List<GameObject> mapmain = new List<GameObject>();
    public GameObject main, m1, m2, m3, m4, m5;
    public static Makesupway makemap;
    public GameObject MapHowToPlay;
    public GameObject Map4;
    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;
    public GameObject Map6hamcho;
    public GameObject Map42;
    public GameObject Map5;
    // tạo map randum
    int valueofmap;
  public static  bool isnewgame = false; // kieemr tra laanf chowi dâud tieen
    // Use this for initialization
    void Start () {
        //  Time.timeScale = 0.2f;

        Getthac();
        StartCoroutine(CheckshowGameOject(0));
        makemap = this;
        valueofmap = 0;
        createmainmap();
        checkshowx = 100;
        AlowlcreatecoinforFly = true;
        if (PlayerPrefs.HasKey("hd") == false)
        {
            isnewgame = true;
            if (isnewgame)
            {
                MapHowToPlay.SetActive(true);
            }

        }
    }
    float distinct = 0;
    float distinctplayer = 30;
    public GameObject createdow;
    float addlocation;
    /// <summary>
    /// tạo map  khi chạy vào game
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    IEnumerator CheckshowGameOject(int value)
    {
        int m = 11;
        for (int i = 0; i < 5; i++)
        {
            value = i;
            switch (value)
            {
                case 0:
                    bettwen = makesupwaymap1;
                    break;
                case 1:
                    bettwen = makesupwaymap2;
                    break;
                case 2:
                    bettwen = makesupwaymap3;
                    break;
                case 3:
                    bettwen = makesupwaymap3;
                    break;
                case 4:
                    bettwen = makesupwaymap3;
                    break;
                default:
                    break;
            }
            if (i>=2)
            {
                m = 3;
            }
            for (int j = 1; j < m; j++)
            {
                yield return new WaitForSeconds(0.01f);

                if (makesupway.gameObject != null)
                {
                    switch (value)
                    {
                        case 0:
                            if (i==0&& Map1.transform.position.z <0)
                            {
                                Map1.SetActive(true);
                                Map1.transform.position = new Vector3(0, 0, location.z);
                            }
                            break;
                        case 1:
                            if (i == 1 && Map2.transform.position.z < 0)
                            {
                                Map2.SetActive(true);
                                Map2.transform.position = new Vector3(0, 0, location.z);
                            }
                            
                            break;
                        case 2:
                            map2.Add(Instantiate(bettwen, location, transform.rotation) as GameObject);
                            break;
                        case 3:
                            map21.Add(Instantiate(bettwen, location, transform.rotation) as GameObject);
                            break;
                        case 4:
                            map22.Add(Instantiate(bettwen, location, transform.rotation) as GameObject);
                            break;
                        default:
                            break;
                    }
                    location.x = 0;
                    location.y = 0;
                    if (m!=3)
                    {
                        location.z = addlocation + 8 * j;
                    }
                    if (m==3)
                    {
                        location.z = addlocation + 40*j;
                    }
                }
            }
            if (i == 0)
            {
                StartCoroutine(emty4(location.z - 1000));
                yield return new WaitForSeconds(0.5f);
            }
            addlocation = location.z;
        }
        yield return new WaitForSeconds(3f);
        Enable();
   
        int randumvcc = Random.Range(0, 13);
        for (int j = 0; j < 2; j++)
        {
            while (lasrandum == randumvcc)
            {
                randumvcc = Random.Range(0, 13);
            }
            lasrandum = randumvcc;
            if (isnewgame == true)
            {
                if (j == 0)
                {
                    continue;
                }

                distinctplayer += 65;
            }
            switch (randumvcc)
            {
                case 0:
                    RandumMapInThestartGame(mapemty4,4);
                    break;
                case 1:
                    RandumMapInThestartGame(mapemty2, 2);
                    break;
                case 2:
                    RandumMapInThestartGame(mapemty3, 3);
                    break;
                case 3:
                    RandumMapInThestartGame(mapemty1, 1);
                    break;
                case 4:
                    RandumMapInThestartGame(mapemty5, 5);
                    break;
                case 5:
                    RandumMapInThestartGame(mapemty6, 6);
                    break;
                case 6:
                    RandumMapInThestartGame(mapemty7, 7);
                    break;
                case 7:
                    RandumMapInThestartGame(mapemty8, 8);
                    break;
                case 8:
                    RandumMapInThestartGame(mapemty9, 9);
                    break;
                case 9:
                    RandumMapInThestartGame(mapemty10, 10);
                    break;
                case 10:
                    RandumMapInThestartGame(mapemty11, 11);
                    break;
                case 11:
                    RandumMapInThestartGame(mapemty12, 12);
                    break;
                case 12:
                    RandumMapInThestartGame(mapemty13, 13);
                    break;
                default:
                    break;
            }
            distinctplayer += 80; // the main change stop core
        }

    }
    void RandumMapInThestartGame(List<GameObject> map , int value)
    {
        for (int i = 0; i < map.Count; i++)
        {
            map[i].gameObject.SetActive(true);
            if (i == 0)
            {
                distinct = Vector3.Distance(map[i].transform.position, transform.position) + distinctplayer;
            }
            map[i].transform.Translate(new Vector3(0, 0, distinct));
            if (i == 0)
            {
                StartCoroutine(Createcoinformap(value, map[i].transform.position.z));
            }
        }
    }
    /// <summary>
    /// load lại map khi chơi lại
    /// </summary>
    /// <returns></returns>
    public IEnumerator playagain()
    {
        yield return new WaitForSeconds(0);
    }

    int notshow;
    /// <summary>
    /// map chính của player khi khởi tạo ban đầu
    /// </summary>
    /// <param name="tranformz"></param>
    /// <returns></returns>
    void createmainmap()
    {
        mapmain.Add(main);
        mapmain.Add(m1);
        mapmain.Add(m2);
        mapmain.Add(m3);
        mapmain.Add(m4);
        mapmain.Add(m5);
    }
    /// <summary>
    /// tái sử dụng các đoạn map và vật cản
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    IEnumerator randumallmap(int value)
    {
        switch (valueofmap)
        {
            case 0:
                Map1.SetActive(true);
                Map1.transform.position = new Vector3(0, 0, location.z);
                location.z += 80;
                break;
            case 1:
                Map2.SetActive(true);
                Map2.transform.position = new Vector3(0, 0, location.z);
                location.z += 80;
                break;
            case 2:
                if (map2[0].gameObject.transform.position.z < checkshow-80)
                {
                    for (int i = 0; i < map2.Count; i++)
                    {
                        map2[i].SetActive(true);

                        map2[i].transform.position = new Vector3(0, 0, location.z);
                        yield return new WaitForSeconds(0.01f);
                        location.z += 40;
                    }
                }
                break;
            case 3:
                if (map21[0].gameObject.transform.position.z < checkshow - 80)
                {
                    for (int i = 0; i < map21.Count; i++)
                    {
                        map21[i].gameObject.SetActive(true);

                        map21[i].transform.position = new Vector3(0, 0, location.z);
                        yield return new WaitForSeconds(0.01f);
                        location.z += 40;
                    }
                }
                break;
            case 4:
                if (map22[0].gameObject.transform.position.z < checkshow - 80)
                {
                    for (int i = 0; i < map22.Count; i++)
                    {
                        map22[i].gameObject.SetActive(true);

                        map22[i].transform.position = new Vector3(0, 0, location.z);
                        yield return new WaitForSeconds(0.01f);
                        location.z += 40;
                    }
                }
                break;
            case 5:
                if (Map6hamcho.gameObject.transform.position.z < checkshow - 80)
                {
                    Map6hamcho.SetActive(true);

                    Map6hamcho.transform.position = new Vector3(0, 0, location.z);
                    Map6hamcho.SetActive(true);
                    location.z += 80;
                }

                break;
            case 6:
               

                if (Map5.gameObject.transform.position.z < checkshow-80)
                {
                    Map5.SetActive(true);

                    Map5.transform.position = new Vector3(0, 0, location.z);
                    Map5.SetActive(true);
                    location.z += 80;
                }
                   
                break;
            case 7:
                int valuemap = Random.Range(0,1);
                switch (valuemap)
                {
                    case 0:
                        if (Map4.gameObject.transform.position.z < checkshow - 80)
                        {
                            Map4.transform.position = new Vector3(0, 0, location.z);
                            Map4.SetActive(true);
                            location.z += 80;
                        }
                        Getthac();
                        break;
                    default:
                        break;
                }
              
                break;
            default:
                break;
        }
       
        valueofmap++;
        notshow++;
        randumtheemty();
        
        if (notshow == 5)
        {
            notshow = 0;
        }
        if (valueofmap == 8)
        {
            valueofmap = 0;
        }
        
    }
    private void Hidemap(List<GameObject> map)
    {
        for (int i = 0; i < map.Count; i++)
        {
            map[i].SetActive(true);
        }
    }
    public GameObject tha1, th2, th3;

    /// <summary>
    /// randum vật cản trong thác nước
    /// </summary>
  public void Getthac()
    {
        int randum = Random.Range(0,3);
        switch (randum)
        {
            case 0:
                tha1.SetActive(true);
                th2.SetActive(false);
                th3.SetActive(false);
                break;
            case 1:
                tha1.SetActive(false);
                th2.SetActive(true);
                th3.SetActive(false);
                break;
            case 2:
                tha1.SetActive(false);
                th2.SetActive(false);
                th3.SetActive(true);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// hàm randum các emty
    /// </summary>
   public  void randumtheemty()
    {
        if ((checkshow<Map4.transform.position.z+10&& checkshow> Map4.transform.position.z-120) ) // khong cho hiện  vật cản tong thác nước
        {
            Debug.Log("");
            Getthac();
            return;
        }
        if (Manageritem.baylongcoin)
        {
            if (coinend!= null)
            {
                if (coinend.transform.position.z-120 >Playermuving.player.transform.position.z)
                {
                    return;
                }
            }
        }
        while (Dontrandum)
        {

        }
        if (call)
        {
            call = false;
            StartCoroutine(whatcallbackmap());
            int nowrandum = Random.Range(0, 15);
            while (lasrandum == nowrandum)
            {
                nowrandum = Random.Range(0, 15);
            }


            lasrandum = nowrandum;
            switch (nowrandum)
            {
                case 0:
                    StartCoroutine(Randummap(mapemty4, 4));
                    break;
                case 1:
                    StartCoroutine(Randummap(mapemty2, 2));

                    break;
                case 2:
                    StartCoroutine(Randummap(mapemty3, 3));
                    break;
                case 3:
                    StartCoroutine(Randummap(mapemty1, 1));
                    break;
                case 4:
                    StartCoroutine(Randummap(mapemty5, 5));
                    break;
                case 5:
                    StartCoroutine(Randummap(mapemty6, 6));
                    break;
                case 6:
                    StartCoroutine(Randummap(mapemty7, 7));
                    break;
                case 7:
                     StartCoroutine(Randummap(mapemty8, 8));
                    break;
                case 8:
                    StartCoroutine(Randummap(mapemty9, 8));
                    break;
                case 9:
                    StartCoroutine(Randummap(mapemty10, 10));
                    break;
                case 10:
                    StartCoroutine(Randummap(mapemty11, 11));
                    break;
                case 11:
                    StartCoroutine(Randummap(mapemty12, 12));
                    break;
                case 12:
                    StartCoroutine(Randummap(mapemty13, 13));
                    break;
                case 13:
                    StartCoroutine(Randummap(mapemty14, 14));
                    break;
                case 14:
                    StartCoroutine(Randummap(mapemty15, 15));
                    break;
                case 15:
                    StartCoroutine(Randummap(mapemty17, 17));
                    break;
                case 16:
                    StartCoroutine(Randummap(mapemty17, 17));
                    break;
                default:
                    break;
            }
        }
      
    }
    bool call = true;
    IEnumerator whatcallbackmap()
    {
        yield return new WaitForSeconds(0.5f);
        call = true;
    }
    int lasrandum =0;  
    #region hệ thống tạo randumcacs đoạn vật cản
    float DistanceTranslate = 0; // khoảng cách cần đi
    public static float backtobehigh = 1;
 
    IEnumerator Randummap(List<GameObject> list,int mapformake)
    {
        for (int i = 0; i < list.Count; i++)
        {
            yield return new WaitForSeconds(0);
            list[i].gameObject.SetActive(true);

            if (i == 0)
            {
                Vector3 vt3 = new Vector3(0, 0, checkshowx + 16);
                DistanceTranslate = Vector3.Distance(list[i].transform.position, vt3);
            }
            list[i].transform.Translate(new Vector3(0, 0, DistanceTranslate * backtobehigh));
            if (i == 0)
            {
                if (Manageritem.baylongcoin == false)
                {
                    StartCoroutine(Createcoinformap(mapformake, list[i].transform.position.z));
                }
            }
        }
    }
    #endregion

    #region create randum emty
    Vector3 loationback = new Vector3(0,0,0);
    float delayy = 0;
    /// <summary>
    /// tạo map hưỡng dẫn chơi cho lần đầu tiên
    /// </summary>
    /// <param name="tranformz"></param>
    /// <returns></returns>
    IEnumerator emtyforhowtoplay(float tranformz)
    {
        yield return new WaitForSeconds(0);
        for (int i = 0; i < 20; i++)
        {
            loationback.z = tranformz + 8 * i;
            yield return new WaitForSeconds(0.01f);
            createemty("makeemtyshipdie", stylecreate.left, "mapemty1");
        }
    }
    IEnumerator emty1(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
               // StartCoroutine(Createcoinformap(1, locationemty.z));
                //createemty("makeembars_big", stylecreate.left, "mapemty3");
            }
            if (i<4)
            {
                createemty("makeemtyshipdie", stylecreate.left, "mapemty1");
                if (i==2)
                {
                    createemty("makeemtyshipdie", stylecreate.betten, "mapemty1");
                    createemty("makeembars_big", stylecreate.righ, "mapemty1");
                }
            }
            if (i==4)
            {
                createemty("makeembars_big", stylecreate.left, "mapemty1");
                createemty("makeembars_smore", stylecreate.righ, "mapemty1");
                createemty("makeembars_big", stylecreate.betten, "mapemty1");
            }
            if (i==6)
            {
                createemty("makeembars_big", stylecreate.left, "mapemty1");
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty1");
                createemty("makeemtyship", stylecreate.righ, "mapemty1");
            }
            if (i>=7 &&i<9)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty1");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty1");
            }

        }
        StartCoroutine(emty5(location.z-500));
    }
    IEnumerator emty2(float ztranform)
    {
        yield return new WaitForSeconds(0);
        for (int i = 1; i < 10; i++)
        {
            locationemty.z = ztranform + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i < 4)
            {
                    createemty("makeemtyshipdie", stylecreate.left, "mapemty2");
                if (i == 3)
                {
                    createemty("makeembars_big", stylecreate.betten, "mapemty2");
                }
            }
            if (i > 4 && i < 10)
            {
                if (i == 7 || i == 9)
                {
                    createemty("makeemtyshipdiemuving", stylecreate.betten, "mapemty2");
                    createemty("makeemtyshipdiemuving", stylecreate.betten, "mapemty2");
                }
                if (makeemtyshipdie.gameObject != null)
                {
                    createemty("makeemtyshipdie", stylecreate.righ, "mapemty2");

                }
                if (i == 5)
                {
                    createemty("makeembars_big", stylecreate.betten, "mapemty2");
                }
            }
        }
        StartCoroutine(emty3(location.z - 500));
    }
    IEnumerator emty3(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i==1)
            {
                createemty("makeembars_big", stylecreate.left, "mapemty3");
                createemty("makeembars_big", stylecreate.righ, "mapemty3");

            }
            if (i>=1&&i<=4)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty3");
                if (i== 3)
                {
                    createemty("makeembars_biger", stylecreate.righ, "mapemty3");

                    createemty("makeemtyship", stylecreate.left, "mapemty3");
                } 
            }
            if (i<=6&&i>=4)
            {
                createemty("makeemtyshipdie", stylecreate.left, "mapemty3");
            }
            if (i== 6)
            {
                createemty("makeemtyship", stylecreate.betten, "mapemty3");
            }
            if (i>6&&i<9)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty3");
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty3");
            }
        }
       StartCoroutine(emty1(location.z-500));
    }
    IEnumerator emty4(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i==1)
            {
               // StartCoroutine(Createcoinformap(4, locationemty.z+25));
                createemty("makeemtyshipdie", stylecreate.left, "mapemty4");
                createemty("makeemtyship", stylecreate.betten, "mapemty4");
            }
            if (i==2)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty4");
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty4");
                createemty("makeemtyshipdie", stylecreate.left, "mapemty4");
            }
            if (i>=3&&i<9)
            {
                if (i==4)
                {
                   // StartCoroutine(Createcoinformap(4, locationemty.z));
                    continue;
                }
                if (i==6)
                {
                    createemty("makeemtyship", stylecreate.betten, "mapemty4");
                    StartCoroutine(createallitem(locationemty.z-15,createitemposition.jumpupbetten));
                    continue;
                }
                if (i==5)
                {
                    createemty("makeemtyshipdie", stylecreate.betten, "mapemty4");
                    createemty("makeemtyshipdie", stylecreate.righ, "mapemty4");
                    continue;
                }
                createemty("makeemtyshipdie", stylecreate.left, "mapemty4");
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty4");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty4");
            }
        }
        StartCoroutine(emty2(location.z-500));
    }
    IEnumerator emty5(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
               // StartCoroutine(Createcoinformap(5, locationemty.z));
                createemty("makeembars_big", stylecreate.left, "mapemty5");
            }
            if (i == 4)
            {
                createemty("makeembars_big", stylecreate.left, "mapemty5");
                createemty("makeembars_big", stylecreate.betten, "mapemty5");
                createemty("makeembars_big", stylecreate.righ, "mapemty5");

            }
            if (i == 5)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty5");
                createemty("makeembars_biger", stylecreate.left, "mapemty5");
                createemty("makeembars_smore", stylecreate.righ, "mapemty5");
            }
            if (i == 2)
            {
                createemty("makeembars_biger", stylecreate.righ, "mapemty5");
            }
            if (i == 6)
            {
                //createemty("makeembars_smore", stylecreate.righ, "mapemty5");
                //createemty("makeembars_smore", stylecreate.left, "mapemty5");
                //createemty("makeembars_smore", stylecreate.betten, "mapemty5");
            }
            if (i == 8)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty5");
                createemty("makeembars_biger", stylecreate.left, "mapemty5");
                createemty("makeembars_smore", stylecreate.righ, "mapemty5");
            }
        }
        StartCoroutine(emty6(location.z-500));
    }
    IEnumerator emty6(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
              //  StartCoroutine(Createcoinformap(6, locationemty.z));
            }
            if (i < 9)
            {
                if (i == 1 || i == 3 || i == 6)
                {
                    createemty("makeemtyshipdie", stylecreate.betten, "mapemty6");
                    createemty("makeemtyship", stylecreate.left, "mapemty6");
                    createemty("makeemtyship", stylecreate.righ, "mapemty6");
                    continue;
                }
                if (i == 5)
                {
                    continue;

                }
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty6");
                createemty("makeemtyshipdie", stylecreate.left, "mapemty6");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty6");
            }
        }
        StartCoroutine(emty7(location.z - 500));

    }
    IEnumerator emty7(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
                createemty("makeembars_smore", stylecreate.betten, "mapemty7");
             //   StartCoroutine(Createcoinformap(7, locationemty.z));

            }
            if (i == 2)
            {
                createemty("makeembridge", stylecreate.betten, "mapemty7");
            }
            if (i == 4)
            {
                createemty("powerpoles", stylecreate.left, "mapemty7");
                createemty("powerpoles", stylecreate.righ, "mapemty7");
            }
            if (i == 9)
            {
                createemty("makeemtyshipdiemuving", stylecreate.betten, "mapemty7");
            }
            if (i == 8)
            {
                createemty("makeemtyshipdiemuving", stylecreate.left, "mapemty7");
            }

        }


        StartCoroutine(emty8(location.z - 500));

    }
    IEnumerator emty8(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
                createemty("makeembars_smore", stylecreate.betten, "mapemty8");
               // StartCoroutine(Createcoinformap(8, locationemty.z));

            }
            if (i == 2)
            {
                createemty("powerpoles", stylecreate.left, "mapemty8");
                createemty("powerpoles", stylecreate.righ, "mapemty8");
            }
            if (i == 7)
            {
                createemty("makeembridgerigh", stylecreate.betten, "mapemty8");
            }


        }
        StartCoroutine(emty9(location.z - 500));

    }
    IEnumerator emty9(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
                createemty("makeembars_smore", stylecreate.betten, "mapemty9");
                createemty("powerpoles", stylecreate.righ, "mapemty9");
                //StartCoroutine(Createcoinformap(9, locationemty.z));

            }
            if (i == 2)
            {
                createemty("makeemtyshipdie", stylecreate.left, "mapemty9");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty9");
            }
            if (i == 5)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty9");

            }
            if (i == 3)
            {
                createemty("makeembars_biger", stylecreate.betten, "mapemty9");
            }
            if (i == 7)
            {
                createemty("makeembridgeleft", stylecreate.betten, "mapemty9");

            }

        }
        StartCoroutine(emty10(location.z - 500));

    }
    IEnumerator emty10(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
                createemty("makeembars_smore", stylecreate.betten, "mapemty10");
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty10");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty10");
                createemty("makeembars_smore", stylecreate.left, "mapemty10");
                //StartCoroutine(Createcoinformap(10, locationemty.z));

            }
            if (i == 3)
            {
                createemty("makeemtyshipdie", stylecreate.left, "mapemty10");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty10");
                createemty("makeembars_biger", stylecreate.betten, "mapemty10");

            }
            if (i == 8)
            {
                createemty("makeembridge", stylecreate.betten, "mapemty10");

            }
            if (i == 7)
            {
                createemty("makeembars_smore", stylecreate.betten, "mapemty10");

            }
            if (i == 5)
            {
                createemty("powerpoles", stylecreate.left, "mapemty10");
                createemty("powerpoles", stylecreate.righ, "mapemty10");

            }

        }
        StartCoroutine(emty11(location.z - 500));
    }
    IEnumerator emty11(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
               // StartCoroutine(Createcoinformap(11, locationemty.z));
                createemty("makeembars_smore", stylecreate.betten, "mapemty11");
                createemty("makeembars_smore", stylecreate.righ, "mapemty11");
                createemty("makeembars_smore", stylecreate.left, "mapemty11");
            }
            if (i == 2)
            {
                createemty("makeembars_big", stylecreate.betten, "mapemty11");
                createemty("makeembars_big", stylecreate.left, "mapemty11");
            }
            if (i == 3)
            {
                createemty("makeembars_biger", stylecreate.righ, "mapemty11");
                createemty("makeembars_biger", stylecreate.left, "mapemty11");
            }
            if (i == 4)
            {
                createemty("makeembars_biger", stylecreate.righ, "mapemty11");
                createemty("makeembars_biger", stylecreate.left, "mapemty11");
            }
            if (i == 5)
            {
                createemty("makeembars_big", stylecreate.betten, "mapemty11");
                createemty("makeembars_biger", stylecreate.left, "mapemty11");
            }
            if (i == 6)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty11");
                createemty("makeemtyshipdie", stylecreate.left, "mapemty11");
            }
            if (i == 7)
            {
                createemty("makeembars_smore", stylecreate.righ, "mapemty11");
            }
            if (i == 8)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty11");
                createemty("makeembars_biger", stylecreate.betten, "mapemty11");
            }
        }
        StartCoroutine(emty12(location.z - 500));
    }
    IEnumerator emty12(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
               // StartCoroutine(Createcoinformap(12, locationemty.z));
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty12");
                createemty("makeemtyshipdie", stylecreate.left, "mapemty12");
                createemty("makeembars_smore", stylecreate.betten, "mapemty12");
            }
            if (i == 2)
            {
                //  createemty("powerpoles", stylecreate.betten, "mapemty12");
            }
            if (i == 3)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty12");
                createemty("powerpoles", stylecreate.left, "mapemty12");
            }
            if (i == 4)
            {
                createemty("powerpoles", stylecreate.righ, "mapemty12");
            }
            if (i == 5)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty12");
                createemty("makeembars_smore", stylecreate.betten, "mapemty12");
                createemty("makeembars_biger", stylecreate.left, "mapemty12");
            }
            if (i == 6)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty12");
                createemty("makeembars_biger", stylecreate.left, "mapemty12");
            }
            if (i == 7)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty12");
                createemty("makeemtyshipdie", stylecreate.left, "mapemty12");
            }
            if (i == 8)
            {
                createemty("powerpoles", stylecreate.betten, "mapemty12");
            }
        }
        StartCoroutine(emty13(location.z - 500));
    }
    IEnumerator emty13(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
               // StartCoroutine(Createcoinformap(13, locationemty.z));
                createemty("makeemtyshipdie", stylecreate.left, "mapemty13");
                createemty("makeembars_smore", stylecreate.betten, "mapemty13");
                createemty("makeembars_biger", stylecreate.righ, "mapemty13");
            }
            if (i == 2)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty13");
            }
            if (i == 3)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty13");
                createemty("makeemtyship", stylecreate.left, "mapemty13");
            }
            if (i == 4)
            {
                createemty("makeemtyshipdie", stylecreate.left, "mapemty13");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty13");
            }
            if (i == 5)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty13");
            }
            if (i == 6)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty13");
            }
            if (i == 7)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty13");
                createemty("makeemtyshipdie", stylecreate.left, "mapemty13");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty13");
            }
            if (i == 8)
            {
                createemty("makeemtyshipdie", stylecreate.left, "mapemty13");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty13");
            }
        }
        StartCoroutine(emty14(location.z - 500));

    }
    IEnumerator emty14(float tranformz)
    {

        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
               // StartCoroutine(Createcoinformap(14, locationemty.z));
                createemty("makeemtyship", stylecreate.left, "mapemty14");
                createemty("makeemtyship", stylecreate.righ, "mapemty14");
            }
            if (i == 2)
            {
                createemty("makeemtyshipdie", stylecreate.left, "mapemty14");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty14");
            }

            if (i == 4)
            {
                createemty("makeemtyshipdie", stylecreate.left, "mapemty14");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty14");
            }
            if (i == 5 || i == 6)
            {
                createemty("makeemtyshipdiemuving", stylecreate.betten, "mapemty14");
            }
            if (i == 6)
            {
                createemty("makeembars_big", stylecreate.left, "mapemty14");
                createemty("makeembars_biger", stylecreate.righ, "mapemty14");
            }
            if (i == 7)
            {
                createemty("powerpoles", stylecreate.left, "mapemty14");
                createemty("makeembars_biger", stylecreate.betten, "mapemty14");
                createemty("powerpoles", stylecreate.righ, "mapemty14");
            }
            if (i == 8)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty14");
            }
        }
        StartCoroutine(emty15(location.z - 500));

    }
    IEnumerator emty15(float tranformz)
    {
   
        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {//
               // StartCoroutine(Createcoinformap(15, locationemty.z));
                //createemty("makeembars_big", stylecreate.left, "mapemty15");
               // createemty("makeembars_biger", stylecreate.betten, "mapemty15");
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty15");
            }
            if (i == 2)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty15");
                createemty("makeembars_biger", stylecreate.left, "mapemty15");

            }

            if (i==3)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty15");
                //createemty("makeembars_smore", stylecreate.left, "mapemty15");
            }
            if (i == 4)
            {
                createemty("makeemtyshipdie", stylecreate.left, "mapemty15");
            }
            if (i == 5 )
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty15");
                //createemty("makeembars_biger", stylecreate.righ, "mapemty15");
            }
            if (i == 6)
            {
                createemty("makeemtyshipdie", stylecreate.left, "mapemty15");
            }
            if (i == 7)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty15");
            }
            if (i == 8)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty15");
               // createemty("makeembars_biger", stylecreate.left, "mapemty15");
            }
        }
       
        StartCoroutine(emty17(location.z - 500));
        //GetchildmapEmty();
    }
    IEnumerator emty16(float tranformz)
    {



        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
                createemty("makeembars_smore", stylecreate.righ, "mapemty16");
            }
            if (i>=3&&i<=6)
            {
                createemty("makeemtyshipdiemuving", stylecreate.righ, "mapemty16");
            }
            if (i == 7)
            {
                createemty("makeemtyshipdiemuving", stylecreate.betten, "mapemty16");
                createemty("makeembars_smore", stylecreate.left, "mapemty16");
            }
            if (i == 8)
            {
                createemty("makeemtyshipdiemuving", stylecreate.betten, "mapemty16");
            }
            if (i == 9)
            {
                createemty("makeemtyshipdiemuving", stylecreate.betten, "mapemty16");
            }
        }
        StartCoroutine(emty17(location.z - 500));
    }
    IEnumerator emty17(float tranformz)
    {
        for (int i = 1; i < 10; i++)
        {
            locationemty.z = tranformz + 8 * i;
            yield return new WaitForSeconds(delayy);
            if (i == 1)
            {
               // StartCoroutine(Createcoinformap(17, locationemty.z));
                createemty("makeemtyship", stylecreate.righ, "mapemty17");
            }
            if (i >= 2 && i <= 6)
            {
                createemty("makeemtyshipdie", stylecreate.righ, "mapemty17");
                if (i==4)
                {
                    createemty("makeembars_smore", stylecreate.betten, "mapemty17");
                }
                createemty("makeemtyshipdie", stylecreate.left, "mapemty17");
            }
            if (i == 7)
            {
                createemty("makeemtyshipdie", stylecreate.left, "mapemty17");
            }
            if (i == 8)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty17");
            }
            if (i == 9)
            {
                createemty("makeemtyshipdie", stylecreate.betten, "mapemty17");
            }
        }
        Addallitem(mapemty1);
        Addallitem(mapemty2);
        Addallitem(mapemty3);
        Addallitem(mapemty4);
        Addallitem(mapemty5);
        Addallitem(mapemty6);
        Addallitem(mapemty7);
        Addallitem(mapemty8);
        Addallitem(mapemty9);
        Addallitem(mapemty10);
        Addallitem(mapemty11);
        Addallitem(mapemty12);
        Addallitem(mapemty13);
        Addallitem(mapemty14);
        Addallitem(mapemty15);
        Addallitem(mapemty16);
        Addallitem(mapemty17);
    }
    float timedelay = 0.2f;
    /// <summary>
    /// TẠO COIN RIÊNG CHO TỪNG MAP
    /// </summary>
    /// <param name="map"></param>
    /// <param name="tranormzz"></param>
    /// <returns></returns>
    public IEnumerator Createcoinformap(int map , float tranormzz)
    {
       
        switch (map)
        {
            case 1:
                StartCoroutine(Createitem(3, tranormzz-6, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz , stylecreatecoin.backtoright, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(5, tranormzz+6, stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz+16, stylecreatecoin.backtolef, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 35, stylecreatecoin.up, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 45, stylecreatecoin.up, stylecreatecoinposisition.rightup));
                yield return new WaitForSeconds(timedelay);
                break;
            case 2:
                StartCoroutine(Createitem(5, tranormzz, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(5, tranormzz+ 31, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz+ 25, stylecreatecoin.backtolef, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz+ 10, stylecreatecoin.up, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz, stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(createallitem(tranormzz, createitemposition.righ));
                break;
            case 3:
                StartCoroutine(Createitem(8, tranormzz + 25, stylecreatecoin.line, stylecreatecoinposisition.leftup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(15, tranormzz , stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);

                StartCoroutine(Createitem(8, tranormzz + 50, stylecreatecoin.line, stylecreatecoinposisition.rightup));
                yield return new WaitForSeconds(timedelay);
                break;
            case 4:
                tranormzz = tranormzz + 26;
                StartCoroutine(Createitem(8, tranormzz - 7, stylecreatecoin.up, stylecreatecoinposisition.betwenup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(6, tranormzz - 20, stylecreatecoin.line, stylecreatecoinposisition.betwenup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(6, tranormzz+20, stylecreatecoin.line, stylecreatecoinposisition.betwenup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz - 7, stylecreatecoin.up, stylecreatecoinposisition.rightup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz - 7, stylecreatecoin.up, stylecreatecoinposisition.leftup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(createallitem(tranormzz, createitemposition.jumpupbetten));
                break;
            case 5:
                StartCoroutine(Createitem(4, tranormzz +15, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(4, tranormzz+15, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(10, tranormzz+3 , stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 25, stylecreatecoin.up, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(createallitem(tranormzz+18, createitemposition.betten));
                StartCoroutine(Createitem(8, tranormzz + 40, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                break;
            case 6:
                StartCoroutine(Createitem(8, tranormzz + 10, stylecreatecoin.line, stylecreatecoinposisition.betwenup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 10, stylecreatecoin.up, stylecreatecoinposisition.rightup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 10, stylecreatecoin.up, stylecreatecoinposisition.leftup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 40, stylecreatecoin.line, stylecreatecoinposisition.betwenup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 44, stylecreatecoin.up, stylecreatecoinposisition.rightup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 44, stylecreatecoin.up, stylecreatecoinposisition.leftup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(createallitem(tranormzz + 50, createitemposition.jumpupbetten));
                break;
            case 7: 
                StartCoroutine(Createitem(5,tranormzz +20,stylecreatecoin.line,stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(10, tranormzz + 35, stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(12, tranormzz + 35, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(createallitem(tranormzz + 26, createitemposition.betten));
                break;
            case 8:
                StartCoroutine(Createitem(3, tranormzz + 20, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz + 20, stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(6, tranormzz , stylecreatecoin.line+4, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz+25, stylecreatecoin.up, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(createallitem(tranormzz + 26, createitemposition.betten));
                break;
            case 9:
                StartCoroutine(Createitem(3, tranormzz + 20, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz + 20, stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz+6, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 25, stylecreatecoin.up, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(createallitem(tranormzz + 26, createitemposition.betten));
                break;
            case 10:
                StartCoroutine(Createitem(3, tranormzz + 20, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz + 6, stylecreatecoin.backtoright, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(createallitem(tranormzz + 26, createitemposition.betten));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 30, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 30, stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                break;
            case 11:
                StartCoroutine(Createitem(4, tranormzz+10, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 18, stylecreatecoin.up, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 50, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                break;
            case 12:
                StartCoroutine(Createitem(3, tranormzz + 11, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 40, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 24, stylecreatecoin.up, stylecreatecoinposisition.bettwen));
                break;
            case 13:
                StartCoroutine(Createitem(4, tranormzz +30 , stylecreatecoin.line, stylecreatecoinposisition.betwenup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(4, tranormzz +6 , stylecreatecoin.backtolef, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(createallitem(tranormzz + 40, createitemposition.jumpupbetten));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz-6 , stylecreatecoin.up, stylecreatecoinposisition.bettwen));
                break;
            case 14:    
                StartCoroutine(Createitem(4, tranormzz + 34, stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);

                StartCoroutine(Createitem(4, tranormzz + 42, stylecreatecoin.backtolef, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(4, tranormzz + 34, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);

                StartCoroutine(Createitem(8, tranormzz + 48, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);

                StartCoroutine(Createitem(4, tranormzz + 42, stylecreatecoin.backtoright, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz+4 , stylecreatecoin.line, stylecreatecoinposisition.rightup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz + 4, stylecreatecoin.line, stylecreatecoinposisition.leftup));
                yield return new WaitForSeconds(timedelay);

                StartCoroutine(Createitem(3, tranormzz + 4, stylecreatecoin.line, stylecreatecoinposisition.rightup));
                yield return new WaitForSeconds(timedelay);
                break;
            case 15:
                StartCoroutine(Createitem(3, tranormzz-4 , stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);

                StartCoroutine(Createitem(4, tranormzz +1 , stylecreatecoin.backtolef, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz +8, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);

                StartCoroutine(Createitem(4, tranormzz  +12 , stylecreatecoin.backtoright, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz + 18, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);

                StartCoroutine(Createitem(4, tranormzz + 22, stylecreatecoin.backtoright, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(6, tranormzz + 28, stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);

                StartCoroutine(Createitem(4, tranormzz + 38, stylecreatecoin.backtolef, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(3, tranormzz + 44, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                StartCoroutine(createallitem(tranormzz + 50, createitemposition.lef));
                break;
            case 16:
                StartCoroutine(Createitem(10, tranormzz, stylecreatecoin.line, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);

                StartCoroutine(Createitem(4, tranormzz + 1, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                break;
            case 17:
                StartCoroutine(Createitem(8, tranormzz + 1, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 18, stylecreatecoin.up, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 10, stylecreatecoin.line, stylecreatecoinposisition.rightup));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, tranormzz + 10, stylecreatecoin.line, stylecreatecoinposisition.leftup));
                yield return new WaitForSeconds(timedelay);
                break;
            default:
                break;
        }
  
    }


    int cchangeship = 0; 

    void createemty(string name , stylecreate style ,string namemap)
    {
        List<GameObject> listGameemty = new List<GameObject>();
              switch (namemap)
        {

            case "mapemty1":
                listGameemty = mapemty1;
                break;
            case "mapemty2":
                listGameemty = mapemty2;
                break;
            case "mapemty3":
                listGameemty = mapemty3;
                break;
            case "mapemty4":
                listGameemty = mapemty4;
                break;
            case "mapemty5":
                listGameemty = mapemty5;
                break;
            case "mapemty6":
                listGameemty = mapemty6;
                break;
            case "mapemty7":
                listGameemty = mapemty7;
                break;
            case "mapemty8":
                listGameemty = mapemty8;
                break;
            case "mapemty9":
                listGameemty = mapemty9;
                break;
            case "mapemty10":
                listGameemty = mapemty10;
                break;
            case "mapemty11":
                listGameemty = mapemty11;
                break;
            case "mapemty12":
                listGameemty = mapemty12;
                break;
            case "mapemty13":
                listGameemty = mapemty13;
                break;
            case "mapemty14":
                listGameemty = mapemty14;
                break;
            case "mapemty15":
                listGameemty = mapemty15;
                break;
            case "mapemty16":
                listGameemty = mapemty16;
                break;
            case "mapemty17":
                listGameemty = mapemty17;
                break;
            case "mapemty18":
                listGameemty = mapemty18;
                break;
            case "mapemty19":
                listGameemty = mapemty19;
                break;
            case "mapemty20":
                listGameemty = mapemty20;
                break;
            default:
                break;
        }
     
        if (name == "makeemtyshipdie")
        {
            cchangeship++;
            if (cchangeship <=10)
            {
                makeemtyshipdie = makeemtyshipdie1;
            }
            else if (cchangeship>=10)
            {
                makeemtyshipdie = makeemtyshipdie2;
            }
            if (cchangeship >=20)
            {
                cchangeship = 0;
            }
        }
        switch (name)
        {
            case "makeemtyshipdie":
                locationemty.y = 1.6f;
                switch (style)
                {
                    case stylecreate.left:
                        locationemty.x = -2.5f;
                        break;
                    case stylecreate.betten:
                        locationemty.x = 0f;
                        break;
                    case stylecreate.righ:
                        locationemty.x = 2.5f;
                        break;
                    default:
                        break;
                }
                listGameemty.Add(Instantiate(makeemtyshipdie, locationemty, transform.rotation) as GameObject);
                break;
            case "makeemtyship":
                locationemty.y = 0.6f;
                switch (style)
                {
                    case stylecreate.left:
                        locationemty.x = -2.5f;
                        break;
                    case stylecreate.betten:
                        locationemty.x = 0f;
                        break;
                    case stylecreate.righ:
                        locationemty.x = 2.5f;
                        break;
                    default:
                        break;
                }
                listGameemty.Add(Instantiate(makeemtyship, locationemty, transform.rotation) as GameObject);
                break;
            case "makeembars_smore":
                locationemty.y = 0.5f;
                switch (style)
                {
                    case stylecreate.left:
                        locationemty.x = -2.50f;
                        break;
                    case stylecreate.betten:
                        locationemty.x = 0f;
                        break;
                    case stylecreate.righ:
                        locationemty.x = 2.5f;
                        break;
                    default:
                        break;
                }
                listGameemty.Add(Instantiate(makeembars_smore, locationemty, transform.rotation) as GameObject);
                break;
            case "makeembars_big":
                locationemty.y = 1.4f;
                switch (style)
                {
                    case stylecreate.left:
                        locationemty.x = -2.50f;
                        break;
                    case stylecreate.betten:
                        locationemty.x = 0f;
                        break;
                    case stylecreate.righ:
                        locationemty.x = 2.50f;
                        break;
                    default:
                        break;
                }
                listGameemty.Add(Instantiate(makeembars_big, locationemty, transform.rotation) as GameObject);
                break;
            case "makeembars_biger":
                locationemty.y = 2f;
                switch (style)
                {
                    case stylecreate.left:
                        locationemty.x = -2.5f;
                        break;
                    case stylecreate.betten:
                        locationemty.x = 0;
                        break;
                    case stylecreate.righ:
                        locationemty.x = 2.5f;
                        break;
                    default:
                        break;
                }
                listGameemty.Add(Instantiate(makeembars_biger, locationemty, transform.rotation) as GameObject);
                break;
            case "powerpoles":
                locationemty.y = 2f;
                switch (style)
                {
                    case stylecreate.left:
                        locationemty.x = -1.25f;
                        break;
                    case stylecreate.betten:
                        locationemty.x = 1.25f;
                        break;
                    case stylecreate.righ:
                        locationemty.x = 1.25f;  
                        break;
                    default:
                        break;
                }
                listGameemty.Add(Instantiate(powerpoles, locationemty, transform.rotation) as GameObject);
                break;
            case "makeembridgeleft":
               // Debug.Log("goijjjjj");

                locationemty.x = 0f;
                switch (style)
                {
                    case stylecreate.left:
                        locationemty.y = 6f;
                        break;
                    case stylecreate.betten:
                        locationemty.y = 2.4f;
                        break;
                    case stylecreate.righ:
                        locationemty.y = 6f;
                        break;
                    default:
                        break;
                }
                listGameemty.Add(Instantiate(makeembridgeleft, locationemty, transform.rotation) as GameObject);
                break;
            case "makeembridgerigh":
                locationemty.x = 0f;
                switch (style)
                {
                    case stylecreate.left:
                        locationemty.y = 6f;
                        break;
                    case stylecreate.betten:
                        locationemty.y = 2.4f;
                        break;
                    case stylecreate.righ:
                        locationemty.y = 6f;
                        break;
                    default:
                        break;
                }
                listGameemty.Add(Instantiate(makeembridgerigh, locationemty, transform.rotation) as GameObject);
                break;
            case "makeembridge":
                locationemty.x = 0f;
                switch (style)
                {
                    case stylecreate.left:
                        locationemty.y = 6f;
                        break;
                    case stylecreate.betten:
                        locationemty.y = 2.4f;
                        break;
                    case stylecreate.righ:
                        locationemty.y = 6f;
                        break;
                    default:
                        break;
                }
                listGameemty.Add(Instantiate(makeembridge, locationemty, transform.rotation) as GameObject);
                break;
            case "makeemtyshipdiemuving":
                switch (style)
                {
                    case stylecreate.left:
                        locationemty.x = -2.5f;
                    
                        break;
                    case stylecreate.betten:
                        locationemty.x = 0f;
                 
                        break;
                    case stylecreate.righ:
                        locationemty.x = 2.5f;
                
                        break;
                    default:
                        break;
                }
                listGameemty.Add(Instantiate(makeemtyshipdiemuving, locationemty, transform.rotation) as GameObject);
                break;
            default:
                break;
        }
    }

    #endregion

    Vector3 tranformcoin;

    IEnumerator Createitem(int value , float tranformz,stylecreatecoin style, stylecreatecoinposisition styleposison)
    {
        yield return new WaitForSeconds(0);
        tranformcoin.z = tranformz;
        int top;
        float limvalue;
        switch (styleposison)
        {
            case stylecreatecoinposisition.left:
                tranformcoin.x = -2.5f;
                tranformcoin.y = 0.5f;
                break;
            case stylecreatecoinposisition.bettwen:
                tranformcoin.x = 0;
                tranformcoin.y = 0.5f;
                break;
            case stylecreatecoinposisition.right:
                tranformcoin.x = 2.5f;
                tranformcoin.y = 0.5f;
                break;
            case stylecreatecoinposisition.leftup:
                tranformcoin.x = -2.5f;
                tranformcoin.y = 3.6f;
                break;
            case stylecreatecoinposisition.betwenup:
                tranformcoin.x = 0;
                tranformcoin.y = 3.6f;
                break;
            case stylecreatecoinposisition.rightup:
                tranformcoin.x = 2.5f;
                tranformcoin.y = 3.6f;
                break;
            default:
                break;
        }

        switch (style)
        {
            case stylecreatecoin.line:
                for (int i = 0; i < value+1; i++)
                {                 
                    if (i>0)
                    {
                        ManagerAllcoin.Add(Instantiate(makeitemcoin, tranformcoin, transform.rotation) as GameObject);
                        tranformcoin.z += 2f;
                    }
                }
                break;
            case stylecreatecoin.backtolef:
                for (int i = 0; i < 4; i++)
                {
                    if (i > 0)
                    {
                      
                        ManagerAllcoin.Add(Instantiate(makeitemcoin, tranformcoin, transform.rotation) as GameObject);
                        tranformcoin.z += 2f;
                        tranformcoin.x -= 1.25f;
                    }
                }
                break;
            case stylecreatecoin.backtoright:
                for (int i = 0; i < 4; i++)
                {
                    if (i > 0)
                    {
                      
                        ManagerAllcoin.Add(Instantiate(makeitemcoin, tranformcoin, transform.rotation) as GameObject);
                        tranformcoin.z += 2f;
                        tranformcoin.x += 1.25f;
                    }
                }
                break;
            case stylecreatecoin.up:
                if ((value + 1) % 2 == 0)
                {
                    top = (value + 1) / 2;
                }
                else
                {
                    top = ((value + 1) / 2) + 1;
                }
                for (int i = 0; i < value+1; i++)
                {
                    if (i>0)
                    {
                        if (i<top)
                        {
                            ManagerAllcoin.Add(Instantiate(makeitemcoin, tranformcoin, transform.rotation) as GameObject);
                            tranformcoin.z += 1.6f;
                            tranformcoin.y += 1f;
                        }
                        if (i>= top)
                        {
                            tranformcoin.y -= 1f;
                            ManagerAllcoin.Add(Instantiate(makeitemcoin, tranformcoin, transform.rotation) as GameObject);
                            tranformcoin.z += 1.6f;
                        }
                    }
                }
                break;
            default:
                break;
        } 
    }
    Vector3 tranformiteflybt;
    Vector3 tranformiteflyl;
    Vector3 tranformiteflyr;
    bool alowshowitemaddcoin =  true;
    public List<GameObject> ManagerAllcoin = new List<GameObject>();
    public List<GameObject> ManagerAllitem = new List<GameObject>();

    /// <summary>
    /// tạo coin   cho item bay 1 đoạn
    /// </summary>
    /// <param name="tranformzst"></param>
    /// <returns></returns>
    public IEnumerator creacoinforitemfly(float tranformzst)
    {
      
        tranformiteflybt = new Vector3(0,14.5f, tranformzst);
        tranformiteflyl = new Vector3(-2.5f, 14.5f, tranformzst);
        tranformiteflyr = new Vector3(2.5f, 14.5f, tranformzst);
        List<GameObject> mbitem1 = new List<GameObject>();
        GameObject craate1 = null;
        GameObject craate2 = null;
        GameObject craate3 = null;
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.005f);
            if (i== 19)
            {
                int rann = Random.Range(0,4);
                switch (rann)
                {
                    case 0:
                        craate1 = makeitemhutcoin;
                        craate2 = makeitembaylong;
                        craate3 = makeitemx2coin;
                        break;
                    case 1:
                        craate1 = makeitembaylong;
                        craate2 = makeitemx2coin;
                        craate3 = makeitemvan;
                        break;
                    case 2:
                        craate1 = makeitemx2coin;
                        craate2 = makeitemvan;
                        craate3 = makeitembox;
                        break;
                    case 3:
                        craate1 = makeitemvan;
                        craate2 = makeitembox;
                        craate3 = makeitemkey;
                        break;
                    case 4:
                        craate1 = makeitembox;
                        craate2 = makeitemvan;
                        craate3 = makeitembaylong;
                        break;
                    case 5:
                        craate1 = makeitembox;
                        craate2 = makeitemhutcoin;
                        craate3 = makeitemvan;
                        break;
                    default:
                        break;
                }
                Instantiate(craate1, tranformiteflybt, transform.rotation);
                Instantiate(craate2, tranformiteflyl, transform.rotation);
                Instantiate(craate3, tranformiteflyr, transform.rotation);
                
                continue;
            }
            mbitem1.Add(Instantiate(makeitemcoin, tranformiteflybt, transform.rotation) as GameObject);
            mbitem1.Add(Instantiate(makeitemcoin, tranformiteflyl, transform.rotation) as GameObject);
            mbitem1.Add(Instantiate(makeitemcoin, tranformiteflyr, transform.rotation) as GameObject);
            if (i==18)
            {

            }
            tranformiteflybt.z += 2;
            tranformiteflyl.z += 2;
            tranformiteflyr.z += 2;
        }
        mbitem1[56].name = "coinend";
        mbitem1[55].name = "coinend";
        mbitem1[54].name = "coinend";
        mbitem1[54].gameObject.AddComponent<BoxCollider>();
        mbitem1[54].GetComponent<BoxCollider>().isTrigger = true;
        mbitem1[54].GetComponent<BoxCollider>().center = new Vector3(-0.177f,-120,2.467f);
        mbitem1[54].GetComponent<BoxCollider>().size = new Vector3(18,273,4);

        for (int i = 0; i < mbitem1.Count; i++)
        {
            ManagerAllcoin.Add(mbitem1[i]);

        }
    }

    bool AlowlcreatecoinforFly = true;
    /// <summary>
    /// tạo coin item bay 1 đoạn dài
    /// </summary>
    /// <param name="tranformzst">tọa độ z</param>
    /// <returns></returns>
    public IEnumerator createcoinforitemflylong(float tranformzst)
    {
        List<GameObject> mb = new List<GameObject>();
        int maxvalue = 150 + managerdata.manager.GetDataItemFly() * 45;
        if (AlowlcreatecoinforFly)
        {
            AlowlcreatecoinforFly = false;
            tranformiteflybt = new Vector3(0, 14.5f, tranformzst);
            tranformiteflyl = new Vector3(-2.5f, 14.5f, tranformzst);
            tranformiteflyr = new Vector3(2.5f, 14.5f, tranformzst);
            GameObject craate1 = null, craate2 = null, craate3 = null;
            Vector3 newvector = tranformiteflybt;
            float lastposisonx = newvector.x;
            float posisonx = newvector.x;
            int randum = Random.Range(0, 3);
            
            for (int i = 0; i < maxvalue; i++)
            {
                if (i%10==0&&i>0)
                {

                    randum = Random.Range(0, 3);
                    lastposisonx = newvector.x;
                    switch (randum)
                    {
                        case 0:
                            newvector = tranformiteflyl;
                            break;
                        case 1:
                            newvector = tranformiteflybt;
                            break;
                        case 2:
                            newvector = tranformiteflyr;
                            break;
                        default:
                            break;
                    }
                }
                mb.Add(Instantiate(makeitemcoin, newvector, transform.rotation) as GameObject);
                if (Manageritem.usingbayitembuy)
                {
                    if (i == maxvalue-1)
                    {
                        usingflyitemtranform = newvector.z + 2;
                    }
                }
                    if (i%10==0 && i > 0)
                    {

                        if (mb[i - 1].gameObject.transform.position.x == -2.5f)
                    {
                        if (mb[i].gameObject.transform.position.x == 0)
                        {
                            mb[i - 1].gameObject.transform.position = new Vector3(-1.25f, newvector.y, newvector.z - 2);
                        }
                        if (mb[i].gameObject.transform.position.x == 2.5f)
                        {
                            mb[i - 1].gameObject.transform.position = new Vector3(1.25f, newvector.y, newvector.z - 2);
                            mb[i - 2].gameObject.transform.position = new Vector3(0, newvector.y, newvector.z - 4);
                            mb[i - 3].gameObject.transform.position = new Vector3(-1.25f, newvector.y, newvector.z - 6);
                        }
                    }
                    if (mb[i - 1].gameObject.transform.position.x == 0)
                    {
                        if (mb[i].gameObject.transform.position.x == -2.5f)
                        {
                            mb[i - 1].gameObject.transform.position = new Vector3(-1.25f, newvector.y, newvector.z - 2);
                        }
                        if (mb[i].gameObject.transform.position.x == 2.5f)
                        {
                            mb[i - 1].gameObject.transform.position = new Vector3(1.25f, newvector.y, newvector.z - 2);
                        }
                    }
                    if (mb[i - 1].gameObject.transform.position.x == 2.5f)
                    {
                        if (mb[i].gameObject.transform.position.x == 0f)
                        {
                            mb[i - 1].gameObject.transform.position = new Vector3(1.25f, newvector.y, newvector.z - 2);
                        }
                        if (mb[i].gameObject.transform.position.x == -2.5f)
                        {
                            mb[i - 1].gameObject.transform.position = new Vector3(-1.25f, newvector.y, newvector.z - 2);
                            mb[i - 2].gameObject.transform.position = new Vector3(0, newvector.y, newvector.z - 4);
                            mb[i - 3].gameObject.transform.position = new Vector3(1.25f, newvector.y, newvector.z - 6);
                        }
                    }
                }
                tranformiteflybt.z += 2;
                tranformiteflyl.z += 2;
                tranformiteflyr.z += 2;
                newvector.z += 2;
                if (i == maxvalue-1)
                {
                    int rann = Random.Range(0, 4);
                    switch (rann)
                    {
                        case 0:
                            craate1 = makeitemhutcoin;
                            craate2 = makeitemx2coin;
                            craate3 = makeitemx2coin;
                            break;
                        case 1:
                            craate1 = makeitembox;
                            craate2 = makeitemx2coin;
                            craate3 = makeitemvan;
                            break;
                        case 2:
                            craate1 = makeitemx2coin;
                            craate2 = makeitemvan;
                            craate3 = makeitembox;
                            break;
                        case 3:
                            craate1 = makeitemvan;
                            craate2 = makeitembox;
                            craate3 = makeitemkey;
                            break;
                        case 4:
                            craate1 = makeitembox;
                            craate2 = makeitemvan;
                            craate3 = makeitemvan;
                            break;
                        case 5:
                            craate1 = makeitembox;
                            craate2 = makeitemhutcoin;
                            craate3 = makeitemvan;
                            break;
                        default:
                            break;
                    }
                    Instantiate(craate1, tranformiteflybt, transform.rotation);
                    Instantiate(craate2, tranformiteflyl, transform.rotation);
                    Instantiate(craate3, tranformiteflyr, transform.rotation);
                }
                yield return new WaitForSeconds(0.01f);
            }
            mb[maxvalue-1].name = "coinendtem2";
            mb[maxvalue-1].gameObject.AddComponent<BoxCollider>();
            mb[maxvalue-1].GetComponent<BoxCollider>().center = new Vector3(-0.389f, -100, 9.8f);
            mb[maxvalue-1].GetComponent<BoxCollider>().isTrigger = true;
            mb[maxvalue-1].GetComponent<BoxCollider>().size = new Vector3(20, 307, 20.1f);
            mb[maxvalue-1].GetComponent<SphereCollider>().center = new Vector3(0,0,4.4f);
        }
        coinend = mb[maxvalue-1];
       
        for (int i = 0; i < mb.Count; i++)
        {
            ManagerAllcoin.Add(mb[i]);
        }
        AlowlcreatecoinforFly = true;
    }
    GameObject coinend = null;
    public static float usingflyitemtranform;
    Vector3 tranformitem;
    /// <summary>
    ///   tạo item tại vị trí cố định randum  loại item
    /// </summary>
    /// <param name="transformz"></param>
    /// <param name="stylecreate"></param>
    /// <returns></returns>
    public IEnumerator createallitem(float transformz,createitemposition stylecreate)
    {
        tranformitem.z = transformz;
        switch (stylecreate)
        {
            case createitemposition.lef:
                tranformitem.x = -2.5f;
                tranformitem.y = 0.7f;
                break;
            case createitemposition.righ:
                tranformitem.x = 2.5f;
                tranformitem.y = 0.7f;
                break;
            case createitemposition.betten:
                tranformitem.x = 0f;
                tranformitem.y = 0.7f;
                break;
            case createitemposition.lefup:
                tranformitem.x = -2.5f;
                tranformitem.y = 4f;
                break;
            case createitemposition.righup:
                tranformitem.y = 4f;
                tranformitem.x = 2.5f;
                break;
            case createitemposition.bettenup:
                tranformitem.y = 4f;
                tranformitem.x = 0f;
                break;
            case createitemposition.jumpleft:
                tranformitem.x = -2.5f;
                break;
            case createitemposition.jupmrifht:
                tranformitem.x = 2.5f;
                break;
            case createitemposition.jumpbetten:
                tranformitem.x = 0f;
                break;
            case createitemposition.jumpupleft:
                tranformitem.y = 6.7f;
                tranformitem.x = -2.5f;
                break;
            case createitemposition.jumpupright:
                tranformitem.y = 6.7f;
                tranformitem.x = 2.5f;
                break;
            case createitemposition.jumpupbetten:
                tranformitem.y = 6.7f;
                tranformitem.x = 0f;
                break;
            default:
                break;
        }
        string nameitem = "x2";
        int rancoin = Random.Range(0,16);
        switch (rancoin)
        {
            case 0:
                nameitem = "x2coin";
                break;
            case 1:
                nameitem = "giay";
                break;
            case 2:
                nameitem = "hutcoin";
                break;
            case 3:
                nameitem = "baycoin";
                break;
            case 4:
                nameitem = "baylongcoin";
                break;
            case 5:
                nameitem = "key";
                break;
            case 6:
                nameitem = "box";
                break;
            case 7:
                nameitem = "van";
                break;
            default:
                break;
        }
        switch (nameitem)
        {
            case "x2coin":
                ManagerAllitem.Add(Instantiate(makeitemx2coin, tranformitem, transform.rotation) as GameObject);
                break;
            case "giay":
                ManagerAllitem.Add(Instantiate(makeitemnhay, tranformitem, transform.rotation) as GameObject);
                break;
            case "hutcoin":
                ManagerAllitem.Add(Instantiate(makeitemhutcoin, tranformitem, transform.rotation) as GameObject);
                break;
            case "baycoin":
                ManagerAllitem.Add(Instantiate(makeitembay, tranformitem, transform.rotation) as GameObject);
                break;
            case "baylongcoin":
                ManagerAllitem.Add(Instantiate(makeitembaylong, tranformitem, transform.rotation) as GameObject);
                break;
            case "key":
                ManagerAllitem.Add(Instantiate(makeitemkey, tranformitem, transform.rotation) as GameObject);
                break;
            case "box":
                ManagerAllitem.Add(Instantiate(makeitembox, tranformitem, transform.rotation) as GameObject);
                break;
            case "van":
                ManagerAllitem.Add(Instantiate(makeitemvan, tranformitem, transform.rotation) as GameObject);
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(0);
    }
    float checkshow;
   public static float checkshowx = 100;
    public GameObject check;
    // Update is called once per frame
    void Update () {
        if (Playermuving.player!= null)
        {
            checkshow = Playermuving.player.gameObject.transform.position.z;

            if (checkshow >= checkshowx)
            {
                checkshowx += 80;
                randummap = Random.Range(0, 3);
                StartCoroutine(randumallmap(randummap));
            }
        }
      
    }
    void Deletecoin()
    {
        StartCoroutine(Delaydestroi());

    }

    public List<GameObject> hidecoin = new List<GameObject>();
    IEnumerator Delaydestroi()
    {
        for (int i = 0; i < hidecoin.Count; i++)
        {
            hidecoin[i].SetActive(false);
        }
        yield return new WaitForSeconds(0);
        for (int i = 0; i < ManagerAllcoin.Count; i++)
        {
            Destroy(ManagerAllcoin[i]);
        }
        ManagerAllcoin.Clear();
        for (int i = 0; i < ManagerAllitem.Count; i++)
        {
            Destroy(ManagerAllitem[i]);
        }
        ManagerAllitem.Clear();
        if (Dontrandum)
        {
            Dontrandum = false;
            randumtheemty();
        }
    }
    float muving  = -300;
    /// <summary>
    /// đưa toàn bộ các đối tượng về phía sau khi có item trượt hoặc key
    /// </summary>
    /// <returns></returns>
    public IEnumerator MuvingbackAllemtyWenhaveitemVan(bool checkvan)
    {
        if (alowback)
        {
            alowback = false;
            if (checkvan==false)
            {
                Playermuving.isplay = false;
            }
            Playermuving.backnowmuvingship = true;
            yield return new WaitForSeconds(0.02f);
            Playermuving.backnowmuvingship = false;

            for (int i = 0; i < allemty.Count; i++)
            {
                allemty[i].gameObject.transform.Translate(new Vector3(0, 0, muving));
            }
            yield return new WaitForSeconds(0.2f);
            Enable();
            Deletecoin();
            randumtheemty();
            Playermuving.isplay = true;
            MapHowToPlay.SetActive(false);
            StartCoroutine( CreateCoinWenDie(Playermuving.player.gameObject.transform.position.z+16));
            StartCoroutine(delay(checkvan));
            Playermuving.player.StartCoroutine(Playermuving.player.backtotruposison());
            if (Playermuving.player.gameObject.transform.position.z > Map4.transform.position.z && Playermuving.player.gameObject.transform.position.z < Map4.transform.position.z + 90)
            {
                Playermuving.player.gameObject.transform.position = new Vector3(0, Playermuving.player.gameObject.transform.position.y, Map4.transform.position.z + 90);
            }
        }
    }
    bool alowback = true;
    bool Dontrandum = false;
    public void Backshipitem()
    {
        //Dontrandum = true;
        //for (int i = 0; i < allemty.Count; i++)
        //{
        //    allemty[i].gameObject.transform.Translate(new Vector3(0, 0, -160));
        //}
        //Deletecoin();

    }
    IEnumerator delay(bool cv)
    {
        yield return new WaitForSeconds(0.2f);
        alowback = true;
        if (cv == false)
        {
            Playermuving.isplay = true;
        }
        Playermuving.isplay = true;
    }

    /// <summary>
    /// back toàn bộ map về đằng sau khi chết - k đủ  - k chọn key
    /// </summary>
    /// <returns></returns>
    public IEnumerator MuvingbackAllemtyWendie()
    {
        
        if (callback)
        {
            Playermuving.isplay = false;
            yield return new WaitForSeconds(0);
            for (int i = 0; i < allemty.Count; i++)
            {
                allemty[i].gameObject.transform.Translate(new Vector3(0, 0, muving));
            }
            //Map_GAME.gameObject.transform.Translate(new Vector3(0, 0, muving));
            Enable();
            Deletecoin();
            randumtheemty();
            StartCoroutine(delaycallback());
            MapHowToPlay.SetActive(false);
            StartCoroutine(CreateCoinWenDie(Playermuving.player.gameObject.transform.position.z + 16));
            Playermuving.player.StartCoroutine(Playermuving.player.backtotruposison());
            if ((Playermuving.player.gameObject.transform.position.z> Map4.transform.position.z&&Playermuving.player.gameObject.transform.position.z < Map4.transform.position.z+90) 
                )
            {
               Playermuving.player.gameObject.transform.position = new Vector3(0, Playermuving.player.gameObject.transform.position.y, Map4.transform.position.z + 85);
            } 
        }
    }

    bool callback = true;
   
    IEnumerator delaycallback()
    {
        yield return new WaitForSeconds(0.5f);
        callback = true; 
    }

    
    bool ismakecoin = true;

    /// <summary>
    /// Sinh Coin trong thác nước
    /// </summary>
    public IEnumerator CreaTeCoinInmap5()
    {
        if (ismakecoin)
        {
            ismakecoin = false;
            StartCoroutine(Createitem(3, Map4.transform.position.z + 30, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
            yield return new WaitForSeconds(timedelay);
            StartCoroutine(Createitem(3, Map4.transform.position.z + 48, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
            yield return new WaitForSeconds(timedelay);
            StartCoroutine(Createitem(3, Map4.transform.position.z + 60, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
            yield return new WaitForSeconds(10);
            ismakecoin = true;
        }
         
    }
    /// <summary>
    /// tạo
    /// </summary>
    /// <param name="ztranform"></param>
    private IEnumerator CreateCoinWenDie(float ztranform)
    {
        int stylecreate = Random.Range(0,6);
        switch (stylecreate)
        {
            case 0:
                StartCoroutine(Createitem(5, ztranform , stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(5, ztranform , stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(5, ztranform , stylecreatecoin.line, stylecreatecoinposisition.left));
                break;
            case 1:
                StartCoroutine(Createitem(5, ztranform, stylecreatecoin.line, stylecreatecoinposisition.right));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(5, ztranform, stylecreatecoin.line, stylecreatecoinposisition.left));
                break;
            case 2:
                StartCoroutine(Createitem(5, ztranform, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(5, ztranform, stylecreatecoin.line, stylecreatecoinposisition.left));
                break;
            case 3:
                StartCoroutine(Createitem(5, ztranform, stylecreatecoin.line, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(5, ztranform, stylecreatecoin.line, stylecreatecoinposisition.right));
                break;
            case 4:
                StartCoroutine(Createitem(8, ztranform, stylecreatecoin.up, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, ztranform, stylecreatecoin.line, stylecreatecoinposisition.right));
                break;
            case 5:
                StartCoroutine(Createitem(8, ztranform, stylecreatecoin.up, stylecreatecoinposisition.bettwen));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, ztranform, stylecreatecoin.up, stylecreatecoinposisition.left));
                yield return new WaitForSeconds(timedelay);
                StartCoroutine(Createitem(8, ztranform, stylecreatecoin.up, stylecreatecoinposisition.right));
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// ẩn hết map emty
    /// </summary>
    public void Enable()
    {
       for (int i = 0; i < allemty.Count; i++)
        {
            allemty[i].gameObject.SetActive(false);
        }
    }
    private List<GameObject> allemty = new List<GameObject>();
    void Addallitem(List<GameObject> map)
    {
        for (int i = 0; i < map.Count; i++)
        {
            allemty.Add(map[i]);
         //   map[i].transform.parent = Map_GAME.transform;
        }
    }
    public GameObject Map_GAME;
}