using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// class manage Pause
/// </summary>
public class inthepanelpause : MonoBehaviour {
    public GameObject panelpause;
    public GameObject panelshowitem;
    public static inthepanelpause pauses;
    // set hiển thị ở thanh menu main
    public GameObject panelmain; // panel mainmenu
    public GameObject btnbuyvan; // pnel mua ván trượt
    public GameObject btnsetinginthemain; // nút mở cài đặt pử main menu
    public GameObject btnopenshopinthemain; // nút mở shop ở menu chính
    public GameObject tabplaymain;  // nút tàng hình tab play
    public GameObject panelseting; // ----------------------------------------------
    public GameObject showtexdelay;
    // Use this for initialization

    bool isclic;
    void Start () {
        playagain = true;
        pauses = this;
        ispause = false;
        isclic = true;
    }
   public static float datatime;
    /// <summary>
    /// dừng chơi game
    /// </summary>
    public void pause()
    {
        if (Playermuving.speedmuving > 10)
        {
            if (Delaystart.delaysecons == 3)
            {
                // evensystem.SetActive(true);
                autoscale.atsc.toscale();
                Soundmanager.soundmanager.Pause();
                panelpause.SetActive(true);
                panelshowitem.SetActive(false);
                //Playermuving.player.PauseGame();
                Debug.Log(datatime);
                if (Time.timeScale != 0)
                {
                    datatime = Time.timeScale;
                }
                Time.timeScale = 0;
            }
        }
    }

    public static bool fixFlylong = false;
   // public GameObject evensystem;
    /// <summary>
    /// chơi tiếp
    /// </summary>
    public void Resume()
    {
        showtextwhait.SetActive(true);
        Soundmanager.soundmanager.Continued();
        panelpause.SetActive(false);
        Debug.Log(datatime);
        panelshowitem.SetActive(true);
        amindelay.SetBool("delay", false);
        playagain = true;
        isclic = true;
    }
    public Animator amindelay;
    public Text delaysecon;
    public GameObject showtextwhait;

    int delaysecons = 3;
    public void showdelaytext()
    {
        delaysecon.text = delaysecons.ToString();
        delaysecons--;
    }
    /// <summary>
    /// de lay for clic pause Again
    /// </summary>
    /// <returns></returns>
    public IEnumerator delayforBack()
    {
        isclic = false;
        amindelay.SetBool("delay",true);
        int delayseconvalue = 3;
        delaysecon.text = delayseconvalue.ToString();

        showtextwhait.SetActive(true);
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.05f);
            Playermuving.player.PauseGame();
            // pause();
            if (i==10||i==20||i==29)
            {
                delayseconvalue--;
                delaysecon.text = delayseconvalue.ToString();
            }
        }
        showtextwhait.SetActive(false);
        panelshowitem.SetActive(true);
      //  yield return new WaitForSeconds(1f);
        amindelay.SetBool("delay", false);
        Playermuving.player.ExitPause();
        yield return new WaitForSeconds(0.3f);
        playagain = true;
        isclic = true;
    }
    public static  bool playagain;
    public static bool ispause;
    public GameObject btnMe;

    /// <summary>
    /// mở menu cài đặt
    /// </summary>
    public void OnenMenuSetting()
    {
        panelmain.SetActive(true);
        btnMe.SetActive(false);
        panelseting.SetActive(true);
        btnbuyvan.SetActive(false);
        btnsetinginthemain.SetActive(false);
        btnopenshopinthemain.SetActive(false);
        tabplaymain.SetActive(false);
        ispause = true;
    }
    /// <summary>
    /// close All menu in the main
    /// </summary>
    public void closemenuseting()
    {
        panelmain.SetActive(false);
        ispause = false;
    }

    /// <summary>
    /// trở về menuchinhs
    /// </summary>
  
}
