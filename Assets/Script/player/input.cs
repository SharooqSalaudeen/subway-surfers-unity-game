using UnityEngine;
using System.Collections;
/// <summary>
/// class input quản lý input  Swipe
/// </summary>
public class input : MonoBehaviour {

    public GameObject fly;
    int checkgetmosechange = 0;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    // Use this for initialization
    void Start () {
        checkgetmosechange = 0;

        delaytimerforitemvan = 0;
        alow = 0;
        alow1 = 0;
    }
    float delaytimerforitemvan;
    int alow;
    int alow1;

    float lasttimer;
    float secontme;
	// Update is called once per frame
	void Update () {
        if (Playermuving.player != null)
        {
                if (Input.mousePosition.x > (Screen.width - Screen.width) && Input.mousePosition.x < Screen.width - (Screen.width / 7) * 6)
                {
                    if (Input.mousePosition.y > (Screen.height*0.84) && Input.mousePosition.y < (Screen.height*0.91f))
                    {
                        Debug.Log("ok");
                    }
                }

          //  }
            if (Playermuving.isplay)
            {
                if (Manageritem.van == false)
                {
                    getinputitemvan();  
                }
                if (Input.GetMouseButtonDown(0))
                {

                    if (Input.mousePosition.x > (Screen.width - Screen.width) && Input.mousePosition.x < Screen.width - (Screen.width / 7) * 6)
                    {
                        if (Input.mousePosition.y > (Screen.height * 0.84) && Input.mousePosition.y < (Screen.height * 0.91f))
                        {
                           // inthepanelpause.pauses.pause();
                        }
                    }
                    if (Input.mousePosition.x > (Screen.width - Screen.width) && Input.mousePosition.x < Screen.width - (Screen.width / 7) * 6)
                    {
                        if (Input.mousePosition.y > (Screen.height * 0.2) && Input.mousePosition.y < (Screen.height * 0.26f))
                        {
                            if (fly.gameObject.transform.position.x> (Screen.width- Screen.width))
                            {
                               // UImanager.uimanager.ClicOnFly();
                            }
                           
                        }
                    }

                }

            }
        }
    }

    /// <summary>
    /// input cho item van
    /// </summary>
    void getinputitemvan()
    {
        delaytimerforitemvan += Time.deltaTime;
        if (
            Manageritem.van == false&&
            Manageritem.baycoin == false && 
            Manageritem.baycoin == false&&
            Playermuving.player.gameObject.transform.position.y<11&&
            Manageritem.baycoin==false&&
            Manageritem.van == false && 
            Playermuving.player.gameObject.transform.position.z >-2&&
            UImanager.getvan&&
            Time.deltaTime != 0
            )
        {
            if (Input.GetMouseButtonDown(0) && alow == 0)
            {
                alow = 1;
                lasttimer = delaytimerforitemvan;
            }

            if (Input.GetMouseButtonUp(0) && alow1 == 0)
            {
                alow1 = 1;
            }
            if (Input.GetMouseButtonDown(0) && alow == 1 && alow1 == 1)
            {
                secontme = delaytimerforitemvan;
                if (secontme - lasttimer <= 0.2f)
                {
                    if (Manageritem.baycoin == false)
                    {
                        StartCoroutine(inthevanite());

                    }
                }
                else if (secontme - lasttimer > 0.2f)
                {
                }
                StartCoroutine(delayclicagain());
            }
        }
    
    }

    /// <summary>
    /// item ván trượt
    /// </summary>
    /// <returns></returns>
   public IEnumerator inthevanite()
    {
        yield return new WaitForSeconds(0);
        Playermuving.player.StartCoroutine(Playermuving.player.delayfordestroiitemmain());
    }
    public IEnumerator delayclicagain()
    {
        yield return new WaitForSeconds(1);
        alow = 0;
        alow1 = 0;
    }
    /// <summary>
    ///  Swipe cảm ứng
    /// </summary>
    public void Swipe()
    {
        if (Input.mousePosition.y <Screen.height -Screen.height/8&&Input.mousePosition.y >Screen.height - (Screen.height/8)*7)
        {
            if (Input.GetMouseButtonDown(0) && checkgetmosechange == 0)
            {
                firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                checkgetmosechange = 1;
            }
            if (checkgetmosechange == 1)
            {
                StartCoroutine(Getstopmose());
            }
        }
       
    }



    /// <summary>
    ///  input  mobile lấy tọa độ
    ///  
    /// </summary>
    /// <returns></returns>
    IEnumerator Getstopmose()
    {

        Vector2 savervector2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (firstPressPos != savervector2)
        {

            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            //normalize the 2d vector
            currentSwipe.Normalize();
            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                // lên
                Playermuving.player.Jump();
                checkgetmosechange = 0;
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                // xuống
                Playermuving.player.StartCoroutine(Playermuving.player.Muvingdow());
                checkgetmosechange = 0;
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Playermuving.player.StartCoroutine(Playermuving.player.Muvingright());
                // trái
                checkgetmosechange = 0;
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                // phải
                Playermuving.player.StartCoroutine(Playermuving.player.Muvingleft());
                checkgetmosechange = 0;
            }
        }
        yield return new WaitForSeconds(0.005f);
    }
}
