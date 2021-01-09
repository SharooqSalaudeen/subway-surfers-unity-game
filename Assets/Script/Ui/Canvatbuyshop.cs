using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Canvatbuyshop : MonoBehaviour {
    public Image imgvanchinh;
    public Transform playeritem; // tranform chứa các item để showh
    public Transform playeritemCharacter; // tranform chứa các item để showh
    public Text cost;

    public Transform tranformlist; //tranform chứa item 3D
    public Transform tranformlistcharacter; //tranform chứa CHARACTER 3D
    public List<Image> img = new List<Image>(); // các ảnh item 3D
    public List<Image> imgcharacter = new List<Image>(); // list  các item 3D
    public List<GameObject> item = new List<GameObject>(); //các item để showh
    public List<GameObject> itemcharacter= new List<GameObject>(); //các charcter để showh
    public GameObject Objectcheck;

    public static bool openshopcharacter;
    // Use this for initialization
    void Start () {

        openshopcharacter = true;
        foreach (Transform item in tranformlist) // load các ảnh item tronh thanh kéo
        {
            if (item.gameObject.name != "m")
            {
                img.Add(item.gameObject.GetComponent<Image>());
            }
        }
        foreach (Transform itemm in playeritem) // load các item trong nhân v
        {
            item.Add(itemm.gameObject);
        }


        foreach (Transform item in tranformlistcharacter) // load các ảnh character tronh thanh kéo
        {
            if (item.gameObject.name != "m")
            {
                imgcharacter.Add(item.gameObject.GetComponent<Image>());
            }
        }

        foreach (Transform item in playeritemCharacter) // load các character để hiển thị
        {
            itemcharacter.Add(item.gameObject);
        }
        showcointext();
    }
	


    /// <summary>
    /// kiểm tra xem đang chọn đến cái item nào thì cho cái đó quay
    /// </summary>
    public void CheckiteminTheList()
    {
        if (openshopcharacter==false)
        {
            inthelisvan();
        }
        else
        {
            inthelisCharactre();
        }
    }

    /// <summary>
    /// quản lý list ảnh character
    /// </summary>
    void inthelisCharactre()
    {
        for (int i = 0; i < img.Count; i++)
        {
            if (Vector3.Distance(Objectcheck.transform.position, imgcharacter[i].gameObject.transform.position) <0.2f)
            {
                bettent = imgcharacter[i].gameObject;
                imgcharacter[i].gameObject.GetComponent<rotaychilditem>().istrue = true;
                imgcharacter[i].gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                ShowCharacter(imgcharacter[i].gameObject.name);
                showCostCharacter(imgcharacter[i].gameObject.name);
            }  
            else
            {
                imgcharacter[i].gameObject.GetComponent<rotaychilditem>().istrue = false;
                imgcharacter[i].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
    /// <summary>
    /// kiểm tra tên nhân vật đẻ chek và hiển thị lên màn hình hiển thị
    /// </summary>
    /// <param name="nameitem"></param>
    void ShowCharacter(string nameitem)
    {
        for (int i = 0; i < itemcharacter.Count; i++)
        {
            if (itemcharacter[i].name == nameitem)
            {
                itemcharacter[i].gameObject.SetActive(true);
            }
            else
            {
                itemcharacter[i].gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// lấy giá bán của character lên nút bấm mua
    /// </summary>
    /// <param name="namecharacter"></param>
    void showCostCharacter(string namecharacter)
    {
        switch (namecharacter)
        {
            case "nvchinh":
                if (managerdata.manager.GetCharacternvchinh() == 0)
                {
                    cost.text = "95000";
                }
                else
                {
                    if (namecharacter != managerdata.manager.Getnowcharacter())
                    {
                        cost.text = "SELECT";
                    }
                    else if (namecharacter == managerdata.manager.Getnowcharacter())
                    {
                        cost.text = "SELECTED";
                    }
                }
                break;
            case "nvgirl":
                if (managerdata.manager.GetCharacternvgirl() == 0)
                {
                    cost.text = "75000";
                }
                else
                {
                    if (namecharacter != managerdata.manager.Getnowcharacter())
                    {
                        cost.text = "SELECT";
                    }
                    else if (namecharacter == managerdata.manager.Getnowcharacter())
                    {
                        cost.text = "SELECTED";
                    }
                }
                break;
            case "nvgau":
                if (managerdata.manager.GetCharacternvGau() == 0)
                {
                    cost.text = "66000";
                }
                else
                {
                    if (namecharacter != managerdata.manager.Getnowcharacter())
                    {
                        cost.text = "SELECT";
                    }
                    else if (namecharacter == managerdata.manager.Getnowcharacter())
                    {
                        cost.text = "SELECTED";
                    }
                }
                break;
            default:
                break;
        }
    }




/// <summary>
///  quản lý list ảnh item
/// </summary>
void inthelisvan()
    {
        for (int i = 0; i < img.Count; i++)
        {
            if (Vector3.Distance(Objectcheck.transform.position, img[i].gameObject.transform.position) < 0.2f)
            {
                bettent = img[i].gameObject;
                img[i].gameObject.GetComponent<rotaychilditem>().istrue = true;
                img[i].gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                Showiteminplayer(img[i].gameObject.name);
                GetCost(img[i].gameObject.name);
            }
            //    if (img[i].gameObject.transform.position.z > -6.8f && img[i].gameObject.transform.position.z < -6.2f)
            //{
              
            //}
            else
            {
                img[i].gameObject.GetComponent<rotaychilditem>().istrue = false;
                img[i].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    /// <summary>
    /// lấy item vào cnhaan vật để check hiển thị
    /// </summary>
    /// <param name="nameitem"></param>
    public void Showiteminplayer(string nameitem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].name == nameitem)
            {
                item[i].gameObject.SetActive(true);
            }
            else
            {
                item[i].gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// lấy giá của cái item vào trongtex giá
    /// </summary>
    public void GetCost(string nameitem)
    {
        switch (nameitem)
        {
            case "vancamap":
                if (managerdata.manager.Getvancamap() ==0)
                {
                    cost.text = "99000";
                }
                else
                {
                    if (nameitem != managerdata.manager.Getvanuser())
                    {
                        cost.text = "SELECT";
                    }
                    else if (nameitem == managerdata.manager.Getvanuser())
                    {
                        cost.text = "SELECTED";
                    }
                }
                break;
            case "vanchinh":
                if (managerdata.manager.Getvanchinh() == 0)
                {
                    cost.text = "55000";
                }
                else
                {
                    if (nameitem != managerdata.manager.Getvanuser())
                    {
                        cost.text = "SELECT";
                    }
                    else if (nameitem == managerdata.manager.Getvanuser())
                    {
                        cost.text = "SELECTED";
                    }
                }
                break;
            case "vantron":
                if (managerdata.manager.Getvantron() == 0)
                {
                    cost.text = "47000";
                }
                else
                {
                    if (nameitem != managerdata.manager.Getvanuser())
                    {
                        cost.text = "SELECT";
                    }
                    else if (nameitem == managerdata.manager.Getvanuser())
                    {
                        cost.text = "SELECTED";
                    }
                }
                break;
            default:
                break;
        }
    }

    public Text cointxt;
    public Text keytxt;

    /// <summary>
    /// hiện coin lên màn hình
    /// </summary>
    public void showcointext()
    {
        cointxt.text = managerdata.manager.Getcoin().ToString();
        keytxt.text = managerdata.manager.getkey().ToString();
    }
    GameObject bettent;

    /// <summary>
    /// clic mua ván trượt và character mới
    /// </summary>
    public void ClicBuyvan()
    {
        string strcheck = cost.text;
        if (openshopcharacter == false)
        {
            if (strcheck == "SELECTED")
            {
                return;
            }
            if (strcheck == "SELECT")
            {
                managerdata.manager.Savevanuser(bettent.name);
                cost.text = "SELECTED";
            }
            if (strcheck != "SELECT" && strcheck != "SELECTED")
            {
                if (int.Parse(strcheck) <= managerdata.manager.Getcoin())
                {
                    managerdata.manager.Savevanuser(bettent.name);
                    managerdata.manager.savecoin(-int.Parse(strcheck));
                    switch (bettent.name)
                    {
                        case "vanchinh":
                            managerdata.manager.Savevanchinh(1);
                            break;
                        case "vantron":
                            managerdata.manager.Savevantron(1);
                            break;
                        case "vancamap":
                            managerdata.manager.Savevancamap(1);
                            break;
                        default:
                            break;
                    }
                    cost.text = "SELECTED";
                }
            }
        }
        else
        {
            if (strcheck == "SELECTED")
            {
                return;
            }
            if (strcheck == "SELECT")
            {
                managerdata.manager.Setnowcharacter(bettent.name);
                cost.text = "SELECTED";
            }
            if (strcheck != "SELECT" && strcheck != "SELECTED")
            {
                if (int.Parse(strcheck) <= managerdata.manager.Getcoin())
                {
                    managerdata.manager.Setnowcharacter(bettent.name);
                    managerdata.manager.savecoin(-int.Parse(strcheck));
                    switch (bettent.name)
                    {
                        case "nvchinh":
                            managerdata.manager.SetCharacternvchinh(1);
                            break;
                        case "nvgirl":
                            managerdata.manager.SetCharacternvgirl(1);
                            break;
                        case "nvgau":
                            managerdata.manager.SetCharacternvGau(1);
                            break;
                        default:
                            break;
                    }
                    cost.text = "SELECTED";
                }
            }
        }
        showcointext();
    }
    public GameObject panebuycharacter;
    public GameObject panebuyvan;
    public GameObject panebuyall;

    public GameObject charactershowvan;
    public GameObject characterselecshow;
    /// <summary>
    /// hiện bản mua character
    /// </summary>
    public void BTNbuyCharacter()
    {

        Debug.Log("chọn nv");
        openshopcharacter = true;
        panebuyall.GetComponent<ScrollRect>().content = panebuycharacter.GetComponent<RectTransform>();
        panebuycharacter.SetActive(true);
        characterselecshow.SetActive(true);
        charactershowvan.SetActive(false);
        panebuyvan.SetActive(false);
    }

    /// <summary>
    /// hiện bảng mua ván trượt
    /// </summary>
    public void BTNbuyvan()
    {
      //  Debug.Log("chọn ván");
        openshopcharacter = false;
        panebuyall.GetComponent<ScrollRect>().content = panebuyvan.GetComponent<RectTransform>();
        panebuycharacter.SetActive(false);
        panebuyvan.SetActive(true);
        characterselecshow.SetActive(false);
        charactershowvan.SetActive(true);
    }


    void Update()
    {
       // Debug.Log("sdfgh");
       // Debug.Log(panel.transform.position);
    }

    public void GetCharacTerOnClic(GameObject namecharacter)
    {
        Debug.Log(namecharacter.name);
        showCostCharacter(namecharacter.name);
        ShowCharacter(namecharacter.name);
    }
    public GameObject panel;
}
