using UnityEngine;
using System.Collections;

public class Chekdestroi : MonoBehaviour {
   public  Transform target;
    float speed = 10f;
    public GameObject coin;
	// Use this for initialization
	void Start () {
      
        alow = true;
        if (this.gameObject.tag == "coin")
        {
            coin = gameObject.transform.Find("Coincon").gameObject;
            StartCoroutine(timer());
        }
    }
    bool rotaychidcoi;
    IEnumerator timer()
     {
    float ran = Random.Range(0, 1f);
    yield return new WaitForSeconds(ran);
    rotaychidcoi = true;
      }
public  bool alow;
	// Update is called once per frame
	void Update () {
        if (Playermuving.player != null)
        {
            checkalloject();
            if (this.gameObject.tag == "coin")
            {
                if (rotaychidcoi)
                {
                    coin.transform.Rotate(new Vector3(0, 150 * Time.deltaTime, 0));
                }
                if (Playermuving.isplay == false && Playermuving.player.gameObject.transform.position.z > 10)
                {
                  //  Destroy(this.gameObject);
                }
            }
        }
	}



    /// <summary>
    /// đưa tòa bộ các đối tượng vật cản trong khoảng của player về phía sau
    /// </summary>
    /// <returns></returns>
     IEnumerator checkpositionformuving()
    {
        yield return new WaitForSeconds(0);
        if (gameObject.tag == "coin" || gameObject.tag == "taucat" || gameObject.tag == "ship" || gameObject.tag == "shipnotdie" || gameObject.tag == "shipnotdie" || gameObject.tag == "cau" || gameObject.tag == "cau" || gameObject.tag == "thanhchan" || gameObject.tag == "cau" || gameObject.tag == "thanhchan" || gameObject.tag == "thanhchan")
        {
            if (Playermuving.gettranformofplayerforitemvantomuving < Makesupway.checkshowx)
            {
                    if (this.transform.position.z <= Makesupway.checkshowx && this.transform.position.z >= Makesupway.checkshowx - 80)
                    {
                        this.transform.Translate(new Vector3(0, 0, -100));
                    }
            }
         
        }
       

    }


    void checkalloject()
    {
       
        if (this.gameObject.tag == "coin")
        {
            if (this.gameObject.name== "coinendtem2")
            {
                if (this.transform.position.z < Playermuving.player.gameObject.transform.position.z)
                {
                    Playermuving.player.StartCoroutine(Playermuving.player.exitdelaydestroiitemlong());
                     Destroy(this.gameObject);
                }
            }
            if (gameObject.name == "coinend")
            {
                if (transform.position.z < Playermuving.player.gameObject.transform.position.z)
                {
                    Playermuving.player.StartCoroutine(Playermuving.player.exitdelaydestroiitem());
                    Destroy(this.gameObject);
                }
            }
            if (Manageritem.hutcoin&& this.gameObject.name != "coinendtem2" && this.gameObject.name != "coinend")
            {
                if (gameObject.transform.position.z <= Playermuving.player.gameObject.transform.position.z + 7)
                {
                    if (Vector3.Distance(this.transform.position, Playermuving.player.gameObject.transform.position) < 9)
                    {
                        muvingcointoplayer();
                    }
                }
            }
        }
    }

    /// <summary>
    /// di chuyển coin đến player khi ăn được hút coin
    /// </summary>
    void muvingcointoplayer()
    {
        if (Manageritem.baylongcoin)
        {
            speed = speed * 1.3f;
        }
        else
        {
            speed = 10;
        }
        if (gameObject.transform.position.z < Playermuving.player.gameObject.transform.position.z)
        {

            transform.Translate(new Vector3(0, 0, 2 * speed * Time.deltaTime));
        }
        if (gameObject.transform.position.z > Playermuving.player.gameObject.transform.position.z)
        {
            transform.Translate(new Vector3(0, 0, -2 * speed * Time.deltaTime));
        }
        //x
        if (gameObject.transform.position.x < Playermuving.player.gameObject.transform.position.x)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (gameObject.transform.position.x > Playermuving.player.gameObject.transform.position.x)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        // y
        if (gameObject.transform.position.y < Playermuving.player.gameObject.transform.position.y)
        {
            this.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        if (gameObject.transform.position.y > Playermuving.player.gameObject.transform.position.y)
        {
            this.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        //   this.transform.position = Vector3.Lerp(this.transform.position, Playermuving.player.gameObject.transform.position, speed*Time.deltaTime);
    }
}
