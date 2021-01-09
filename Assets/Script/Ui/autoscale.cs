using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// class tự động scale điểm số
/// </summary>
public class autoscale : MonoBehaviour {
    public Image imgcoin, valuecoin;
    public static autoscale atsc;
    int valuescale;
    int valuescalecoin;
    public Text distance, valuecointxt;
    string stroooo, strshow,strcoin0;
    // Use this for initialization
    void Start () {
        atsc = this;
        stroooo = "";
        strcoin0 = "";
        playcoin = true;

    }
    string str, strcoin;
    public static bool playcoin;
    /// <summary>
    /// tự động scale nền hiển thị điểm theo con số
    /// </summary>
   public void toscale()
    {
        str = distance.text;
        
        valuescale = str.ToCharArray().Length;
        if (valuescale <=2)
        {
           // imgcoin.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100 + valuescale * 30);
            stroooo = "0000";
        }
        else if (valuescale==3)
        {
           // imgcoin.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 80 + valuescale * 30);
            stroooo = "000";
        }
        else if (valuescale == 4)
        {
           // imgcoin.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 60 + valuescale * 30);
            stroooo = "00";
        }
        else if (valuescale == 5)
        {
            //imgcoin.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 40 + valuescale * 30);
            stroooo = "0";
        }
        else if (valuescale > 5)
        {
           // imgcoin.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 30 + valuescale * 30);
            stroooo = "";

        }
        strshow = stroooo + distance.text;
        distance.text = strshow;
        strcoin = valuecointxt.text;
        valuescalecoin = strcoin.ToCharArray().Length;
        if (valuescalecoin <= 2)
        {
            if (valuescalecoin == 1|| valuescalecoin == 0)
            {
               // valuecoin.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 50 + valuescale * 30);
                strcoin0 = "000";
            }
            if (valuescalecoin == 2)
            {
              //  valuecoin.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 45 + valuescale * 30);
                strcoin0 = "00";
            }
        }
        else if (valuescalecoin == 3)
        {
          //  valuecoin.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 45  + valuescale * 30);
            strcoin0 = "0";
        }
        else if (valuescalecoin == 4)
        {
           // valuecoin.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 40 + valuescale * 30);
            strcoin0 = "0";
        }
        else if (valuescalecoin >= 5)
        {
          //  valuecoin.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 30 + valuescale * 30);
            strcoin0 = "";
        }
       
        valuecointxt.text = strcoin0 + strcoin;
      //  strcoin = valuecointxt.text;
    }
    
    // Update is called once per frame
    void Update () {

        //if (Playermuving.player != null)
        //{
        //    //if (Playermuving.isplay)
        //    //{
        if (Playermuving.isplay)
        {

          
                toscale();
      
        }

    }
}
