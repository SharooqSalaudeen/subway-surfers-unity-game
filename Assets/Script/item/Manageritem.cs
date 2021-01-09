using UnityEngine;
using System.Collections;

/// <summary>
/// class quản lý một số item
/// </summary>
public class Manageritem : MonoBehaviour {
    public static bool giay;
    public static bool x2coin;
    public static bool hutcoin;
    public static bool baycoin;
    public static bool van;
    public static bool baylongcoin;
    public static bool box;
    public static bool usingbayitembuy;
    public static Manageritem mngitem;
    // Use this for initialization
    void Awake()
    {
        van = false;
        giay = false;
        x2coin = false;
        hutcoin = false;
        baycoin = false;
        baylongcoin = false;
        usingbayitembuy = false;
    }
    /// <summary>
    /// xóa toàn bộ  item lúc ơplayer chết
    /// </summary>
    public void DeleteAllItemWendie()
    {
        van = false;
        giay = false;
        x2coin = false;
        hutcoin = false;
        baycoin = false;
        baylongcoin = false;
        usingbayitembuy = false;
    }
    void Start () {
        mngitem = this;
  }
    public IEnumerator delayfordestroiiteam(int value, string nameiteam)
    {
        Debug.Log(giay);
        yield return new WaitForSeconds(5);
        Debug.Log("sau " + giay);
        switch (nameiteam)
        {
            case "giay":
                giay = false;
                Debug.Log("sau " + giay);
                break;
            case "x2coin":
                Manageritem.x2coin = false;
                break;
            case "jupm":
                Manageritem.baycoin = false;
                break;
            case "jupmtong":
                Manageritem.baylongcoin = false;
                break;
            case "hutcoin":
                Manageritem.hutcoin = false;
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
